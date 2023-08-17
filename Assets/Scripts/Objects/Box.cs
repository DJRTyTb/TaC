using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool is_onButton = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Button")
            is_onButton = true;
    }

    private void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Button")
            is_onButton = false;
    }
}
