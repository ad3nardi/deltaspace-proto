﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 100;
    public int curHP;
    public bool inAction;
    public HP_UI hpBar;
    
    void Start()
    {
        curHP = maxHP;
        hpBar.SetMaxHealth(maxHP);
        inAction = true;
    }
    public void Damage(int dmg)
    {
        GetComponent<ParticleSystem>().Play();
        curHP -= dmg;
        if (curHP <= 0)
        {
            inAction = false;
        }
        else
            return;
    }
}
