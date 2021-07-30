using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInputs))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    private PlayerInputs input;
    [Header("Player speeds")]
    public float speed;
    public float rotationSpeed;

    public float height;
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        input = GetComponent<PlayerInputs>();
    }

    void Update()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast (transform.position, -transform.up, out hitInfo))
        {
            transform.up = hitInfo.normal;
            transform.position = hitInfo.point + hitInfo.normal * height;
        }
    }
    void FixedUpdate()
    {
        HandleMovement();
    }

    protected virtual void HandleMovement()
    {
        Vector3 wantedPos = transform.position + (transform.forward * input.ForwardInput * speed * Time.deltaTime);
        playerRB.MovePosition(wantedPos);
        
        if (input.ForwardInput == 1)
       { 
        Quaternion wantedRotation = transform.rotation * Quaternion.Euler(Vector3.up * (rotationSpeed * input.RotationInput * Time.deltaTime));
        playerRB.MoveRotation(wantedRotation);
       }
        if (input.ForwardInput == -1)
        {
            Quaternion wantedRotation = transform.rotation * Quaternion.Euler(Vector3.down * (rotationSpeed * input.RotationInput * Time.deltaTime));
            playerRB.MoveRotation(wantedRotation);
        }
    }
}
