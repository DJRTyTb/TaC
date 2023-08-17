using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tea : CharacterBase
{
    public Coffee coffee;

    static KeyCode[] keys = new KeyCode[4] {KeyCode.W, KeyCode.A, KeyCode.S, KeyCode.D};

    public Tea()
        : base(keys)
    {
        scaleKoef = 3.6f;
    }

    new void Update()
    {
        base.Update();

        if (transform.position.x - coffee.transform.position.x >= predel)
            canGoRight = false;
        else canGoRight = true;

        if (transform.position.x - coffee.transform.position.x <= -predel)
            canGoLeft = false;
        else canGoLeft = true;
    }

    /*int flyT = 0;
    float speedXT;
    float speedT = 0.1f;
    float vertical_ImpulseT = 520f;
    Rigidbody2D rbT;
    SpriteRenderer sprtT;

    

    void Start () 
    {
        rbT = GetComponent<Rigidbody2D>();
        sprtT = GetComponent<SpriteRenderer>();
	}
	void Update () 
    {
        if(Input.GetKey(KeyCode.D))
        {
            speedXT = speedT;
            StoronaTea();
        }

        if (Input.GetKey(KeyCode.A))
        {
            speedXT = -speedT;
            StoronaTea();
        }

        if (Input.GetKeyDown(KeyCode.W) && (!Pause_menu.GIP))
        {
            rbT.AddForce(new Vector2(0, vertical_ImpulseT), ForceMode2D.Impulse);
        }

        if (!Pause_menu.GIP) transform.Translate(speedXT, 0, 0);
        speedXT = 0;
    }

    void OnCollisionExit(Collider2D collider)
    {
        while (flyT <= 2)
        {
            if ((collider.tag == "Ground") && (Input.GetKeyDown(KeyCode.W)))
            {
                flyT++;
            }
            flyT = 0;
        }
    }

    void StoronaTea()
    {

    }*/
}
