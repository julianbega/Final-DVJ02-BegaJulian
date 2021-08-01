using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInputs))]
public class PlayerController : MonoBehaviour
{
   // private Rigidbody playerRB;
    private PlayerInputs input;
    [Header("Player speeds")]
    public float speed;
    public float rotationSpeed;

    public float height;
    void Start()
    {
       // playerRB = GetComponent<Rigidbody>();
        input = GetComponent<PlayerInputs>();
    }

    void Update()
    {
        RaycastHit hitInfo;
        if (Physics.Raycast (transform.position, Vector3.down, out hitInfo))
        {
            transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
            transform.position = new Vector3 (this.transform.position.x, hitInfo.point.y + height, this.transform.position.z);
            Debug.Log(hitInfo.transform.tag);
        }

        Vector3 wantedPos = transform.forward * input.ForwardInput * speed * Time.deltaTime;
        this.transform.position += new Vector3(wantedPos.x, 0, wantedPos.z);
    }

    protected virtual void HandleMovement()
    {
       
        
       /* if (input.ForwardInput == 1)
       { 
        Quaternion wantedRotation = transform.rotation * Quaternion.Euler(Vector3.up * (rotationSpeed * input.RotationInput * Time.deltaTime));
        playerRB.MoveRotation(wantedRotation);
       }
        if (input.ForwardInput == -1)
        {
            Quaternion wantedRotation = transform.rotation * Quaternion.Euler(Vector3.down * (rotationSpeed * input.RotationInput * Time.deltaTime));
            playerRB.MoveRotation(wantedRotation);
        }*/
    }
}
