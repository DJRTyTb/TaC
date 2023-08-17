using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButtonMain : ButtonsMain
{
    public Sprite[] sparr;// 0 N, 1 A
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
        Application.Quit();
    }
}
