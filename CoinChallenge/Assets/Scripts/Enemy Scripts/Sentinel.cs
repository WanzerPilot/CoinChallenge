using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sentinel : MonoBehaviour
{
    [SerializeField] List<MobAffectation> m_Affectations;

    [SerializeField] FieldOfView fovController;
    GameObject player { get { return fovController.playerRef; } }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (fovController.playerDetected)
        {
            SetNewAffectation();
        }
    }

    void SetNewAffectation()
    {
        foreach (var affectation in m_Affectations)
        {
            affectation.initialWaypointGroup = affectation.enemy.refWaypointGroup;
            affectation.enemy.SetNewAffectation(affectation.waypointGroup);
        }
    }

    void SetInitialAffectation()
    {
        foreach (var affectation in m_Affectations)
        {
            affectation.enemy.SetNewAffectation(affectation.initialWaypointGroup);
        }
    }

    private void OnDisable()
    {
        SetInitialAffectation();
    }
}
[System.Serializable]
public class MobAffectation
{
    public EnemyController enemy;
    public WaypointGroup waypointGroup;

    [System.NonSerialized]
    public WaypointGroup initialWaypointGroup;
}
