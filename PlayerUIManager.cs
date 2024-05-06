using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    [SerializeField] public TMP_Text playerHealthUI;
    [SerializeField] public TMP_Text playerScoreUI;
    [SerializeField] public TMP_Text playerTimeUI;
    [SerializeField] public TMP_Text playerInvincibilityUI;
    [SerializeField] public TMP_Text gameOverUI;
    [SerializeField] public PlayerState playerState;
    private float invincibilityTimeRemaining = 10f;
    private float timer = 0f;
    private float totalTime = 0f;

    void Start()
    {
        playerHealthUI.text = "Health: " + playerState.totalHealth.ToString();
        playerScoreUI.text = "Score: " + playerState.totalCoinValue.ToString();
        playerTimeUI.text = "Time: 00:00";
        playerInvincibilityUI.text = "";
        gameOverUI.text = "";
    }

    void Update()
    {
        playerHealthUI.text = "Health: " + playerState.totalHealth.ToString();
        playerScoreUI.text = "Score " + playerState.totalCoinValue.ToString();
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            playerTimeUI.text = "Time: " + Time.realtimeSinceStartup.ToString("F1") + "s";
        }

        if (playerState.isInvincible)
        {
            if (invincibilityTimeRemaining > 0 && playerState.isInvincible)
            {
                Debug.Log("[TIMER] Invincibility Seconds Remaining: " + invincibilityTimeRemaining);
                Debug.Log("[TIMER] Player Invincibility Bool: " + playerState.isInvincible);
                playerInvincibilityUI.text = "Invincibility " + invincibilityTimeRemaining.ToString("F0") + "s";
                invincibilityTimeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("[TIMER] Invincibility time has run out!");
                Debug.Log("[TIMER] Player Invincibility State: " + playerState.isInvincible);
                invincibilityTimeRemaining = 10f;
                playerInvincibilityUI.text = "";
            }
        
        }

        if (playerState.isDead)
        {
            gameOverUI.text = "GAME OVER";
        }
    }

    


}
