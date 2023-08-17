using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Tea tea;
    public Coffee coffee;
    public Background background;

    private float startY;

    private float preX = 0;

    void Start()
    {
        tea = GameObject.FindGameObjectsWithTag("Tea")[0].GetComponent<Tea>();
        coffee = GameObject.FindGameObjectsWithTag("Coffee")[0].GetComponent<Coffee>();
        background = GameObject.FindGameObjectsWithTag("Background")[0].GetComponent<Background>();
        startY = transform.position.y;
    }

    void Update()
    {
        float x, y, z = transform.position.z, teaX, teaY, coffeeX, coffeeY;

        teaX = tea.transform.position.x;
        teaY = tea.transform.position.y;
        coffeeX = coffee.transform.position.x;
        coffeeY = coffee.transform.position.y;

        x = (teaX + coffeeX) / 2;
        if (background.isTouchingLeftBorder)
        {
            if(preX < x)
                background.isTouchingLeftBorder = false;
            else
                return;
        }
        if (background.isTouchingRightBorder)
        {
            if (preX > x)
                background.isTouchingRightBorder = false;
            else
                return;
        }
        preX = x;

        y = (teaY + coffeeY) / 2;
        if (y < startY) y = startY;

        transform.SetPositionAndRotation(new Vector3(x, y, z), new Quaternion(0, 0, 0, 0));
    }
}
