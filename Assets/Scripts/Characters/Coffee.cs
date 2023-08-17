using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : CharacterBase
{
    public Tea tea;

    static KeyCode[] keys = new KeyCode[4] { KeyCode.UpArrow, KeyCode.LeftArrow, KeyCode.DownArrow, KeyCode.RightArrow };

    public Coffee()
        : base(keys)
    {
        scaleKoef = 2.1f;
    }

    new void Update()
    {
        base.Update();

        if (transform.position.x - tea.transform.position.x >= predel)
            canGoRight = false;
        else canGoRight = true;

        if (transform.position.x - tea.transform.position.x <= -predel)
            canGoLeft = false;
        else canGoLeft = true;
    }
}