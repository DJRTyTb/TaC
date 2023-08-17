using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batut : MonoBehaviour
{
    public Animator anim;
    private float batut_impulse = 2.5f;
    public Tea tea;
    public Coffee coffee;
    public Box box;

    void Start()
    {
        tea = GameObject.FindGameObjectsWithTag("Tea")[0].GetComponent<Tea>();
        coffee = GameObject.FindGameObjectsWithTag("Coffee")[0].GetComponent<Coffee>();
        anim = GetComponentInParent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        switch (coll.gameObject.tag)
        {
            case "DoT":
                anim.SetTrigger("jump");
                tea.rb.velocity = new Vector2(tea.rb.velocity.x, 0);
                tea.rb.AddForce(new Vector2(0, tea.vertical_Impulse + batut_impulse), ForceMode2D.Impulse);
                break;
            case "DoC":
                anim.SetTrigger("jump");
                coffee.rb.velocity = new Vector2(coffee.rb.velocity.x, 0);
                coffee.rb.AddForce(new Vector2(0, coffee.vertical_Impulse + batut_impulse), ForceMode2D.Impulse);
                break;
            case "Box":
                anim.SetTrigger("jump");
                box.rb.velocity = new Vector2(box.rb.velocity.x, 0);
                box.rb.AddForce(new Vector2(0, batut_impulse + 5), ForceMode2D.Impulse);
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        switch (coll.gameObject.tag)
        {
            case "DoT":
                anim.SetTrigger("jump");
                tea.rb.velocity = new Vector2(tea.rb.velocity.x, 0);
                tea.rb.AddForce(new Vector2(0, tea.vertical_Impulse + batut_impulse), ForceMode2D.Impulse);
                break;
            case "DoC":
                anim.SetTrigger("jump");
                coffee.rb.velocity = new Vector2(coffee.rb.velocity.x, 0);
                coffee.rb.AddForce(new Vector2(0, coffee.vertical_Impulse + batut_impulse), ForceMode2D.Impulse);
                break;
            case "Box":
                anim.SetTrigger("jump");
                box.rb.velocity = new Vector2(box.rb.velocity.x, 0);
                box.rb.AddForce(new Vector2(0, batut_impulse + 5), ForceMode2D.Impulse);
                break;
        }
    }
}
