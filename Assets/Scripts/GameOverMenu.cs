using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject player;

    private bool isDead = false;

    void Start()
    {
        // Hide the Game Over panel at the start
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        // Check if the player is dead.
        if (!isDead && IsObjectDead())
        {
            isDead = true;
            // Show the Game Over panel when the player dies.
            ShowGameOverPanel();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Debug.Log("Game Over");
        }
    }

    private bool IsObjectDead()
    {
        // For example, if the player's health reaches zero, return true.
        // Replace this with the appropriate condition for your game.
        return player == null;
    }

    private void ShowGameOverPanel()
    {
        // Enable the Game Over panel.
        gameOverPanel.SetActive(true);
    }

    public void Retry()
    {
        // Reload the current scene when the player clicks the Retry button
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Retrying");
    }

    public void QuitTheGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
