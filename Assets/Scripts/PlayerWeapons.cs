using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeapons : InputObj
{
    InputList currentInput = new InputList();
    public GameManager gm;
    public bool isFiring;
    public bool mgReadyFire = true;
    public bool mizLock;
    public bool missileActive;
    public bool torpReadyFire = true;
    public bool mizReadyFire = true;
    public int weaponType = 1;
    public int torpAmmo = 5;
    public int maxTorpAmmo = 5;
    public int mizAmmo = 5;
    public int maxMizAmmo = 5;
    public float mizSpd;
    public float torpPower;
    public float mgFireRate;
    public float torpFireRate;
    public float mizFireRate;
    public float lockTime;
    //weaponType mg = 1, missile = 2, torpedo = 3
    public GameObject mg;
    public GameObject mgRet;
    public GameObject mgRound;
    public GameObject missile;
    public GameObject mizRet;
    public GameObject miz;
    public GameObject torp;
    public GameObject torpLaunch;
    public Transform mgOrgin;
    public Transform mizOrigin;
    public Transform targetPos;
    public Transform mizTarget;
    public Quaternion fireDir;
    public TorpedoAmmo Tammo;
    public MissileAmmo Mammo;
    public override void GetInputs(InputList inputs)
    {
        currentInput = inputs;
    }
    void Start()
    {
        mizRet.SetActive(false);
        Tammo.SetMaxTammo(maxTorpAmmo);
        Mammo.SetMaxMammo(maxTorpAmmo);
        torpAmmo = maxTorpAmmo;
    }
    public override void FixedTick(float delta)
    {
        if (gm.gS == GS.inGame)
        {
            if (currentInput.weaponSelect == true)
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
                mizLock = false;
                StartCoroutine(missileLock());
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
                    Tammo.SetTammo(torpAmmo);
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
    public IEnumerator missileLock()
    {
        yield return new WaitForSeconds(lockTime);
        MissileFire();
    }
    void MissileFire()
    {
        if(mizAmmo > 0 && mizReadyFire == true && mizTarget != null)
        {
            GameObject GO = Instantiate(miz, mizOrigin.position, mizOrigin.rotation) as GameObject;
            GO.transform.LookAt(mizTarget);
            GO.GetComponent<MissileMove>().mizTarget = mizTarget.GetComponent<EnemyHealth>().missileLockSpot;
            mizAmmo--;
            Mammo.SetMammo(mizAmmo);
            StartCoroutine(resetMiz());
            mizReadyFire = false;
        }
    }

    void mgFire()
    {
        Ray mgRay = new Ray(mgOrgin.position, mgRet.transform.position - mgOrgin.position);
        Debug.DrawRay(mgOrgin.position, mgRet.transform.position - mgOrgin.position);
        if (mgReadyFire == true)
        {
            GameObject mgRnd = Instantiate(mgRound);
            mgRnd.GetComponent<Damage>().isPlayer = true;
            mgRnd.transform.forward = mgRay.direction;
            mgRnd.transform.position = mgOrgin.position;
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
    private IEnumerator resetMiz()
    {
        yield return new WaitForSeconds(mizFireRate);
        mizReadyFire = true;
    }
}