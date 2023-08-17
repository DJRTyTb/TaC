using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;
using System.IO;

public class Pause_menu : MonoBehaviour
{
    private bool won = false;
    private bool losed = false;
    private int deltatime = 2;
    public static bool GIP = false;
    public GameObject pause_menu_UI;
    public GameObject win;
    public GameObject lose;
    public int timeToLeave = 50;
    public int timeToReload = 50;
    public int lvl;
    public static string path;
    public Tea tea;
    public Coffee coffee;
    public Door door;

    void Start()
    {
        tea = GameObject.FindGameObjectsWithTag("Tea")[0].GetComponent<Tea>();
        coffee = GameObject.FindGameObjectsWithTag("Coffee")[0].GetComponent<Coffee>();
        door = GameObject.FindGameObjectsWithTag("Door")[0].GetComponent<Door>();

        pause_menu_UI = GameObject.FindGameObjectsWithTag("MenuObj")[0];
        win = GameObject.FindGameObjectsWithTag("Win")[0];
        lose = GameObject.FindGameObjectsWithTag("Lose")[0];

        lvl = int.Parse(SceneManager.GetActiveScene().name.Substring(5));
        path = DataHolder.path + @"\passed\" + lvl + ".txt";

        Resume();
        win.SetActive(false);
        lose.SetActive(false);
        pause_menu_UI.SetActive(false);
    }

	void Update() 
    {
        int now = DateTime.Now.Second;

        if (now == timeToLeave) LoadMenu();
        if (now == timeToReload) Reload();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GIP = !GIP;
            if (!GIP) Resume();
            else Pause();
        }

        if (tea.is_vosleDveri && coffee.is_vosleDveri && !won)
        {
            Win();
            won = true;
        }
	}

    public void Resume()
    {
        if (losed || won) return;

        pause_menu_UI.SetActive(false);
        Time.timeScale = 1f;
        GIP = false;
    }

    void Pause()
    {
        if (losed || won) return;

        pause_menu_UI.SetActive(true);
        Time.timeScale = 0f;
        GIP = true;
    }

    public void Lose()
    {
        if (losed) return;
        losed = true;

        lose.SetActive(true);
        timeToReload = DateTime.Now.Second;
        if (timeToReload > 59 - deltatime) timeToReload -= 60;
        timeToReload += deltatime;
        Time.timeScale = 0f;
        GIP = true;
    }

    public void Win()
    {
        Directory.CreateDirectory(DataHolder.path + @"\passed");

        if (File.Exists(path))
            File.WriteAllText(path, "true");
        else
        {
            File.Create(path);
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine("true");
            }
        }

        win.SetActive(true);
        timeToLeave = DateTime.Now.Second;
        if (timeToLeave > 59 - deltatime) timeToLeave -= 60;
        timeToLeave += deltatime;
        Time.timeScale = 0f;
        GIP = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Reload()
    {
        losed = false;
        SceneManager.LoadScene("Level" + lvl);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
