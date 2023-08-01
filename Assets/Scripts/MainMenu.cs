using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("Playing Game");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadMenu()
    {
        Debug.Log("Loading Menu");
    }

    
    public void QuitTheGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
