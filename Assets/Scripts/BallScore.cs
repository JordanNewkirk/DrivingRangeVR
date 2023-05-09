using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallScore : MonoBehaviour
{
    public UnityEvent<int> Scored;
  

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ScoringArea"))
        {
            Debug.Log("ball score trigger event");
            ScoreArea scoreArea = other.GetComponent<ScoreArea>();
            Scored.Invoke(scoreArea.GetPoints());
        }

    }
}
