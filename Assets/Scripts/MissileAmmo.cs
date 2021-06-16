using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissileAmmo : MonoBehaviour
{
    public Slider mizAmmo;
    public void SetMaxMammo(int Tammo)
    {
        mizAmmo.maxValue = Tammo;
        mizAmmo.value = Tammo;
    }
    public void SetMammo(int Tammo)
    {
        mizAmmo.value = Tammo;
    }
}
