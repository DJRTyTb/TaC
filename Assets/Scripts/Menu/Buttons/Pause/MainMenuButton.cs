using UnityEngine;

public class MainMenuButton : ButtonsPause
{
    public Sprite[] sparr;// 0 - N, 1 - A 
    private SpriteRenderer sp;

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
        menu.LoadMenu();
    }
}
