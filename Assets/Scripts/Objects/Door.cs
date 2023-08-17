using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public Sprite[] sprites = new Sprite[2];
    public GameObject[] buttons;
    public bool active;
    public Pause_menu menu;
    public Tea tea;
    public Coffee coffee;

    void Start()
    {
        tea = GameObject.FindGameObjectsWithTag("Tea")[0].GetComponent<Tea>();
        coffee = GameObject.FindGameObjectsWithTag("Coffee")[0].GetComponent<Coffee>();
        menu = GameObject.FindGameObjectsWithTag("Menu")[0].GetComponent<Pause_menu>();
        buttons = GameObject.FindGameObjectsWithTag("Button");
    }

    void Update()
    {
        active = AllButtonsActive();

        if(active) gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
        else gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
    }

    private bool AllButtonsActive()
    {
        foreach (GameObject button in buttons)
            if (!button.GetComponent<Button>().active) return false;

        return true;
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        switch (coll.gameObject.tag)
        {
            case "Tea":
                if (tea.is_grounded)
                    if (active)
                    {
                        tea.is_vosleDveri = true;
                    }
                break;
            case "Coffee":
                if (coffee.is_grounded)
                    if (active)
                    {
                        coffee.is_vosleDveri = true;
                    }
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Tea":
                tea.is_vosleDveri = false;
                break;
            case "Coffee":
                coffee.is_vosleDveri = false;
                break;
        }
    }
}