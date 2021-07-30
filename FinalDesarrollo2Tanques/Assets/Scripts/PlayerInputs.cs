﻿using System.Collections;
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


    void Update()
    {
        InputHandler();
    }

    protected virtual void InputHandler()
    {
        forwardInput = Input.GetAxisRaw("Vertical");
        rotationInput = Input.GetAxisRaw("Horizontal");
    }
}
