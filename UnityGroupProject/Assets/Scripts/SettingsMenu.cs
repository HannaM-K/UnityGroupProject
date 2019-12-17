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
    }
    public void SounOff()
    {
        IsSoundOn = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu_Scene");
        }
    }
}
