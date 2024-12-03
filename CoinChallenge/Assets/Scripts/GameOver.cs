using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Timer;

public class GameOverMenuController : MonoBehaviour
{
    public static GameOverMenuController Instance;
    [SerializeField] GameObject parent;


    void Awake()
    {
        Instance = this; //instancie le GameOverMenuController d�s le d�marrage
    }

    private void Start()
    {
        SetActive(false); //d�sactiv� au d�marrage d'une partie

        Timer.instance.onTimeOut += DisplayGameOver;
    }

    public void SetActive(bool active)
    {
        parent.SetActive(active); //S'affiche quand l'�tat IsLost est rencontr�
    }

    public void DisplayGameOver()
    {
        SetActive(true);
    }


    public void Retry()
    {
        SceneManager.LoadScene("Level01");
    }


    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }



    public void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
        Application.Quit();
    }
}

