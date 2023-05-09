using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreArea : MonoBehaviour
{
    public int points;

    public int GetPoints()
    {
        Debug.Log("should be getting points ScoreArea script");
        return points;
    }
}
