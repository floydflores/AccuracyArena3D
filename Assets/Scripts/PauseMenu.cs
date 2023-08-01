using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Customize this to your preferred pause input
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Debug.Log("Game is Resumed");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        Debug.Log("Game is Paused");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading Menu"); // Implement the logic to restart the game, if needed.
    }

    public void SkipGame()
    {
        Debug.Log("Skipping Part");
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LeaveGame()
    {
        Debug.Log("Leaving Game");
         // Implement the logic to quit the game, if needed.
    }

    public void QuitTheGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}