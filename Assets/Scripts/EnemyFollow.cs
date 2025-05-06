/************************************************************************************
//File Name :       EnemyFollow.cs
//Author :          Brandon Migala
//Creation Date :   April 17, 2025
//
//Brief Description : This document causes enemies to follow the player within range.
************************************************************************************/
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private float speed;
    public GameObject Player;

    private void OnCollisionEnter(Collision Enemy)
    {
        if (Enemy.gameObject.CompareTag("Player"))
        {
            Enemy.gameObject.GetComponent<PlayerController>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(new Vector3 (Player.transform.position.x, transform.position.y, 
            Player.transform.position.z));
        float distance = Vector3.Distance(transform.position, Player.transform.position);
        if (distance < 7)
        {
            Vector3 Movement = Vector3.MoveTowards(transform.position, Player.transform.position, Time.deltaTime
                * speed);
            transform.position = new Vector3(Movement.x, transform.position.y, Movement.z);
        }
    }
}
