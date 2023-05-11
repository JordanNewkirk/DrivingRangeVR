using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolfClub : MonoBehaviour
{
    public float maxSwingSpeed = 10f; // the maximum speed of the swing
    public float minSwingSpeed = 1f; // the minimum speed of the swing
    private Vector3 lastPosition;
    private float currentSpeed;

    private Vector3 startingPosition;

    void Start()
    {
        lastPosition = transform.position;
        startingPosition = transform.position;
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;
        float distance = Vector3.Distance(currentPosition, lastPosition);
        currentSpeed = distance / Time.deltaTime;
        lastPosition = currentPosition;
    }

    public float GetNormalizedSpeed()
    {
        return Mathf.Clamp((currentSpeed - minSwingSpeed) / (maxSwingSpeed - minSwingSpeed), 0f, 1f);
    }

    public void ReturnToStartingPosition()
    {
        this.gameObject.transform.position = startingPosition;
    }
}
