using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int dmg;
    public void OnTriggerEnter(Collider other )
    {
        Destroy(gameObject);
        if (other.tag == "Enemy")
            other.GetComponent<EnemyHealth>().Damage(dmg);
        if(other.tag == "Player")
            other.GetComponent<PlayerHealth>().Damage(dmg);
    }
}
