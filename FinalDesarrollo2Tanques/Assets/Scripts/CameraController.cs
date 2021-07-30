using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    public Transform lookAtThat;

    [SerializeField] [Range(1, 3.5f)] public float verticalDistance;
    [SerializeField] [Range(2, 8)] public float horizontalDistanceX;
    [SerializeField] [Range(-3, 3)] public float horizontalDistanceZ;
    private Vector3 zoom;

    private Vector3 posToMoveTowards;

    private void Start()
    {
        LookAtPlayer();
    }

    private void OnDisable()
    {
    }
    void LateUpdate()
    {        
        MoveCameraToFolowTarget();

        if (this.transform.rotation.x > 70 || this.transform.rotation.y < 75 || this.transform.rotation.y > 103)
        {
            LookAtPlayer();
        }
    }
    public void LookAtPlayer()
    {
        transform.LookAt(lookAtThat.transform);
    }
    public void MoveCameraToFolowTarget()
    {
        Vector3 myPos = transform.position;

        zoom = new Vector3(-horizontalDistanceX, verticalDistance, horizontalDistanceZ);

        posToMoveTowards = lookAtThat.transform.position + zoom;

        transform.position = Vector3.Lerp(myPos, posToMoveTowards, Vector3.Distance(myPos, posToMoveTowards) * Time.deltaTime);
    }
}
