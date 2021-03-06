using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(PlayerInputs))]
public class PlayerController : MonoBehaviour
{
    private Terrain terrain;
    private PlayerInputs input;
    private PlayerManager manager;
    [Header("Player speeds")]
    public float speed;
    public float rotationSpeed;
    public float canonRotationSpeed;
    [Header("No tocar")]
    public float height;
    public bool rotatingCanon;
    public bool canonIsRotating;

    [Header("GameObjects")]
    public GameObject Canon;
    public GameObject Bomb;
    public GameObject ShootingPoint;
    void Start()
    {
        canonIsRotating = false;
        rotatingCanon = false;
        input = GetComponent<PlayerInputs>();
        manager = GetComponent<PlayerManager>();
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
        if (!canonIsRotating)
        {
            MoveForward();
            RotateTank();
        }
        rotatingCanon = input.ShootInput;
    }


    void LateUpdate()
    {
        if (!canonIsRotating && rotatingCanon) rotateCanon();
    }
    private void MoveForward()
    {
        Vector3 wantedPos = transform.forward * input.ForwardInput * speed * Time.deltaTime;
        this.transform.position += new Vector3(wantedPos.x, 0, wantedPos.z);
        if (input.ForwardInput != 0)
        {
            manager.SetDistanceTraveled(manager.GetDistanceTraveled() + (Time.deltaTime * speed));
        }
    }
    private void RotateTank()
    {
        transform.Rotate(0.0f, input.RotationInput * Time.deltaTime * rotationSpeed, 0.0f);
        // transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(transform.rotation.x, input.RotationInput * Time.deltaTime * rotationSpeed, transform.rotation.z, transform.rotation.w), 1);
    }
    private void rotateCanon()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            Vector3 direction = hit.point - transform.position;
            if (Mathf.Abs(direction.x) >= 1 && Mathf.Abs(direction.z) > 1)
            {
                StartCoroutine(RotateCanon(direction));
            }

            Debug.Log(direction);
        }
    }

  
    private void shoot()
    {
        Instantiate(Bomb, ShootingPoint.transform.position, Canon.transform.rotation);
    }

    IEnumerator RotateCanon(Vector3 shootPos)
    {
        bool alreadyShoot = false;
        float maxTimeToShoot = 0;
        while (Quaternion.LookRotation(shootPos) != Canon.transform.rotation  )
        {
            maxTimeToShoot += Time.deltaTime;
            #region fail test position to shoot
            /*  
           while (Canon.transform.rotation.x <= Quaternion.LookRotation(shootPos).x + 0.01 && Canon.transform.rotation.x >= Quaternion.LookRotation(shootPos).x - 0.01 &&
          Canon.transform.rotation.y <= Quaternion.LookRotation(shootPos).y + 0.01 && Canon.transform.rotation.y >= Quaternion.LookRotation(shootPos).y - 0.01 &&
          Canon.transform.rotation.z <= Quaternion.LookRotation(shootPos).z + 0.01 && Canon.transform.rotation.z >= Quaternion.LookRotation(shootPos).z - 0.01 &&
          Canon.transform.rotation.w <= Quaternion.LookRotation(shootPos).w + 0.01 && Canon.transform.rotation.w >= Quaternion.LookRotation(shootPos).w - 0.01)
           {*/
            #endregion
            Canon.transform.rotation = Quaternion.Slerp(Canon.transform.rotation, Quaternion.LookRotation(shootPos), canonRotationSpeed * Time.deltaTime);
            canonIsRotating = true;

            Debug.Log("time " + maxTimeToShoot);

            if (maxTimeToShoot >= 4 && !alreadyShoot)
            {
                alreadyShoot = true;
                shoot();
                canonIsRotating = false;
                break;
            }
            if (maxTimeToShoot >= 6)
            {
                alreadyShoot = true;
                canonIsRotating = false;
                break;
            }
            yield return new WaitForEndOfFrame();
        }
        if (!alreadyShoot)
        {
            alreadyShoot = true;
            shoot();
        }
        canonIsRotating = false;
        yield return null;
    }

}
