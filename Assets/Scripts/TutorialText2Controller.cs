/**********************************************************************************
//File Name :       TutorialText2Controller.cs
//Author :          Brandon Migala
//Creation Date :   April 20, 2025
//
//Brief Description : This document manages the jumpText within the Tutorial level.
**********************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Lists the variables used for the jumpText
    [SerializeField] private GameObject jumpText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jumpText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jumpText.SetActive(false);
        }
    }
}
