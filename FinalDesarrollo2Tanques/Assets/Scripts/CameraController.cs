using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    public GameObject Player;

    [SerializeField] [Range(1f, 5f)] public float verticalDistance;
    [SerializeField] [Range(0, 7f)] public float zoomDistance;
    public float cameraSpeed;
    public GameObject cameraConstraint;

    private void Start()
    {
        cameraConstraint.transform.position = new Vector3(cameraConstraint.transform.position.x - zoomDistance, cameraConstraint.transform.position.y + verticalDistance, cameraConstraint.transform.position.z);
    }
    private void Update()
    {
        follow();
    }
    private void follow()
    {
        gameObject.transform.position = Vector3.Lerp(transform.position, cameraConstraint.transform.position, Time.deltaTime * cameraSpeed);
        gameObject.transform.LookAt(Player.transform.position);
    }
   
}
    
