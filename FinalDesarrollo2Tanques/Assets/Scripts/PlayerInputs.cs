using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{

    private float forwardInput;
    public float ForwardInput
    {
        get { return forwardInput; }        
    }
    private float rotationInput;
    public float RotationInput
    {
        get { return rotationInput; }
    }

    private bool shootInput;
    public bool ShootInput
    {
        get { return shootInput; }
    }


    void Update()
    {
        InputHandler();
    }

    protected virtual void InputHandler()
    {
        forwardInput = Input.GetAxisRaw("Vertical");
        rotationInput = Input.GetAxisRaw("Horizontal");
        shootInput = Input.GetMouseButtonDown(0);
    }
}
