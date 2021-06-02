using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeapons : InputObj
{
    InputList currentInput = new InputList();
    public bool inAction = true;
    public bool isFiring;
    public bool mgReadyFire = true;
    public bool misLock;
    public bool missileActive;
    public int weaponType = 1;
    public float torpPower;
    public float mgFireRate;
    //weaponType mg = 1, missile = 2, torpedo = 3
    public GameObject mg;
    public GameObject mgRet;
    public GameObject mgRound;
    public GameObject missile;
    public GameObject misRet;
    public GameObject misTarget;
    public GameObject torp;
    public GameObject torpLaunch;
    public Transform mgOrgin;
    public Transform targetPos;
    public Quaternion fireDir;
    public override void GetInputs(InputList inputs)
    {
        currentInput = inputs;
    }
    void Start()
    {
        misRet.SetActive(false);
    }
    public override void FixedTick(float delta)
    {
        if (inAction == true)
        {
            if(currentInput.weaponSelect == true)
            {
                checkSelect();
            }
            if (currentInput.fire == true && weaponType == 1)
            {
                mgFire();
                isFiring = true;
            }
            if (currentInput.fire == true && weaponType == 2)
            {
                isFiring = true;
                misLock = false;
            }
            if (currentInput.fire == true && weaponType == 3)
            {
                GameObject GO = Instantiate(torp, torpLaunch.transform.position, Quaternion.identity) as GameObject;
                GO.GetComponent<Rigidbody>().AddForce(torpLaunch.transform.forward * torpPower, ForceMode.Impulse);
            }
        }
    }

    void checkSelect()
    {
        if (currentInput.weaponSelect == true && currentInput.verticalAim > 0)
        {
            weaponType = 1;
            mgReadyFire = true;
            missileActive = false;
            mgRet.SetActive(true);
            misRet.SetActive(false);
        }
        if (currentInput.weaponSelect == true && currentInput.horizontalAim > 0)
        {
            weaponType = 2;
            missileLock();
            missileActive = true;
            mgRet.SetActive(false);
            misRet.SetActive(true);
        }
        if (currentInput.weaponSelect == true && currentInput.horizontalAim < 0)
        {
            weaponType = 3;
            missileActive = false;
            mgRet.SetActive(false);
            misRet.SetActive(false);
        }
    }
    void missileLock()
    {
        RaycastHit hit;
        float mgRange = 10;
        do
        {
            Ray mgRay = new Ray(mgOrgin.position, targetPos.position - mgOrgin.position);
            Debug.DrawRay(mgOrgin.position, targetPos.position - mgOrgin.position);
            if (Physics.Raycast(mgRay, out hit, mgRange))
            {
                if (hit.collider.tag == "enemy")
                {
                    Debug.Log("Hit enemy");
                }
            }
            if(missileActive == false)
                break;
        }
        while (missileActive == true);
    }
    void mgFire()
    {
        RaycastHit hit;
        float mgRange = 10;
        Ray mgRay = new Ray(mgOrgin.position, targetPos.position - mgOrgin.position);
        Debug.DrawRay(mgOrgin.position, targetPos.position - mgOrgin.position);
        if (Physics.Raycast(mgRay, out hit, mgRange))
        {
            if(hit.collider.tag == "enemy")
            {
                Debug.Log("Hit enemy");
            }
            if (hit.collider.tag == "Environment")
            {
                Debug.Log("Hit environment");
            }
        }

        GameObject spawned = Instantiate(mgRound);
        spawned.transform.forward = mgRay.direction;
        spawned.transform.position = mgOrgin.position;

        if (mgReadyFire == false)
        {
            return;
        }
     mgReadyFire = false;
     Invoke("ResetMG", mgFireRate);
    }
    void ResetMG()
    {
        mgReadyFire = true;
    }
}