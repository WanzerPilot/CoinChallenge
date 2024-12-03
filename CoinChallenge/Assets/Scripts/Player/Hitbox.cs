using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HitBox")
        {
            HealthSystem healthSystem = other.transform.parent.GetComponent<HealthSystem>();
            healthSystem.SetDamage(10);
            Debug.Log("Enemy has been killed");
        }
    }
}
