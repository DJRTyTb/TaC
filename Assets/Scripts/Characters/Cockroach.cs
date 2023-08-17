using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cockroach : MonoBehaviour
{
    private Rigidbody2D tarakan;
    private Animator anim;
    private bool active = false, mogno = true, attac = false;
    public bool TeaHunter;
    public string level;
    private float speed = 0.04f;
    private float time = 0, ptime = 0;
    private float rast = 1.7f, prast = 0;

    void Start()
    {
        anim = GetComponent<Animator>();
        tarakan = GetComponent<Rigidbody2D>();
    }
  
    void FixedUpdate()
    {
        ptime += Time.deltaTime;
        if (active && mogno)
        {
            attac = true;
            if (prast < rast)
            {
                prast += speed;
                transform.Translate(0, speed, 0);
            }
            else
            {
                time += Time.deltaTime;
                //anim.SetBool("attac", true);

                if (time >= 2.5)
                {
                    //anim.SetBool("attac", false);
                    if (prast < 2 * rast)
                    {
                        prast += speed;
                        transform.Translate(0, -speed, 0);
                    }
                    else
                    {
                        prast = 0;
                        active = false;
                        ptime = 0;
                        time = 0;
                        mogno = false;
                        attac = false;
                    }
                }
            }
        }
        else
        {
            if (active)
            {
                if (ptime <= 3) mogno = false;
                else mogno = true;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D coll)
    {
        switch (TeaHunter)
        {
            case true:
                if (attac && (coll.gameObject.tag == "Tea" || coll.gameObject.tag == "DoT"))
                    GameObject.FindGameObjectsWithTag("Menu")[0].GetComponent<Pause_menu>().Lose();
                break;
            case false:
                if (attac && (coll.gameObject.tag == "Coffee" || coll.gameObject.tag == "DoC"))
                    GameObject.FindGameObjectsWithTag("Menu")[0].GetComponent<Pause_menu>().Lose();
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Coffee" || coll.gameObject.tag == "Tea" || coll.gameObject.tag == "DoC" || coll.gameObject.tag == "DoT")
            active = true;
    }
}