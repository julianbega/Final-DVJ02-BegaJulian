using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bomb : MonoBehaviour
{
    private Rigidbody rb;
    private TrailRenderer trail;
    private bool isDead;

    public static Action GivePoints;
    public static Action AddBoxDestroyed;

    void Start()
    {
        isDead = false;
        rb = FindObjectOfType<Rigidbody>();
        rb.AddForce(transform.forward*700);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(this.transform.position.x) > 400 || Mathf.Abs(this.transform.position.y) > 400 || Mathf.Abs(this.transform.position.z) > 400)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Box")
        {
            if (!isDead)
            { 
            Destroy(collision.gameObject);
            AddBoxDestroyed?.Invoke();
            GivePoints?.Invoke();
            isDead = true;
            }
        }
        if (collision.transform.tag == "Target")
        {
            if (!isDead)
            {
                Destroy(collision.gameObject);
                AddBoxDestroyed?.Invoke();
                GivePoints?.Invoke();
                isDead = true;
            }
        }
        Destroy(this.gameObject);
    }
}
