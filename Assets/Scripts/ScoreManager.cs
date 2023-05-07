using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int startingBalls = 10;
    public GameObject ballPrefab;
    public Transform ballSpawn;
    public TMP_Text scoreText;
    public TMP_Text ballsRemainingText;

    private int score = 0;
    private int ballsRemaining;
    private BallScore ballScore;

    private void Start()
    {
        ballsRemaining = startingBalls;
        UpdateScore(0);

        ballScore = ballPrefab.GetComponent<BallScore>();
        ballScore.Scored.AddListener(UpdateScore);
    }

    void UpdateScore(int points)
    {
        score += points;
        ballsRemaining--;
        UpdateUI();

        if (ballsRemaining > 0)
        {
            SpawnBall();
        }
    }


    void SpawnBall()
    {
        Instantiate(ballPrefab, ballSpawn.position, Quaternion.identity);
    }

    void UpdateUI()
    {
        scoreText.text = "Score: " + score;
        ballsRemainingText.text = "Balls Remaining: " + ballsRemaining;
    }
}
