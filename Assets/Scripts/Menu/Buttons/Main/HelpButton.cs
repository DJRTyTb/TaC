using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpButton : ButtonsMain
{
    private SpriteRenderer sp;
    public AudioSource audio_;
    public Sprite[] sparr;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
        sp.sprite = sparr[1];
    }

    private void OnMouseExit()
    {
        sp.sprite = sparr[0];
    }

    private void OnMouseDown()
    {
        DataHolder.timeAudio_MainAndLevels = audio_.timeSamples;
        SceneManager.LoadScene("Help");
    }
}
