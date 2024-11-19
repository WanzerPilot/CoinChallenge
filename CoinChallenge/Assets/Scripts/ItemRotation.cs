using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotation : MonoBehaviour
{
    //Options de rotation y, x, ou z
    public bool rotateX = false;
    public bool rotateY = true; //sur true par défaut
    public bool rotateZ = false;

    public float speed = 50f;

    void Update()
    {
        Vector3 rotation = Vector3.zero;
        if (rotateX)
        {
            rotation += Vector3.right;
        }        
        
        if (rotateY)
        {
            rotation += Vector3.up;
        }        
        
        if (rotateZ)
        {
            rotation += Vector3.forward;
        }

        transform.Rotate(rotation * speed * Time.deltaTime);
    }
}
