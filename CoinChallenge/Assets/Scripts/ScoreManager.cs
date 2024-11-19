using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public int score;
    public int goalScoreMin = 10;
    public TextMeshProUGUI scoreText;

    public static ScoreManager instance;

    public void Awake()
    {
        instance = this;
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
