using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{

void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
