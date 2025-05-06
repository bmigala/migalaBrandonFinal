/************************************************************************************
//File Name :       EnemyFollow.cs
//Author :          Brandon Migala
//Creation Date :   April 18, 2025
//
//Brief Description : This document causes the player to stick to certain platforms.
************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    // Lists the variables used for sticky platforms
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //parent the player to the moving platform
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //removes the platform parent
            collision.gameObject.transform.SetParent(null);
        }
    }
}
