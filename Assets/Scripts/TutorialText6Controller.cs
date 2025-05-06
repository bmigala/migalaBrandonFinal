/************************************************************************************
//File Name :       TutorialText6Controller.cs
//Author :          Brandon Migala
//Creation Date :   April 21, 2025
//
//Brief Description : This document manages the icicleText within the Tutorial level.
************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialText6Controller : MonoBehaviour
{
    // Lists the variables used for the icicleText
    [SerializeField] private GameObject icicleText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            icicleText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            icicleText.SetActive(false);
        }
    }
}
