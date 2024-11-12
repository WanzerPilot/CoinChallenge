using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //Enemy movements
    NavMeshAgent agent;
 
    int waypointIndex; //Index où sont choisis les waypoints
    Vector3 target;
    [SerializeField] FieldOfView fovController;
    GameObject player { get { return fovController.playerRef; } }

    [SerializeField] float attackRange = 1.5f; 
    [SerializeField] int attackDamage = 1;
   

    [SerializeField] MeshRenderer rend;

    public static List<EnemyController> enemyList;

    public WaypointGroup refWaypointGroup;


    bool chasePlayer
    {
        get
        {

            if (agent.pathStatus != NavMeshPathStatus.PathComplete)
                return false;

            if (Vector3.Distance(agent.destination, player.transform.position) > fovController.radius) return false;
            if (!playerHealthSystem.IsAlive) return false;
            return true;
        }
    }

    HealthSystem playerHealthSystem;

    //Enemy detection

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
        SetNewAffectation(refWaypointGroup);

        playerHealthSystem = player.GetComponent<HealthSystem>();
    }

    private void OnEnable()
    {
        if (enemyList == null) enemyList = new List<EnemyController>();
        enemyList.Add(this);
    }

    private void OnDisable()
    {
        if (enemyList == null) enemyList = new List<EnemyController>();
        enemyList.Remove(this);
    }


    IEnumerator PatrolCorout()
    {
        rend.material.color = Color.green;
        UpdateDestination();
        while (!fovController.playerDetected)
        {
            //Si la distance entre l'agent et la cible (waypoint) est à moins d'un mètre ->
            if (Vector3.Distance(transform.position, target) < agent.stoppingDistance + 0.1f)
            {
                IterateWaypointIndex();
                UpdateDestination();
            }
            yield return null;
        }

        if (playerHealthSystem.IsAlive)
        StartCoroutine(ChaseCorout());


    }

    IEnumerator ChaseCorout()
    {
        rend.material.color = Color.red;

        do
        {
            agent.SetDestination(player.transform.position);
            while (agent.pathPending)
            {
                yield return null;
            }

            if (agent.remainingDistance < attackRange)
            {
                Attack();
                yield return new WaitForSeconds(1);
            }

            yield return null;
        }
        while (chasePlayer);

        StartCoroutine(PatrolCorout());
    }

    void UpdateDestination()
    {
        target = refWaypointGroup.waypointsList[waypointIndex].position; //update la destination du waypoint suivant à partir de la positon en cours
        agent.SetDestination(target); //déinit la cible à suivre
    }

    void IterateWaypointIndex()
    {
        //Si la distance de la cible est à moins d'1 mètre, augmente l'index de waypoints par 1
        waypointIndex++;
        if (waypointIndex == refWaypointGroup.waypointsList.Count) //Si l'index est egal au nombre de waypoints disponibles, retourne au début (0)
        {
            waypointIndex = 0; //Retour au début du tableau
        }

    }

    void Attack()
    {
        playerHealthSystem.SetDamage(attackDamage);
    }

    public void SetNewAffectation(WaypointGroup waypointGroup)
    {
        StopAllCoroutines();
        refWaypointGroup = waypointGroup;
        waypointIndex = 0;
        StartCoroutine(PatrolCorout());
    }
}
