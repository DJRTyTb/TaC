using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    public int predel = 13;
    public float speedX;
    public float speed = 0.04f;
    public float vertical_Impulse = 5.1f;
    public bool is_onBox = false;
    public bool is_onButton = false;
    public bool is_vosleDveri = false;
    public bool is_grounded = false;
    public bool is_onPlatform = false;
    public bool is_onHalf = false;
    public bool is_onPlayer = false;
    public bool is_onCockroach = false;
    public bool is_onGround = false;
    public bool is_onBatut = false;
    public bool canGoRight = true;
    public bool canGoLeft = true;
    public float PSpeed;
    public float predSpeed;

    public Animator anim;
    public BoxCollider2D ThisColl;
    public Rigidbody2D rb;
    public SpriteRenderer sprite;

    public float CoordX;
    public float CoordY;
    public float ScaleX;
    public float ScaleY;

    public float scaleKoef;

    public bool forward;
    public bool back;

    KeyCode[] keys = new KeyCode[4];

    public CharacterBase(KeyCode[] GetKeys)
    {
        for (int i = 0; i < keys.Length; i++)
        {
            keys[i] = GetKeys[i];
        }
    }

    void Start()
    {
        speed = speed / 1024 * Screen.width;

        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        ThisColl = GetComponent<BoxCollider2D>();
        ScaleX = transform.localScale.x;
        ScaleY = transform.localScale.y;
    }

    protected void Update()
    {
        if (is_onPlayer)
            speedX += PSpeed;

        CoordX = transform.position.x;
        CoordY = transform.position.y;

        if (GetComponent<BoxCollider2D>().isTrigger)
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
        }

        if (is_onGround || is_onPlatform || is_onHalf || is_onPlayer || is_onBatut || is_onBox || is_onCockroach)
        {
            is_grounded = true;
            if (!Pause_menu.GIP) anim.SetBool("fly", false);
        }
        else
        { 
            is_grounded = false;
            if (!Pause_menu.GIP) anim.SetBool("fly", true);
        }

        if (Input.GetKey(keys[3]) && canGoRight)
        {
            speedX = speed;
            if (!Pause_menu.GIP) sprite.flipX = false;
            forward = true;
        }
        else if (forward)
            forward = false;

        if (Input.GetKey(keys[1]) && canGoLeft)
        {
            speedX = -speed;
            if (!Pause_menu.GIP) sprite.flipX = true;
            back = true;
        }
        else if (back)
            back = false;

        if (Input.GetKeyDown(keys[0]) && (!Pause_menu.GIP) && is_grounded)
        {
            rb.AddForce(new Vector2(0, vertical_Impulse), ForceMode2D.Impulse);
        }
        
        if (!Pause_menu.GIP && ((speedX != 0 && !is_onPlayer) || (is_onPlayer && (Input.GetKey(keys[3]) || Input.GetKey(keys[1]))))) anim.SetBool("walk", true); 
        else if (!Pause_menu.GIP) anim.SetBool("walk", false);

        if (!Pause_menu.GIP)
            if (speedX != 0)
            {
                float sign = speedX / System.Math.Abs(speedX);
                Vector2 center = new Vector2(transform.position.x + (speedX + sprite.bounds.size.x / 2 * sign), transform.position.y);

                if (!isObjectOnY_PushIt(center, sprite.bounds.size.y / scaleKoef, 0.1f, speedX / 2))
                    transform.Translate(speedX, 0, 0);
            }
        predSpeed = speedX;
        speedX = 0;

        if (Input.GetKey(keys[2]) && is_onHalf)
        {
            ThisColl.isTrigger = true;
        }

    }

    public void Push(float x)
    {
        transform.Translate(x, 0, 0);
    }

    private bool HasComponent<T>(GameObject obj) where T : Component
    {
        return obj.GetComponent<T>() != null;
    }

    private bool isObjectOnY_PushIt(Vector2 center, float deltaY, float step, float xPush, bool fromThis = false)
    {
        for (float deltaY_ = 0; deltaY_ <= deltaY; deltaY_ += step)
            if (isObjectHere_PushIt(new Vector2(center.x, center.y + deltaY_), xPush, fromThis) || isObjectHere_PushIt(new Vector2(center.x, center.y - deltaY_), xPush, fromThis))
                return true;
        return false;
    }

    private bool isObjectHere_PushIt(Vector2 position, float xPush, bool fromThis = false)
    {
        Collider2D[] intersecting = Physics2D.OverlapCircleAll(position, 0.01f);

        foreach (Collider2D coll in intersecting)
        {
            if (coll.gameObject.CompareTag("Cockroach") && (coll.gameObject.GetComponent<Cockroach>().TeaHunter && CompareTag("Tea") || !coll.gameObject.GetComponent<Cockroach>().TeaHunter && CompareTag("Coffee"))
                || coll.gameObject.CompareTag("Thorns")
                || coll.gameObject.CompareTag("Mosquitude")) continue;
            if (!coll.isTrigger && (HasComponent<Rigidbody2D>(coll.gameObject) && coll.gameObject.GetComponent<Rigidbody2D>().isKinematic || !HasComponent<Rigidbody2D>(coll.gameObject)))
                return true;
            else if(CompareTag("Coffee") || CompareTag("Tea"))
            {
                if ((coll.gameObject.CompareTag("Coffee") || coll.gameObject.CompareTag("Tea")) && !coll.gameObject.CompareTag(tag) && !is_onPlayer && !coll.gameObject.GetComponent<CharacterBase>().is_onPlayer)
                {
                    if (coll.gameObject.GetComponent<CharacterBase>().predSpeed == -GetComponent<CharacterBase>().predSpeed)
                        return true;
                    else
                    {
                        float sign = speedX / System.Math.Abs(speedX);
                        Vector2 center = new Vector2(coll.gameObject.transform.position.x + (speedX + coll.gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 2 * sign), coll.gameObject.transform.position.y);

                        if (fromThis) return true;

                        if (isObjectOnY_PushIt(center, coll.gameObject.GetComponent<SpriteRenderer>().bounds.size.y / 2, 0.1f, xPush, true))
                            return true;
                        else
                        {
                            coll.gameObject.GetComponent<CharacterBase>().Push(xPush);
                            return true;
                        }
                    }
                }
            }
        }

        return false;
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Half"))
        {
            is_onHalf = false;
            if (ThisColl.isTrigger) ThisColl.isTrigger = false;
        }
    }

}
