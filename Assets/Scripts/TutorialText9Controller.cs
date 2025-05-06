/************************************************************************************
//File Name :       TutorialText9Controller.cs
//Author :          Brandon Migala
//Creation Date :   May 4, 2025
//
//Brief Description : This document manages the exitText within the Tutorial level.
************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialText9Controller : MonoBehaviour
{
    // Lists the variables used for the exitText
    [SerializeField] private GameObject exitText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            exitText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            exitText.SetActive(false);
        }
    }
}
