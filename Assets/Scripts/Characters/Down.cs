using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down : MonoBehaviour
{
    private const bool T = true;
    private const bool F = false;

    public CharacterBase player;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private bool ContainsTag(Collider2D[] colls, string tag)
    {
        foreach (Collider2D coll in colls)
            if (coll.gameObject.CompareTag(tag))
                return true;

        return false;
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        switch (coll.gameObject.tag)
        {
            case "Ground":
                player.is_onGround = F;
                break;
            case "Platform":
                player.is_onPlatform = F;
                break;
            case "Batut":
                player.is_onBatut = F;
                break;
            case "Box":
                player.is_onBox = F;
                break;
            case "Half":
                if (ContainsTag(Physics2D.OverlapCircleAll(new Vector2(player.transform.position.x, player.transform.position.y), 0.1f), "Half")) break;
                player.is_onHalf = F;
                if (player.ThisColl.isTrigger) player.ThisColl.isTrigger = F;
                break;
            case "Cockroach":
                player.is_onCockroach = F;
                break;
            case "Tea":
            case "Coffee":
                player.is_onPlayer = F;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        switch (coll.gameObject.tag)
        {
            case "Ground":
                player.is_onGround = T;
                break;
            case "Platform":
                player.is_onPlatform = T;
                break;
            case "Batut":
                player.is_onBatut = T;
                break;
            case "Box":
                player.is_onBox = T;
                break;
            case "Half":
                player.is_onHalf = T;
                break;
            case "Cockroach":
                player.is_onCockroach = T;
                break;
        }
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        switch (coll.gameObject.tag)
        {
            case "Tea":
                player.is_onPlayer = T;
                Tea tea = coll.gameObject.GetComponent<Tea>() as Tea;
                if (tea.forward)
                    player.PSpeed = tea.speed;
                else if (tea.back)
                    player.PSpeed = -tea.speed;
                else
                    player.PSpeed = 0;
                break;
            case "Coffee":
                player.is_onPlayer = T;
                Coffee coffee = coll.gameObject.GetComponent<Coffee>() as Coffee;
                if (coffee.forward)
                    player.PSpeed = coffee.speed;
                else if (coffee.back)
                    player.PSpeed = -coffee.speed;
                else
                    player.PSpeed = 0;
                break;
        }
    }
}
