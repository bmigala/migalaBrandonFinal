/**********************************************************************
//File Name :       CoinController.cs
//Author :          Brandon Migala
//Creation Date :   March 2, 2025
//
//Brief Description : This document allows the player to collect coins.
**********************************************************************/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    // Lists the variables used for coin collecting.
    [SerializeField] private TMP_Text scoreText;
    private int score;
    public GameObject player;
    public int recentCoins;
    public AudioSource CoinSound;

    public int Score { get => score; set => score = value; }

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        Score = 0;
        recentCoins = 0;
        UpdateScoreText();
    }

    /// <summary>
    /// Updates the score with each coin collected.
    /// </summary>
    private void OnTriggerEnter(Collider coinIHit)
    {
        if (coinIHit.gameObject.CompareTag("Coin"))
        {
            // update score.
            Score += 1;
            recentCoins++;
            UpdateScoreText();
            Destroy(coinIHit.gameObject);
            CoinSound.Play();
        }
    }

    public void resetCoins()
    {
        Score -= 5;
        UpdateScoreText();
    }

    /// <summary>
    /// Changes the score number.
    /// </summary>
    private void UpdateScoreText()
    {
        scoreText.text = "Coins: " + Score.ToString();
    }
}
