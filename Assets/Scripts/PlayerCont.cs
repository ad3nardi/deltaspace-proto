using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Rendering.Universal.Internal;

public class PlayerCont : InputObj
{
    InputList currentInput = new InputList();
    public GameManager gm;
    public Transform weap;
    public Vector3 aimClamp;
    //Movement
    public float moveSpd;
    public float throttle;
    public float latSpd;
    public float rollSpd;
    public float rollMult;
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
    }
    public override void GetInputs(InputList inputs)
    {
        currentInput = inputs;
    }
    public override void FixedTick(float delta)
    {
        if (gm.gS == GS.inGame)
        {
            if (currentInput.vertical < 0)
            {
                transform.Rotate(pitchSpd * Time.fixedDeltaTime, 0.0f, 0.0f);
                cc.Move(Vector3.down * latSpd * Time.deltaTime);
            }
            if (currentInput.vertical > 0)
            {
                transform.Rotate(-pitchSpd * Time.fixedDeltaTime, 0.0f, 0.0f);
                cc.Move(Vector3.up * latSpd * Time.deltaTime);
            }
            if (isRollingLeft == false && isRollingRight == false)
            {
                transform.rotation = Quaternion.identity;
            }
            if (currentInput.horizontal < 0)
            {
                isYawingLeft = true;
                transform.Rotate(0.0f, 0.0f, rollSpd * yawSpd * Time.fixedDeltaTime);
                cc.Move(Vector3.left * latSpd * Time.deltaTime);
            }
            if (currentInput.horizontal > 0)
            {
                isYawingRight = true;
                transform.Rotate(0.0f, 0.0f, -rollSpd * yawSpd * Time.fixedDeltaTime);
                cc.Move(Vector3.right * latSpd * Time.deltaTime);
            }
            if (currentInput.horizontal == 0)
            {
                isYawingLeft = false;
                isYawingRight = false;
            }
            if (currentInput.rollLeft == true)
            {
                transform.Rotate(0.0f, 0.0f, rollSpd * rollMult * Time.fixedDeltaTime);
                isRollingLeft = true;
            }
            if (currentInput.rollRight == true)
            {
                transform.Rotate(0.0f, 0.0f, -rollSpd * rollMult * Time.fixedDeltaTime);
                isRollingRight = true;
            }
            if (currentInput.rollLeft == false && currentInput.rollRight == false)
            {
                isRollingLeft = false;
                isRollingRight = false;
            }
            if (currentInput.verticalAim < 0)
                aimClamp += -weap.transform.up * vertAimSpd * Time.deltaTime;
            if (currentInput.verticalAim > 0)
                aimClamp += weap.transform.up * vertAimSpd * Time.deltaTime;
            if (currentInput.horizontalAim < 0)
                aimClamp += -weap.transform.right * vertAimSpd * Time.deltaTime;
            if (currentInput.horizontalAim > 0)
                aimClamp += weap.transform.right * vertAimSpd * Time.deltaTime;
            if (currentInput.esc == true)
            {
                gm.GameStateChange(GS.inMenu);
                gm.gS = GS.inMenu;
            }
            cc.Move(Vector3.forward * moveSpd * Time.deltaTime);
            aimClamp.x = Mathf.Clamp(aimClamp.x, -8.4f, 8.4f);
            aimClamp.y = Mathf.Clamp(aimClamp.y, -4.5f, 5);
            aimClamp.z = 20;
            weap.transform.localPosition = aimClamp;
        }
        if (gm.gS == GS.preGame)
            if (currentInput.fire == true)
            {
                gm.GameStateChange(GS.inGame);
                gm.gS = GS.inGame;
            }
    }
}
