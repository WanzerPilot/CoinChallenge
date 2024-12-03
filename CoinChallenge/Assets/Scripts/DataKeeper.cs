using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataKeeper : MonoBehaviour
{

    public static DataKeeper instance;

    public float elapseTime;
    public float score;
    public float killCount;

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

    }

    public void GetPersistentData()
    {
        elapseTime = Timer.instance.elapseTime;
        score = ScoreManager.instance.score;
        killCount = ScoreManager.instance.killMobCount;
    }
}
