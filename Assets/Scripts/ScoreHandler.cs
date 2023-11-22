using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreHandler : MonoBehaviour
{
    [Header("Score Settings")]
    [SerializeField] PlatformBehavior platformBehaviorScript;
    [SerializeField] int playerScore = 0;
    [SerializeField] int highScore = 0;

    [Header("Text Score Settings")]
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] TextMeshProUGUI playerScoreText;

    void Update()
    {
        updateScore();
        updateScoreUI();
    }

    // Continuously update the player score, only update the high score when needed.
    void updateScore()
    {
        playerScore = platformBehaviorScript.score;
        if (playerScore > highScore)
        {
            highScore = playerScore;
        }
    }

    void updateScoreUI()
    {
        highScoreText.text = "High Score: " + highScore.ToString();
        playerScoreText.text = "Current Score: " + playerScore.ToString();
    }
}
