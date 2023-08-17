using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public bool isTouchingLeftBorder = false;
    public bool isTouchingRightBorder = false;

    private List<Collider2D> touchedBorders = new List<Collider2D>();

    void Start()
    {
        
    }

    void Update()
    {
        /*foreach (Collider2D coll in touchedBorders)
        {
            if (coll.gameObject.CompareTag("OutLeft"))
            {
                isTouchingLeftBorder = true;
            }
            if (coll.gameObject.CompareTag("OutRight"))
            {
                isTouchingRightBorder = true;
            }
            Debug.Log(coll.name);
        }*/
    }

    public List<Collider2D> getTouchedBorders()
    {
        return touchedBorders;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("OutLeft"))
        {
            isTouchingLeftBorder = true;
        }
        if (coll.gameObject.CompareTag("OutRight"))
        {
            isTouchingRightBorder = true;
        }
        touchedBorders.Add(coll);
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("OutLeft"))
        {
            isTouchingLeftBorder = true;
        }
        if (coll.gameObject.CompareTag("OutRight"))
        {
            isTouchingRightBorder = true;
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("OutLeft"))
        {
            isTouchingLeftBorder = false;
        }
        if (coll.gameObject.CompareTag("OutRight"))
        {
            isTouchingRightBorder = false;
        }
        touchedBorders.Remove(coll);
    }
}
