using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeapons : InputObj
{
    InputList currentInput = new InputList();
    public bool inAction;
    public bool isFiring;
    public int weaponType;

    //weaponType mg = 1, missile = 2, torpedo = 3
    public GameObject mg;
    public GameObject missile;
    public GameObject torp;
    public GameObject torpLaunch;

    public float torpPower;

    public GameObject raycastMarker = null;

    public float mgFireRate;
    private bool mgReadyFire;

    void Start()
    {
        inAction = true;
        weaponType = 1;
    }
    public override void GetInputs(InputList inputs)
    {
        currentInput = inputs;
    }

    public override void FixedTick(float delta)
    {
        RaycastHit hit;
        float distanceOfRay = 100;

        if (inAction == true)
        {
            if (currentInput.fire == true && weaponType == 1)
            {
                isFiring = true;
                raycastMarker.transform.position = hit.point;
                raycastMarker.GetComponentInChildren<ParticleSystem>().Play();
                Debug.Log(hit.point);

                if (mgReadyFire == false)
                {
                    return;
                }

                mgReadyFire = false;
                Invoke("ResetMG", mgFireRate);
            }


            if (currentInput.fire == true && weaponType == 2)
            {
                isFiring = true;
            }
            if (currentInput.fire == true && weaponType == 3)
            {
                GameObject GO = Instantiate(torp, torpLaunch.transform.position, Quaternion.identity) as GameObject;
                GO.GetComponent<Rigidbody>().AddForce(torpLaunch.transform.forward * torpPower, ForceMode.Impulse);
            }
        }

        
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * distanceOfRay);
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, distanceOfRay))
        {
            Debug.Log(hit.transform.name);
        }
    }
    private void ResetMG()
    {
        mgReadyFire = true;
    }
}