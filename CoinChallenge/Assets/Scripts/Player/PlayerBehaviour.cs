using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour, IDamageable
{
    public void OnDamage(int damage)
    {
        Debug.Log("J'ai �t� touch�");
    }

    public void OnKilled()
    {
        Debug.Log("Je suis mort");
    }
}
