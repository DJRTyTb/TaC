using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicButton : ButtonsMain
{
    public AudioSource audio_;
    private SpriteRenderer sp;
    private bool music = true;
    public Sprite[] sparr;// 0 AN, 1 AA, 2 NN, 3 NA

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        audio_ = GetComponentInChildren<AudioSource>();
        audio_.pitch = 1;
        audio_.volume = 1f;
        audio_.timeSamples = DataHolder.timeAudio_MainAndLevels;

        music = DataHolder.music;
        OnMouseExit();
    }

    private void OnMouseEnter()
    {
        switch (music)
        {
            case true:
                sp.sprite = sparr[1];
                break;
            case false:
                sp.sprite = sparr[3];
                break;
        }
    }

    private void OnMouseExit()
    {
        switch (music)
        {
            case true:
                sp.sprite = sparr[0];
                break;
            case false:
                sp.sprite = sparr[2];
                break;
        }
    }

    private void OnMouseDown()
    {
        switch (music)
        {
            case true:
                audio_.pitch = 0;
                sp.sprite = sparr[3];
                break;
            case false:
                audio_.pitch = 1;
                sp.sprite = sparr[1];
                break;
        }
        music = !music;

        menu.MusicSettings();
    }


}
/*public Sprite[] sprites = new Sprite[2];

    void Start()
    {
        
    }

    void Update()
    {
        if (DataHolder.music) gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
        else gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
    }

    public override void MainFunction()
    {
        menu.MusicSettings();
    }*/
