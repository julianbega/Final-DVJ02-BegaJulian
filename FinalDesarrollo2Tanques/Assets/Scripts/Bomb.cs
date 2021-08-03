using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Rigidbody rb;
    private TrailRenderer trail;
    void Start()
    {
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
        Destroy(this.gameObject);
    }
}
