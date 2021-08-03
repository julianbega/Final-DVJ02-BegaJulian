using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerManager : MonoBehaviour
{
    
    private float score;
    private float boxesDestroyed;
    private float distanceTraveled;
    public int pointsPerEnemyDestroyed;

    void Start()
    {
        Bomb.GivePoints += UpdateScore;
        Bomb.AddBoxDestroyed += UpdateBoxesDestroyed;
    }
    private void OnDisable()
    {
        Bomb.GivePoints -= UpdateScore;
        Bomb.AddBoxDestroyed -= UpdateBoxesDestroyed;
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
    public void UpdateBoxesDestroyed()
    {
        boxesDestroyed++;
    }
    public void UpdateScore()
    {
        score += pointsPerEnemyDestroyed;
    }
    public void SetDistanceTraveled(float distance)
    {
        distanceTraveled = distance;
    }

}
