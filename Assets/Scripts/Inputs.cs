using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    public InputList inp = new InputList();
    public InputObj[] inputObjects;
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
        inp.vertical = Input.GetAxis("VertMove");
        inp.horizontal = Input.GetAxis("HorMove");
        inp.verticalAim = Input.GetAxis("VertAim");
        inp.horizontalAim = Input.GetAxis("HorAim");
        inp.fire = Input.GetButton("Fire");
        inp.weaponSelect = Input.GetButton("WeaponSelect");
        inp.rollLeft = Input.GetButton("RollLeft");
        inp.rollRight = Input.GetButton("RollRight");
        inp.esc = Input.GetButton("Esc");

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
    public bool esc;
}
