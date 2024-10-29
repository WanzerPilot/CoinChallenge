using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCollection : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        ICollectable icollectable = other.GetComponent<ICollectable>();
        if (icollectable == null) return;
        icollectable.OnCollected(this.gameObject);
    }
}
