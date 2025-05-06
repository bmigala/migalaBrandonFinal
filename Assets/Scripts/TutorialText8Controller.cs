/************************************************************************************
//File Name :       TutorialText8Controller.cs
//Author :          Brandon Migala
//Creation Date :   April 21, 2025
//
//Brief Description : This document manages the finishText within the Tutorial level.
************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialText8Controller : MonoBehaviour
{
    // Lists the variables used for the finishText
    [SerializeField] private GameObject finishText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            finishText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            finishText.SetActive(false);
        }
    }
}
