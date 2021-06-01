using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PlayerCont : InputObj
{
    public bool gameActive;

    //Movement
    public float moveSpeed;
    public float rollSpeed;
    public float yawSpeed;
    public float pitchSpeed;

    public bool isPitchingUp;
    public bool isPitchingDown;
    public bool isYawingRight;
    public bool isYawingLeft;

    private Vector3 previousRotationDirection = Vector3.forward;
    private Vector3 movementVector = new Vector3();
    private Vector3 directionVector = new Vector3();

    CharacterController cc;
    InputList currentInput = new InputList();

    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
    }

    public override void GetInputs(InputList inputs)
    {
        //Debug.Log("vfgf");
        currentInput = inputs;
    }


    public override void Tick(InputList inputs, float delta)
    {
    }

    public override void FixedTick(float delta)
    {
        if (gameActive == true)
        {
            if(currentInput.vertical < 0)
            {
                isPitchingUp = true;
                cc.transform.rotation;

            }
            if (currentInput.vertical > 0)
            {
                isPitchingDown = true;
            }
            if (currentInput.horizontal < 0)
            {
                isYawingLeft = true;
            }
            if (currentInput.horizontal > 0)
            {
                isYawingRight = true;
            }
            if (currentInput.verticalAim < 0)
            {
                //aim down
            }
            if (currentInput.verticalAim > 0)
            {
                //aim up
            }
            if (currentInput.horizontalAim < 0)
            {
                //aim left
            }
            if (currentInput.horizontalAim > 0)
            {
                //aim right
            }
            if (currentInput.weaponSelect == true)
            {

            }
            if (currentInput.rollLeft == true)
            {

            }
            if (currentInput.rollRight == true)
            {

            }
        }
    }


}
