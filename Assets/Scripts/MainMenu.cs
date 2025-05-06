/*******************************************************************************
//File Name :       MainMenu.cs
//Author :          Brandon Migala
//Creation Date :   March 27, 2025
//
//Brief Description : This document allows the player to navigate the main menu.
*******************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Lists the variable to manage the main menu screen.
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject instructionsMenu;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        mainMenu.SetActive(true);
        instructionsMenu.SetActive(false);
        Time.timeScale = 1.0f;
    }

    /// <summary>
    /// Starts the game.
    /// </summary>
    public void startButton()
    {
        mainMenu.SetActive(false);
        Time.timeScale = 1f;

        SceneManager.LoadScene(1);
    }

    // Backs out of the InstructionsMenu and back into the MainMenu.
    public void BackButton()
    {
        instructionsMenu.SetActive(false);
        mainMenu.SetActive(true);
        Time.timeScale = 1.0f;
    }

    // Activates the InstructionsMenu.
    public void Controls()
    {
        instructionsMenu.SetActive(true);
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
