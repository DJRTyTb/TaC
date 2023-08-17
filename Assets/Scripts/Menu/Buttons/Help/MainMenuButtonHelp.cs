using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtonHelp : ButtonsHelp
{
    public Sprite[] sparr;
    private SpriteRenderer sp;

    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

    }

    private void OnMouseEnter()
    {
        sp.sprite = sparr[1];
    }

    private void OnMouseExit()
    {
        sp.sprite = sparr[0];
    }

    public override void MainFunction()
    {
        menu.MainMenu();
    }
}
