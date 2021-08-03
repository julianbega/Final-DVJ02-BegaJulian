using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Rigidbody rb;
    void Start()
    {
        rb = FindObjectOfType<Rigidbody>();
        rb.AddForce(transform.forward*1000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
