using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] public TMP_Text playerHealthUIText;
    [SerializeField] public TMP_Text playerScoreUIText;
    [SerializeField] public TMP_Text playerTimeUIText;
    [SerializeField] public PlayerState playerState;
    private float timer = 0;
    private int count = 0;
    private int minuteCount = 0;

    void Start()
    {
        playerHealthUIText.text = "Health: " + playerState.totalHealth.ToString();
        playerScoreUIText.text = "Score: " + playerState.totalCoinValue.ToString();
        playerTimeUIText.text = "Time: 00:00";

    }

    void Update()
    {
        playerHealthUIText.text = "Health: " + playerState.totalHealth.ToString();
        playerScoreUIText.text = "Score " + playerState.totalCoinValue.ToString();
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            playerTimeUIText.text = "Time: " + Time.realtimeSinceStartup;

            // if (count < 10)
            // {
            //     playerTimeUIText.text = "Time: 00:0" + count++;
            //     timer = 0;
            // }

            // if (count >= 10)
            // {
            //     playerTimeUIText.text = "Time 00:" + count++;
            //     timer = 0;
            // }

            // if (count > 59)
            // {
            //     count = 0;
            //     minuteCount++;
            //     playerTimeUIText.text = "Time 0:" + minuteCount + ":" + 
            // }
        }

    }


}
