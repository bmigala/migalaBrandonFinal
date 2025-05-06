/***********************************************************************************
//File Name :       TutorialText1Controller.cs
//Author :          Brandon Migala
//Creation Date :   April 20, 2025
//
//Brief Description : This document manages the moveText within the Tutorial level.
***********************************************************************************/
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    // Lists the variables used for the moveText
    [SerializeField] private GameObject startText;

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            startText.SetActive(false);
        }
    }
}

