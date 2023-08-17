using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource Audio;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Levels();
        }
    }

    public void MusicSettings()
    {
        DataHolder.music = !DataHolder.music;
    }

    public void Levels()
    {
        DataHolder.timeAudio_MainAndLevels = Audio.timeSamples;
        SceneManager.LoadScene("LevelsMenu");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
