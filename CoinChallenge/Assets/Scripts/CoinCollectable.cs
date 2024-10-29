using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectable : MonoBehaviour, ICollectable
{
    [SerializeField] int CoinValue = 1;
    [SerializeField] int TimeValue = 1;

    public void OnCollected(GameObject Collector)
    {
        ScoreManager.instance.AddScore(CoinValue);
        Timer.instance.AddTime(TimeValue);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
