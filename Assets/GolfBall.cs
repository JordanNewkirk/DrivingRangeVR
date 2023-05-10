using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GolfBall : MonoBehaviour
{
    public ScoreManager scoreManager;

    public float maxHitForce = 10f; // the maximum force to apply to the ball
    public float minHitForce = 1f; // the minimum force to apply to the ball
    public float maxDistance = 500f; // the maximum distance the ball can travel
    private Rigidbody rb;
    private float hitForce;
    private TrailRenderer trailRenderer;
    public float respawnTime = 1.0f;
    //public float removeTime = 5.0f;
    public GameObject ballPrefab;
    public Transform ballSpawn;
    public AudioSource scoringSound;
    public AudioSource ballHitSound;

    private bool ballDestroyed = false;
    private bool scored = false;
  

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        trailRenderer = GetComponent<TrailRenderer>();
        trailRenderer.enabled = false; // disable the trail renderer by default
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GolfClub"))
        {
            GolfClub golfClub = collision.gameObject.GetComponent<GolfClub>();
            float swingSpeed = golfClub.GetNormalizedSpeed();
            hitForce = Mathf.Lerp(minHitForce, maxHitForce, swingSpeed);
            Vector3 hitDirection = collision.contacts[0].point - transform.position;

            // get the direction of the club
            Vector3 clubDirection = golfClub.transform.forward;

            // project the hitDirection onto the plane perpendicular to the clubDirection
            Vector3 planeNormal = Vector3.Cross(clubDirection, Vector3.up);
            hitDirection = Vector3.ProjectOnPlane(hitDirection, planeNormal);

            // add a force in the modified hitDirection
            rb.AddForce(hitDirection.normalized * hitForce, ForceMode.Impulse);
            trailRenderer.enabled = true; // enable the trail renderer when the ball is hit
            ballDestroyed = true;
            ballHitSound.Play();
        }

        if (collision.gameObject.CompareTag("Ground"))
        {
            if (!ballDestroyed && !scored)
            {
                scoreManager.addToScore(scoreManager.groundScore);
                scored = true;
                StartCoroutine(RespawnBall());
            }
            ballDestroyed = false;
        }
        else if (collision.gameObject.CompareTag("BlueScore"))
        {
            if (!ballDestroyed && !scored)
            {
                scoreManager.addToScore(scoreManager.blueScore);
                scored = true;
                StartCoroutine(RespawnBall());
            }
            ballDestroyed = false;
        }
        else if (collision.gameObject.CompareTag("YellowScore"))
        {
            if (!ballDestroyed && !scored)
            {
                scoringSound.Play();
                scoreManager.addToScore(scoreManager.yellowScore);
                scored = true;
                StartCoroutine(RespawnBall());
            }
            ballDestroyed = false;
        }
        else if (collision.gameObject.CompareTag("RedScore"))
        {
            if (!ballDestroyed && !scored)
            {
                scoreManager.addToScore(scoreManager.redScore);
                scored = true;
                StartCoroutine(RespawnBall());
            }
            ballDestroyed = false;
        }
        else if (collision.gameObject.CompareTag("PurpleScore"))
        {
            if (!ballDestroyed && !scored)
            {
                scoreManager.addToScore(scoreManager.purpleScore);
                scored = true;
                StartCoroutine(RespawnBall());
            }
            ballDestroyed = false;
        }

    }

    IEnumerator RespawnBall()
    {
        if (scoreManager.ballsRemaining >= 1)
        {
            Instantiate(ballPrefab, ballSpawn.position, Quaternion.identity);
            scoreManager.ballDestroyed();
        }

        yield return new WaitForSeconds(respawnTime);

        Destroy(gameObject);

        if (scoreManager.ballsRemaining == 0)
        {
            // Display game over message or do other end game actions
            SceneManager.LoadScene("RetryMenu");
        }
    }



}
