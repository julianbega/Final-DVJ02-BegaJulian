using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovment : MonoBehaviour
{
    public float speed;
    public float duration;
    private float timeToMove;
    [Header("use vec3 like left or right (1,0,0 or -1,0,0)")]
    public Vector3 direction;
    
    private void Start()
    {
        timeToMove = 0;
    }
    // Update is called once per frame
    void Update()
    {
        timeToMove += Time.deltaTime;
        if(timeToMove >= duration)
        {
            direction = direction * -1;
            timeToMove = 0;
        }
        transform.Translate(direction * Time.deltaTime * speed);
    } 
}
