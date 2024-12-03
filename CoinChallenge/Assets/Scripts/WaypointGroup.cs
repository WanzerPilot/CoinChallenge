using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointGroup : MonoBehaviour
{
    [SerializeField] public List<Transform> waypointsList;

    public void GetAllWaypoints()
    {
        waypointsList = new List<Transform>();
        foreach (Transform t in transform)
        {
            waypointsList.Add(t);
        }
    }
}
