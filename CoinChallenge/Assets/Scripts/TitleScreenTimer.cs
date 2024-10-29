using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenTimer : MonoBehaviour
{
    [SerializeField] float timer = 2f;

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}