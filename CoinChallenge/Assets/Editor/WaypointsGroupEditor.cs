using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(WaypointGroup))]
public class WaypointsGroupEditor : Editor
{
    WaypointGroup _target;

    private void OnEnable()
    {
        _target = (WaypointGroup)target;
        _target.GetAllWaypoints();
    }

    public void OnSceneGUI()
    {
        DrawPath();
    }

    void DrawPath()
    {
        if (_target.waypointsList.Count < 2) return;

        for (int i = 0; i < _target.waypointsList.Count; i++)
        {

            if (i <  _target.waypointsList.Count - 1)
            {
                Handles.DrawLine(_target.waypointsList[i].position, _target.waypointsList[i + 1].position, 3);
            }
            else
            {
                Handles.DrawLine(_target.waypointsList[i].position, _target.waypointsList[0].position, 3);
            }
        }

    }
}
