/**************************************************************************
//File Name :       QuitButton.cs
//Author :          Brandon Migala
//Creation Date :   April 20, 2025
//
//Brief Description : This document allows the player to quit the game.
**************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    // Lists the variables to manage the quit button.
    [SerializeField] private Button quitButton;

    public void Quit()
    {
        Application.Quit();
    }
}
