using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Thorns : MonoBehaviour
{
    public int level;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Tea" || coll.gameObject.tag == "Coffee")
            GameObject.FindGameObjectsWithTag("Menu")[0].GetComponent<Pause_menu>().Lose();
    }
}
