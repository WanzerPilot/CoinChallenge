using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HitBox")
        {
            Destroy(other.transform.parent.gameObject);
        }
    }
}
