using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    public InputList inp = new InputList();
    public InputObj[] inputObjects;
    public bool inAction = false;

    void Start()
    {
        for (int i = 0; i < inputObjects.Length; i++)
        {
            inputObjects[i].control = this;
        }
    }
    void Update()
    {
        inp = new InputList();
        if (inAction == false)
        {
            inp.vertical = Input.GetAxis("Vertical");
            inp.horizontal = Input.GetAxis("Horizontal");
            inp.verticalAim = Input.GetAxis("VA");
            inp.horizontalAim = Input.GetAxis("HA");
            inp.fire = Input.GetButton("Fire");
            inp.weaponSelect = Input.GetButton("weaponSelect");
            inp.rollLeft = Input.GetButton("rollLeft");
            inp.rollRight = Input.GetButton("rollRight");


        }
        for (int i = 0; i < inputObjects.Length; i++)
        {
            inputObjects[i].GetInputs(inp);
            inputObjects[i].Tick(inp, Time.deltaTime);
        }
    }
    void FixedUpdate()
    {
        for (int i = 0; i < inputObjects.Length; i++)
        {
            inputObjects[i].FixedTick(Time.deltaTime);
        }
    }
}
[System.Serializable]
public class InputList
{
    public float vertical;
    public float horizontal;
    public float verticalAim;
    public float horizontalAim;
    public bool fire;
    public bool weaponSelect;
    public bool rollLeft;
    public bool rollRight;
}
