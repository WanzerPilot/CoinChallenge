using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAsChild : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
    }

    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
