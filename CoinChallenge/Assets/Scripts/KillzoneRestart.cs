using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillzoneRestart : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        Destroy(other.gameObject);
        SceneManager.LoadScene("Level01");
    }
}
