using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public static bool IsSoundOn = true;

    public void SounOn()
    {
        IsSoundOn = true;
        LoadMenuScene();
    }
    public void SounOff()
    {
        IsSoundOn = false;
        LoadMenuScene();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadMenuScene();
        }
    }
    void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu_Scene");
    }
}
