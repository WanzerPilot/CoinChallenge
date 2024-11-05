using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static HealthBar instance;
    public Image lifeGauge;

    [SerializeField] 
    HealthSystem healthSystem;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        healthSystem.onDamageTaken += UpdateHealth;
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        lifeGauge.fillAmount = healthSystem.lifeRate;
    }


}
