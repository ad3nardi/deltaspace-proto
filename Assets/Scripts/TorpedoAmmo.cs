using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TorpedoAmmo : MonoBehaviour
{
    public Slider torpAmmo;
    public void SetMaxTammo(int Tammo)
    {
        torpAmmo.maxValue = Tammo;
        torpAmmo.value = Tammo;
    }
    public void SetTammo(int Tammo)
    {
        torpAmmo.value = Tammo;
    }
}
