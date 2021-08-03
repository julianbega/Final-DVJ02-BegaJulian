using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private float score;
    private float boxesDestroyed;
    private float distanceTraveled;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    void FixedUpdate()
    {

    }

    public float GetScore()
    {
        return score;
    }
    public float GetBoxesDestroyed()
    {
        return boxesDestroyed;
    }
    public float GetDistanceTraveled()
    {
        return distanceTraveled;
    }
}
