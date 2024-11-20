using UnityEngine;
using System.Collections;

public class AudioSync : MonoBehaviour
{
    //set these in the inspector!
    public AudioSource master;
    public AudioSource slave;

    public static AudioSync instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        //Lance les deux musiques en même temps, mais pas au même volume
        master.loop = true;
        master.volume = 1.0f;

        slave.loop = true;
        slave.volume = 0f;

        slave.Play();
        master.Play();
    }

    void Update()
    {
        //Sync des deux audios. Hors script, via seulement des audiosources, les musiques avaient tendance à se desync.
        slave.timeSamples = master.timeSamples;
    }

    public void scoreSwapOnMinimumScore()
    {
        //Fonction pour qu'à un scertain score, la piste change
            slave.volume = 1.0f;
            master.volume = 0f;
    }
}
