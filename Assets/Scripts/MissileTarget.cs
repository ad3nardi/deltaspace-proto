using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTarget : MonoBehaviour
{
    public PlayerWeapons pw;

    public void OnTriggerStay(Collider other)
    {
        pw.mizTarget = other.transform;
    }
    public void OnTriggerEnter(Collider other)
    {
        pw.mizTarget = null;
    }
}
