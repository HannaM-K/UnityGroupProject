using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Main_Scene");
    }
    public void LoadSettings()
    {
        SceneManager.LoadScene("Settings_Scene");
    }
    public void QuitGame()
    {
        Debug.Log("Wyjście z gry.");
        Application.Quit();
    }
}
