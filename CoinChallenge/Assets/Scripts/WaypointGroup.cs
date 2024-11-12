using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointGroup : MonoBehaviour
{
    [SerializeField] public List<Transform> waypointsList;


    // Start is called before the first frame update
    void Start()
    {

    }

    public void GetAllWaypoints()
    {
        waypointsList = new List<Transform>();
        foreach (Transform t in transform)
        {
            waypointsList.Add(t);
        }
    }
}
