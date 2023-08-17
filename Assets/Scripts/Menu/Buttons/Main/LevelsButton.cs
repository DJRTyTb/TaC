using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsButton : ButtonsMain
{
    public Sprite[] sparr;// 0 N, 1 A
    public AudioSource audio_;
    private SpriteRenderer sp;

    private void Start()
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
        SceneManager.LoadScene("LevelsMenu");
    }
}
/*public override void MainFunction()
    {
        menu.Levels();
    }*/