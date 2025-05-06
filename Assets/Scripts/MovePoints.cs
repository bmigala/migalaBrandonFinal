/**************************************************************************
//File Name :       MovePoints.cs
//Author :          Brandon Migala
//Creation Date :   April 14, 2025
//
//Brief Description : This document causes enemies to move.
**************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoints : MonoBehaviour
{
    // Lists the variables used for the movepoints
    [SerializeField] private GameObject[] movePoints;
    [SerializeField] private float speed;
    private int currentIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, movePoints[currentIndex].transform.position) < 0.1f)
        {
            currentIndex++;

            //if current index gets to the end of the array
            if (currentIndex == movePoints.Length)
            {
                //reset the index value
                currentIndex = 0;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, movePoints[currentIndex].transform.position,
            speed * Time.deltaTime);
    }
}
