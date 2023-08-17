using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundtracks : MonoBehaviour
{
    private float vol;

    void Start()
    {
        vol = gameObject.GetComponent<AudioSource>().volume;

        if (DataHolder.music)
            gameObject.GetComponent<AudioSource>().volume = vol;
        else
            gameObject.GetComponent<AudioSource>().volume = 0;

        if (gameObject.tag != "LevelMusic")
            gameObject.GetComponent<AudioSource>().timeSamples = DataHolder.timeAudio_MainAndLevels;
    }

    void Update()
    {
        if (DataHolder.music)
            gameObject.GetComponent<AudioSource>().volume = vol;
        else
            gameObject.GetComponent<AudioSource>().volume = 0;
    }
}
