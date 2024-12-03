using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndLevelStats : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI killText;
    [SerializeField] TextMeshProUGUI timeText;

    // Start is called before the first frame update
    void Start()
    {
        if (DataKeeper.instance == null) return;
        scoreText.text = DataKeeper.instance.score.ToString();

        if (DataKeeper.instance == null) return;
        timeText.text = DataKeeper.instance.elapseTime.ToString();

        if (DataKeeper.instance == null) return;
        killText.text = DataKeeper.instance.killCount.ToString();
    }
}
