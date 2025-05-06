/**********************************************************************************
//File Name :       TutorialText3Controller.cs
//Author :          Brandon Migala
//Creation Date :   April 21, 2025
//
//Brief Description : This document manages the coinText within the Tutorial level.
**********************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialText3Controller : MonoBehaviour
{
    // Lists the variables used for the coinText
    [SerializeField] private GameObject coinText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coinText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            coinText.SetActive(false);
        }
    }
}
