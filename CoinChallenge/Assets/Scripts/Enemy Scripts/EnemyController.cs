using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //Enemy movements
    NavMeshAgent agent;
    public Transform[] waypoints; //Tableau de waypoints
    int waypointIndex; //Index o� sont choisis les waypoints
    Vector3 target;
    [SerializeField] FieldOfView fovController;
    GameObject player { get { return fovController.playerRef; } }
    [SerializeField] float maxDistance = 10;

    [SerializeField] MeshRenderer rend;


    bool chasePlayer
    {
        get
        {
            /*if (Vector3.Distance(transform.position, player.transform.position) > maxDistance)
                return false;*/
            Debug.Log(agent.pathStatus);
            if (agent.pathStatus != NavMeshPathStatus.PathComplete)
                return false;
            return true;
        }
    }

    //Enemy detection

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
        StartCoroutine(PatrolCorout());
    }


    IEnumerator PatrolCorout()
    {
        rend.material.color = Color.green;
        UpdateDestination();
        while (!fovController.playerDetected)
        {
            //Si la distance entre l'agent et la cible (waypoint) est � moins d'un m�tre ->
            if (Vector3.Distance(transform.position, target) < 1)
            {
                IterateWaypointIndex();
                UpdateDestination();
            }
            yield return null;
        }

        StartCoroutine(ChaseCorout());

    }

    IEnumerator ChaseCorout()
    {
        rend.material.color = Color.red;

        do
        {
            agent.SetDestination(player.transform.position);
            Debug.Log(player.transform.position);
            while (agent.pathPending)
            {
                yield return null;
            }
            yield return null;
        }
        while (chasePlayer);

        StartCoroutine(PatrolCorout());
    }

    void UpdateDestination()
    {
        target = waypoints[waypointIndex].position; //update la destination du waypoint suivant � partir de la positon en cours
        agent.SetDestination(target); //d�init la cible � suivre
    }

    void IterateWaypointIndex()
    {
        //Si la distance de la cible est � moins d'1 m�tre, augmente l'index de waypoints par 1
        waypointIndex++;
        if (waypointIndex == waypoints.Length) //Si l'index est egal au nombre de waypoints disponibles, retourne au d�but (0)
        {
            waypointIndex = 0; //Retour au d�but du tableau
        }

    }
}
