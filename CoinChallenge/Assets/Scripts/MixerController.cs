using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerController : MonoBehaviour
{
    [SerializeField] private AudioMixer coinChallengeAudioMixer;

    public void SetMasterVolume(float sliderValue)
    {
        coinChallengeAudioMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
    }
    public void SetMusicsVolume(float sliderValue)
    {
        coinChallengeAudioMixer.SetFloat("MusicsVolume", Mathf.Log10(sliderValue) * 20);
    }    
    public void SetAmbientsVolume(float sliderValue)
    {
        coinChallengeAudioMixer.SetFloat("AmbientsVolume", Mathf.Log10(sliderValue) * 20);
    }
    public void SetSFXVolume(float sliderValue)
    {
        coinChallengeAudioMixer.SetFloat("SFXVolume", Mathf.Log10(sliderValue) * 20);
    }
}
