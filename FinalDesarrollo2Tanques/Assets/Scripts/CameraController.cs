using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    public bool cameraIsSelected;
    public GameObject Player;

    [SerializeField] [Range(1, 3.5f)] public float verticalDistance;
    [SerializeField] [Range(2, 8)] public float horizontalDistanceX;
    [SerializeField] [Range(-3, 3)] public float horizontalDistanceZ;
    private Vector3 zoom;
    public float cameraSpeed;
    public GameObject cameraConstraint;
    private Vector3 posToMoveTowards;

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
    
