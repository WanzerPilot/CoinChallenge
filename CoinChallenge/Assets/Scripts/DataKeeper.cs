using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataKeeper : MonoBehaviour
{

    public static DataKeeper instance;

    void Awake()
    {
        if (instance != null && instance != this) 
        { 
            Destroy(this.gameObject); 
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        Timer.instance.onTimeOut += OnTimeOut;
    }

    void OnTimeOut()
    {
        Debug.Log("Jeu terminé");
    }
}
