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
        GetComponentInParent<ParticleSystem>().Play();
        curHP -= dmg;
        hpBar.SetHealth(curHP);
        Debug.Log("dmgtaken");
        if (curHP <= 0)
        {
            gm.gS = GS.isDead;
            gm.GameStateChange(GS.isDead);
            Time.timeScale = 0;
        }
        else
            return;
    }
}
