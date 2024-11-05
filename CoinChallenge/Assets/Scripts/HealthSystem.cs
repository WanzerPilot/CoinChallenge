using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public float lifeRate
    {
        get
        {
            return (float)currentHealth / (float)maxHealth;
        }
    }

    public bool IsAlive
    {
        get { return currentHealth > 0; }
    }

    IDamageable iDamageable;

    public delegate void OnDamageTaken();
    public OnDamageTaken onDamageTaken;

    private void Awake()
    {
        iDamageable = GetComponent<IDamageable>();
        if (iDamageable == null)
        {
            Debug.LogError("L'interface iDamageable n'a pas été trouvé sur le gameobject " + gameObject.name);
        }
    }

    void Start()
    {
        currentHealth = maxHealth;
    }


    void Update()
    {

    }

    public void SetDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        else
        {
            iDamageable.OnDamage(damage);
            if (onDamageTaken != null)
            {
                onDamageTaken();
            }
        }


        if (currentHealth == 0)
        {
            Debug.Log("Je suis mort");
            iDamageable.OnKilled();
        }

    }
}
