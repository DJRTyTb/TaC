using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Tea tea;
    public Coffee coffee;
    public GameObject[] boxes;
    public Sprite act, neact;
    private SpriteRenderer sp;
    private const bool F = false;
    private const bool T = true;

    public bool active;

    void Start()
    {
        boxes = GameObject.FindGameObjectsWithTag("Box");

        tea = GameObject.FindGameObjectsWithTag("Tea")[0].GetComponent<Tea>();
        coffee = GameObject.FindGameObjectsWithTag("Coffee")[0].GetComponent<Coffee>();
        sp = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        switch(coll.gameObject.tag)
        {
            case "Tea":
                tea.is_onButton = true;
                break;
            case "Coffee":
                coffee.is_onButton = true;
                break;
            case "Box":
                coll.gameObject.GetComponent<Box>().is_onButton = true;
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        active = T;
        sp.sprite = act;
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        switch (coll.gameObject.tag)
        {
            case "Tea":
                tea.is_onButton = false;
                break;
            case "Coffee":
                coffee.is_onButton = false;
                break;
            case "Box":
                coll.gameObject.GetComponent<Box>().is_onButton = false;
                break;
        }
        if (!tea.is_onButton && !coffee.is_onButton && !IsAnyBoxOnButton())
        {
            active = F;
            sp.sprite = neact;
        }
    }

    private bool IsAnyBoxOnButton()
    {
        foreach (var box in boxes)
            if (box.GetComponent<Box>().is_onButton)
                return true;

        return false;
    }
}
