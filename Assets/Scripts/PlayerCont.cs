using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerCont : InputObj
{
    public bool inAction;

    //Movement
    public float moveSpeed;
    public float rollSpeed;
    public float yawSpeed;
    public float pitchSpeed;

    public bool isPitchingUp;
    public bool isPitchingDown;
    public bool isYawingRight;
    public bool isYawingLeft;

    private Vector3 movementVector = new Vector3();
    private Vector3 directionVector = new Vector3();

    CharacterController cc;
    InputList currentInput = new InputList();

    void Start()
    {
        cc = gameObject.GetComponent<CharacterController>();
        inAction = gameObject.GetComponent<PlayerHealth>().inAction;
    }

    public override void GetInputs(InputList inputs)
    {
        //Debug.Log("vfgf");
        currentInput = inputs;
    }

    public override void Tick(InputList inputs, float delta)
    {
        directionVector = directionVector.normalized;
        transform.rotation = Quaternion.LookRotation(directionVector);
        cc.Move(movementVector * Time.deltaTime * moveSpeed);
    }

    public override void FixedTick(float delta)
    {
        if (inAction == true)
        {
            if(currentInput.vertical < 0 && isPitchingDown != true)
            {
                isPitchingUp = true;
                transform.rotation = Quaternion.LookRotation(directionVector);
            }
            if (currentInput.vertical > 0 && isPitchingUp != true)
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
            float rotX = currentInput.horizontal;
            float rotZ = -currentInput.vertical;
            directionVector = new Vector3(rotX, 0.0f, rotZ);
            /*
            if(directionVector.magnitude != 0)
            {
                directionVector = Vector3.zero;
            }
            */
        }
    }


}
