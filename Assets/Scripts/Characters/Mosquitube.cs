using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mosquitube : MonoBehaviour
{
    private SpriteRenderer sp;
    private Rigidbody2D rb;
    private bool vpravo = true;
    public string level;
    private float speedM = 0.03f;
    private float speedX = 0, speedY = 0;// СКОРОСТЬ ПО ОСЯМ X И Y
    public bool GoUp;
    public float time = 5; 
    private float ptime = 0;

    private void Start()
    {
        if (GoUp) speedY = speedM;
        else speedX = speedM;
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (ptime >= time)
        {
            ptime = 0;
            vpravo = !vpravo;
        }

        if (!Pause_menu.GIP)
        {
            switch (vpravo)
            {
                case true:
                    ptime += Time.deltaTime;
                    sp.flipX = true;
                    transform.Translate(speedX, speedY, 0);
                    break;
                case false:
                    ptime += Time.deltaTime;
                    sp.flipX = false;
                    transform.Translate(-speedX, -speedY, 0);
                    break;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Coffee" || coll.gameObject.tag == "Tea")
            GameObject.FindGameObjectsWithTag("Menu")[0].GetComponent<Pause_menu>().Lose();
    }
}
