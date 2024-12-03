using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayObjects : MonoBehaviour
{

    AudioSource SFX;
    void Start()
    {
        SFX = GetComponent<AudioSource>();
    }

    public void playSound()
    {
        SFX.Play();
    }
}
