using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    /*public int startingBalls = 10;
    public GameObject ballPrefab;
    public Transform ballSpawn;*/

    public int maxBalls = 10; // the maximum number of balls that can be spawned
    public int groundScore = 5; // the score for hitting the ground
    public int blueScore = 50;
    public int yellowScore = 25;
    public int redScore = 75;
    public int purpleScore = 100;// the score for hitting the scoring area
    private int totalScore; // the total score so far

    public TMP_Text scoreText;
    public TMP_Text ballsRemainingText;

    //private int score = 0;
    public int ballsRemaining = 10;
    //private BallScore ballScore;

    /*private void Start()
    {
        ballsRemaining = startingBalls;
        UpdateScore(0);

        ballScore = ballPrefab.GetComponent<BallScore>();
        ballScore.Scored.AddListener(UpdateScore);
    }

    void UpdateScore(int points)
    {
        Debug.Log("Inside update score");
        score += points;
        ballsRemaining--;
        UpdateUI();

        if (ballsRemaining > 0)
        {
            Debug.Log("Inside Spawnball");
            //SpawnBall();
        }
    }


    void SpawnBall()
    {
        Debug.Log("ball should spawn");
        Instantiate(ballPrefab, ballSpawn.position, Quaternion.identity);
    }

    void UpdateUI()
    {
        Debug.Log("should be updating score");
        scoreText.text = "Score: " + score;
        ballsRemainingText.text = "Balls Remaining: " + ballsRemaining;
    }*/

    void Start()
    {
        ballsRemaining--;
        totalScore = 0;
        updateUI();
    }

    public void ballDestroyed()
    {
        ballsRemaining--;
        updateUI();

    }

    void updateUI()
    {
        scoreText.text = "Total Score: " + totalScore.ToString();
        ballsRemainingText.text = "Balls Remaining: " + (ballsRemaining).ToString() + " / " + maxBalls.ToString();
    }

    public void addToScore(int points)
    {
        totalScore += points;
        updateUI();
    }

}
