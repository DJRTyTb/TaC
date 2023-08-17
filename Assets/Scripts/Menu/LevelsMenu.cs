using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsMenu : MonoBehaviour
{
    public GameObject[] levels;
    public Sprite[] sprites;
    public AudioSource Audio;
    private static string[] paths;

    void Start()
    {
        Directory.CreateDirectory(DataHolder.path + @"\passed");

        string path = DataHolder.path;

        int pathLength = levels.Length;

        string pathDirectory = path + @"\passed";

        paths = new string[pathLength];
        for (int i = 0; i < pathLength; i++)
            paths[i] = pathDirectory + @"\" + (i + 1) + ".txt";

        for (int i = 0; i < pathLength; ++i)
            if (!File.Exists(paths[i])) File.Create(paths[i]);

        GameObject originalLevel = levels[0];
        originalLevel.GetComponent<SpriteRenderer>().sprite = sprites[0];

        for (int i = 1; i < levels.Length; i++)
        {
            GameObject obj = Instantiate(originalLevel, new Vector3(originalLevel.transform.position.x + i % 3 * 3.8F, originalLevel.transform.position.y - i / 3 * 2.5F, originalLevel.transform.position.z), new Quaternion(0, 0, 0, 0));
            obj.GetComponent<SpriteRenderer>().sprite = (!IsTextFileEmpty(paths[i - 1]) && File.ReadAllText(paths[i - 1]) == "true") ? sprites[i * 2 - 1] : sprites[i * 2];
            (obj.GetComponent<ChoseLevelButton>() as ChoseLevelButton).lvl = i + 1;
            levels[i] = obj;
        }
    }

    public static bool IsTextFileEmpty(string fileName)
    {
        var info = new FileInfo(fileName);
        if (info.Length == 0)
            return true;

        if (info.Length < 6)
        {
            var content = File.ReadAllText(fileName);
            return content.Length == 0;
        }
        return false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) MainMenu();
    }

    public void LoadLevel(int lvl)
    {
        DataHolder.timeAudio_MainAndLevels = 0;

        if (lvl == 1)
            SceneManager.LoadScene("Level" + lvl);
        else if(File.ReadAllText(DataHolder.path + @"\passed\" + (lvl - 1) + ".txt") == "true")
            SceneManager.LoadScene("Level" + lvl);
    }

    public void MainMenu()
    {
        DataHolder.timeAudio_MainAndLevels = Audio.timeSamples;
        SceneManager.LoadScene("MainMenu");
    }
}
