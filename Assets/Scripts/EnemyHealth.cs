using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Transform missileLockSpot;
    public int maxHP = 100;
    public int curHP;
    void Start()
    {
        curHP = maxHP;
    }
    public void Damage(int dmg)
    {
        GetComponent<ParticleSystem>().Play();
        curHP -= dmg;
        if (curHP <= 0)
        {
            Remove();
        }
        else
            return;
    }
    private void Remove()
    {
        GameObject.Find("GameManager").GetComponent<GameManager>().ScoreUp(2);
        GetComponent<ParticleSystem>().Play();
        Destroy(gameObject);
    }
}
