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
        if (Physics.Raycast(transform.position, Vector3.down, out hitInfo))
        {
            #region fail rotations
            // transform.Rotate(Quaternion.FromToRotation(Vector3.up, hitInfo.normal).x, input.RotationInput * Time.deltaTime * rotationSpeed, Quaternion.FromToRotation(Vector3.up, hitInfo.normal).z);
            //transform.rotation = Quaternion.FromToRotation(Vector3.up, hitInfo.normal);
            // transform.rotation = new Quaternion (Quaternion.FromToRotation(Vector3.up, hitInfo.normal).x,0,Quaternion.FromToRotation(Vector3.up, hitInfo.normal).z,Quaternion.FromToRotation(Vector3.up, hitInfo.normal).w);
            //transform.Rotate(Quaternion.FromToRotation(Vector3.up, hitInfo.normal).x, input.RotationInput * Time.deltaTime * rotationSpeed, Quaternion.FromToRotation(Vector3.up, hitInfo.normal).w);
            // Vector3 aux = Vector3.Slerp(hitInfo.normal, hitInfo.normal, Time.deltaTime * 10f);
            //transform.rotation = new Quaternion(aux.x, aux.y, aux.z, transform.rotation.w);
            // transform.rotation = Quaternion.FromToRotation(transform.up, hitInfo.normal) * transform.rotation;
            #endregion
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.FromToRotation(transform.up, hitInfo.normal) * transform.rotation, 0.15f);
            transform.position = new Vector3(this.transform.position.x, hitInfo.point.y + height, this.transform.position.z);
        }


        Vector3 wantedPos = transform.forward * input.ForwardInput * speed * Time.deltaTime;
        this.transform.position += new Vector3(wantedPos.x, 0, wantedPos.z);

        transform.Rotate(0.0f, input.RotationInput* Time.deltaTime * rotationSpeed, 0.0f);
        // transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(transform.rotation.x, input.RotationInput * Time.deltaTime * rotationSpeed, transform.rotation.z, transform.rotation.w), 1);

    }


}
