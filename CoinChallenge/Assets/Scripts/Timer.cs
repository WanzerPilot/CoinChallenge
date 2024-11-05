using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class Timer : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float remainingTime;
    public int time;

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
        time += timeToAdd;
        remainingTime += 5;
    }

    IEnumerator TimerCorout()
    {
        while (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            UpdateTextUI();
            yield return null;
        }

        if (onTimeOut != null)
        {
            onTimeOut();
        }
    }

    void UpdateTextUI()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (remainingTime < 0)
        {
            remainingTime = 0;
            // GameOver(); Quand arrive à 0, envoyer la fonction GameOver, qui est encore à faire...
            timerText.color = Color.red; //S'affiche en rouge quand le timer atteint 0
        }
    }

}
