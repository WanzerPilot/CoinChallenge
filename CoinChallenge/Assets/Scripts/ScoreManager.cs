using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public int score;
    public int swapMusicScore = 10;
    public int goalScoreMin = 50;
    public TextMeshProUGUI scoreText;

    public AudioSync other;

    public static ScoreManager instance;

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
            Debug.Log("Porte ouverte");
        }
        scoreText.text = "Score: " + score.ToString();
    }

}
