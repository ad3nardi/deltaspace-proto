using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    public GameManager gm;
    public int maxHP = 100;
    public int curHP;
    public HP_UI hpBar;
    void Start()
    {
        curHP = maxHP;
        hpBar.SetMaxHealth(maxHP);
    }
    public void Damage(int dmg)
    {
        GetComponent<ParticleSystem>().Play();
        curHP -= dmg;
        hpBar.SetHealth(curHP);
        if (curHP <= 0)
            gm.GameStateChange(GS.isDead);
        else
            return;
    }
}
