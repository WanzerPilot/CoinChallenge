using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{

    public int score;
    public int swapMusicScore = 10;
    public int goalScoreMin = 50;
    public int killMobCount;
    public TextMeshProUGUI scoreText;

    public AudioSync other;

    public static ScoreManager instance;

    public UnityEvent onScoreReached;

    public void Awake()
    {
        instance = this;
    }

    public void Update()
    {
        if (score >= swapMusicScore)
        {
            AudioSync.instance.scoreSwapOnMinimumScore();
        }
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        if (score >= goalScoreMin) 
        {
            onScoreReached.Invoke();
        }
        scoreText.text = "Score: " + score.ToString();
    }

}
