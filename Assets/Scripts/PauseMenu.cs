/*******************************************************************************
//File Name :       PauseMenu.cs
//Author :          Brandon Migala
//Creation Date :   March 13, 2025
//
//Brief Description : This document allows the player to access the pause menu.
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Lists the variables to manage the pause menu screen.
    [SerializeField] private GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Activates the PauseMenu.
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void continueButton()
    {
        // loads the next level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Resumes the game.
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
