/************************************************************************************
//File Name :       TutorialText7Controller.cs
//Author :          Brandon Migala
//Creation Date :   April 21, 2025
//
//Brief Description : This document manages the timeText within the Tutorial level.
************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialText6Controller1 : MonoBehaviour
{
    // Lists the variables used for the timeText
    [SerializeField] private GameObject timeText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timeText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            timeText.SetActive(false);
        }
    }
}
