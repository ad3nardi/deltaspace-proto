using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class PlayerCont : InputObj
{
    public bool inAction;

    //Movement
    public float moveSpd;
    public float throttle;
    public float latSpd;
    public float rollSpd;
    public float yawSpd;
    public float pitchSpd;

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
        inAction = true;
    }

    public override void GetInputs(InputList inputs)
    {
        currentInput = inputs;
    }

    public override void Tick(InputList inputs, float delta)
    {
     //   directionVector = directionVector.normalized;
     //   transform.rotation = Quaternion.LookRotation(directionVector);
    }

    public override void FixedTick(float delta)
    {
        if (inAction == true)
        {
            if(currentInput.vertical < 0 && isPitchingDown != true)
            {
                isPitchingUp = true;
                gameObject.transform.Rotate(pitchSpd * Time.deltaTime, 0.0f, 0.0f);
                cc.Move(Vector3.down * latSpd * Time.deltaTime);
            }
            if (currentInput.vertical > 0 && isPitchingUp != true)
            {
                isPitchingDown = true;
                gameObject.transform.Rotate(-pitchSpd * Time.deltaTime, 0.0f, 0.0f);
                cc.Move(Vector3.up * latSpd * Time.deltaTime);
            }
            if(currentInput.vertical == 0)
            {
                isPitchingUp = false;
                isPitchingDown = false;
            }
            if (currentInput.horizontal < 0)
            {
                isYawingLeft = true;
                gameObject.transform.Rotate(0.0f, 0.0f, -rollSpd * Time.deltaTime);
                cc.Move(Vector3.left * latSpd * Time.deltaTime);

            }
            if (currentInput.horizontal > 0)
            {
                isYawingRight = true;
                gameObject.transform.Rotate(0.0f, 0.0f, -rollSpd * Time.deltaTime);
                cc.Move(Vector3.right * latSpd * Time.deltaTime);
            }
            if (currentInput.horizontal == 0)
            {
                isYawingLeft = false;
                isYawingRight = false;
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
                gameObject.transform.Rotate(0.0f, 0.0f, rollSpd * Time.deltaTime);
            }
            if (currentInput.rollRight == true)
            {
                gameObject.transform.Rotate(0.0f, 0.0f, -rollSpd * Time.deltaTime);

            }
            cc.Move(Vector3.forward * moveSpd * Time.deltaTime);

        //    if(gameObject.transform.rotation)
        //    {
        //      gameObject.transform.Rotate(0.0f, 0.0f, 0.0f)
        //    }

          /* 
            directionVector = new Vector3(rotX, 0.0f, rotZ);
            var angle = Mathf.Atan2(directionVector.x, directionVector.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, angle, 0f), Time.fixedDeltaTime * pitchSpd);
            
            if(directionVector.magnitude != 0)
            {
                directionVector = Vector3.zero;
            }
            */
        }
    }


}
