using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour, IDamageable
{
    public AudioClip onDamage;
    public AudioSource audioSource;

    public void OnDamage(int damage)
    {
        Debug.Log("J'ai �t� touch�");
        audioSource.PlayOneShot(onDamage, 0.6f);
    }

    public void OnKilled()
    {
        SceneManager.LoadScene("GameOverNoHP");
    }
}
