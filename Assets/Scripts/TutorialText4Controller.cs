/************************************************************************************
//File Name :       TutorialText4Controller.cs
//Author :          Brandon Migala
//Creation Date :   April 21, 2025
//
//Brief Description : This document manages the battleText within the Tutorial level.
************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialText4Controller : MonoBehaviour
{
    // Lists the variables used for the battleText
    [SerializeField] private GameObject battleText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            battleText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            battleText.SetActive(false);
        }
    }
}
