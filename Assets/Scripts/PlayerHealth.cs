using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHP = 100;
    public float curHP;
    public bool inAction;
    void Start()
    {
        curHP = maxHP;
        inAction = true;
    }
    void Damage()
    {
        if (curHP <= 0 && inAction == true)
        {
            inAction = false;
        }
        else
            return;
    }
}
