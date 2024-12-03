using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI timerText;
    float remainingTime;
    public int maxTime;

    public float elapseTime {  get { return maxTime - remainingTime; } }

    public static Timer instance;

    public delegate void OnTimeOut();
    public OnTimeOut onTimeOut;


    public void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(TimerCorout());
    }

    public void AddTime(int timeToAdd)
    {
        remainingTime += timeToAdd;
    }

    IEnumerator TimerCorout()
    {
        remainingTime = maxTime;
        while (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            if (remainingTime < 0) remainingTime = 0;
            UpdateTextUI();
            yield return null;
        }

        if (onTimeOut != null)
        {
            onTimeOut();
        }
        
        if (remainingTime <= 0) 
        {
            SceneManager.LoadScene("GameOverNoTime");
        }
    }

    public void StopTimer()
    {
        StopAllCoroutines();
    }

    void UpdateTextUI()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
