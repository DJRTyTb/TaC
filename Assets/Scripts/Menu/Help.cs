using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Help : MonoBehaviour
{
    public AudioSource Audio;

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void MainMenu()
    {
        DataHolder.timeAudio_MainAndLevels = Audio.timeSamples;
        SceneManager.LoadScene("MainMenu");
    }
}
