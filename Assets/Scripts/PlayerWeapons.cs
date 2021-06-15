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
    public bool mizLock;
    public bool missileActive;
    public bool torpReadyFire = true;
    public int weaponType = 1;
    public int torpAmmo = 5;
    public int mizAmmo = 5;
    public float mizSpd;
    public float torpPower;
    public float mgFireRate;
    public float torpFireRate;
    public float lockTime;
    //weaponType mg = 1, missile = 2, torpedo = 3
    public Camera cam;
    public GameObject mg;
    public GameObject mgRet;
    public RectTransform MGret;
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
        RaycastHit hit;
        if (weaponType == 2)
        {
            float mizRange = 10;
            {
                Ray mizRay = new Ray(mizOrigin.position, targetPos.position - mizOrigin.position);
                Debug.DrawRay(mizOrigin.position, targetPos.position - mizOrigin.position);
                if (Physics.Raycast(mizRay, out hit, mizRange))
                {
                    if (hit.collider.tag == "Enemy")
                    {
                        missileLock();
                        mizTarget = hit.collider.transform;
                    }
                }
            }
        }
    }
    public IEnumerator missileLock()
    {
        yield return new WaitForSeconds(lockTime);
        MissileFire();
    }
    void MissileFire()
    {
        Instantiate(miz, mizOrigin.position, mizOrigin.rotation);
        miz.transform.LookAt(mizTarget);
        StartCoroutine(MissileDirect(missile));
    }
    public IEnumerator MissileDirect(GameObject missile)
        {
        while (Vector3.Distance(mizTarget.position, missile.transform.position) > 0.3f)
        {
            missile.transform.position += (mizTarget.position - missile.transform.position).normalized * mizSpd * Time.deltaTime;
            missile.transform.LookAt(mizTarget);
            yield return null;
        }
        Destroy(miz);
        }
    void mgFire()
    {
        RaycastHit hit;
        float mgRange = 10;
        Ray mgRay = new Ray(mgOrgin.position, MGret.position - mgOrgin.position);
        Debug.DrawRay(mgOrgin.position, MGret.position - mgOrgin.position);
    //    MGret.transform.position = cam.WorldToViewportPoint(hit.point);
        if (Physics.Raycast(mgRay, out hit, mgRange))
        {
            
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