using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class PlayerCont : InputObj
{
    InputList currentInput = new InputList();

    public bool inAction;
    public GameObject mgRet;

    //Movement
    public float moveSpd;
    public float throttle;
    public float latSpd;
    public float rollSpd;
    public float yawSpd;
    public float pitchSpd;

    public float vertAimSpd;
    public float horAimSpd;

    public bool isPitchingUp;
    public bool isPitchingDown;
    public bool isRollingRight;
    public bool isRollingLeft;
    public bool isYawingRight;
    public bool isYawingLeft;

    CharacterController cc;

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
        
    }

    public override void FixedTick(float delta)
    {
        if (inAction == true)
        {
            if (currentInput.vertical < 0 && isPitchingDown != true)
            {
                isPitchingUp = true;
                gameObject.transform.Rotate(pitchSpd * Time.fixedDeltaTime, 0.0f, 0.0f);
                cc.Move(Vector3.down * latSpd * Time.deltaTime);
            }
            if (currentInput.vertical > 0 && isPitchingUp != true)
            {
                isPitchingDown = true;
                gameObject.transform.Rotate(-pitchSpd * Time.fixedDeltaTime, 0.0f, 0.0f);
                cc.Move(Vector3.up * latSpd * Time.deltaTime);
            }
            if (currentInput.vertical == 0)
            {
                isPitchingUp = false;
                isPitchingDown = false;
            }
            if (isPitchingDown == false && isPitchingUp == false && isRollingLeft == false && isRollingRight == false)
            {
                transform.rotation = Quaternion.identity;
            }
            if (currentInput.horizontal < 0)
            {
                isYawingLeft = true;
                gameObject.transform.Rotate(0.0f, 0.0f, rollSpd * yawSpd * Time.fixedDeltaTime);
                cc.Move(Vector3.left * latSpd * Time.deltaTime);
            }
            if (currentInput.horizontal > 0)
            {
                isYawingRight = true;
                gameObject.transform.Rotate(0.0f, 0.0f, -rollSpd * yawSpd * Time.fixedDeltaTime);
                cc.Move(Vector3.right * latSpd * Time.deltaTime);
            }
            if (currentInput.horizontal == 0)
            {
                isYawingLeft = false;
                isYawingRight = false;
            }
            if (currentInput.rollLeft == true)
            {
                gameObject.transform.Rotate(0.0f, 0.0f, rollSpd * Time.fixedDeltaTime);
                isRollingLeft = true;
            }
            if (currentInput.rollRight == true)
            {
                gameObject.transform.Rotate(0.0f, 0.0f, -rollSpd * Time.fixedDeltaTime);
                isRollingRight = true;
            }
            if (currentInput.rollLeft == false && currentInput.rollRight == false)
            {
                isRollingLeft = false;
                isRollingRight = false;
            }
            if (currentInput.verticalAim < 0)
            {
                mgRet.transform.Translate(Vector3.down * vertAimSpd * Time.fixedDeltaTime);
            }
            if (currentInput.verticalAim > 0)
            {
                mgRet.transform.Translate(Vector3.up * vertAimSpd * Time.fixedDeltaTime);
            }
            if (currentInput.horizontalAim < 0)
            {
                mgRet.transform.Translate(Vector3.left * horAimSpd * Time.fixedDeltaTime);
            }
            if (currentInput.horizontalAim > 0)
            {
                mgRet.transform.Translate(Vector3.right * horAimSpd * Time.fixedDeltaTime);
            }
            cc.Move(Vector3.forward * moveSpd * Time.deltaTime);
        }
    }
}
