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
    public bool torpReadyFire = true;
    public int weaponType = 1;
    public int torpAmmo = 5;
    public int mizAmmo = 5;
    public float torpPower;
    public float mgFireRate;
    public float torpFireRate;
    public float lockTime;
    //weaponType mg = 1, missile = 2, torpedo = 3
    public GameObject mg;
    public GameObject mgRet;
    public GameObject mgRound;
    public GameObject missile;
    public GameObject mizRet;
    public GameObject mizTarget;
    public GameObject torp;
    public GameObject torpLaunch;
    public Transform mgOrgin;
    public Transform mizOrigin;
    public Transform targetPos;
    public Quaternion fireDir;
    public override void GetInputs(InputList inputs)
    {
        currentInput = inputs;
    }
    void Start()
    {
        mizRet.SetActive(false);
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
                if (torpAmmo > 0 && torpReadyFire == true)
                {
                    GameObject GO = Instantiate(torp, torpLaunch.transform.position, Quaternion.identity) as GameObject;
                    GO.GetComponent<Rigidbody>().AddForce(torpLaunch.transform.forward * torpPower, ForceMode.Impulse);
                    torpReadyFire = false;
                    StartCoroutine(resetTorp());
                    torpAmmo--;
                }
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
            mizRet.SetActive(false);
        }
        if (currentInput.weaponSelect == true && currentInput.horizontalAim > 0)
        {
            weaponType = 2;
            missileActive = true;
            mgRet.SetActive(false);
            mizRet.SetActive(true);
        }
        if (currentInput.weaponSelect == true && currentInput.horizontalAim < 0)
        {
            weaponType = 3;
            missileActive = false;
            mgRet.SetActive(false);
            mizRet.SetActive(false);
        }
    }
    void Update()
    {
        if (weaponType == 2)
        {
            RaycastHit hit;
            float mizRange = 10;
            {
                Ray mizRay = new Ray(mizOrigin.position, targetPos.position - mizOrigin.position);
                Debug.DrawRay(mizOrigin.position, targetPos.position - mizOrigin.position);
                if (Physics.Raycast(mizRay, out hit, mizRange))
                {
                    if (hit.collider.tag == "Enemy")
                    {
                        missileLock();
                        mizTarget = hit.collider.gameObject;
                    }
                }
            }
        }
    }
    void missileLock()
    {
        
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
        if (mgReadyFire == true)
        {
            GameObject spawned = Instantiate(mgRound);
            spawned.transform.forward = mgRay.direction;
            spawned.transform.position = mgOrgin.position;
            mgReadyFire = false;
            StartCoroutine(ResetMG());
        }
        if (mgReadyFire == false)
        {
            return;
        }
     
    }
    private IEnumerator ResetMG()
    {
        yield return new WaitForSeconds(mgFireRate);
        mgReadyFire = true;
    }
    private IEnumerator resetTorp()
    {
        yield return new WaitForSeconds(torpFireRate);
        torpReadyFire = true;
    }
}