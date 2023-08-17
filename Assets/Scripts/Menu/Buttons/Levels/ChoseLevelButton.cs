using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoseLevelButton : ButtonsLevels
{
    public int lvl;

    void Start()
    {

    }

    void Update()
    {

    }

    public override void MainFunction()
    {
        menu.LoadLevel(lvl);
    }
}
