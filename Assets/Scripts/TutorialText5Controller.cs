/************************************************************************************
//File Name :       TutorialText5Controller.cs
//Author :          Brandon Migala
//Creation Date :   April 21, 2025
//
//Brief Description : This document manages the iceText within the Tutorial level.
************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialText5Controller : MonoBehaviour
{
    // Lists the variables used for the iceText
    [SerializeField] private GameObject iceText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            iceText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            iceText.SetActive(false);
        }
    }
}
