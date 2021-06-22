using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int dmg;
    public bool isPlayer;
    public void OnTriggerEnter(Collider other )
    {
        if (other.tag == "Enemy" && isPlayer)
        {
            other.GetComponent<EnemyHealth>().Damage(dmg);
            Destroy(gameObject);
        }
        if (other.tag == "Player" && !isPlayer)
        {
            other.GetComponent<PlayerHealth>().Damage(dmg);
            Destroy(gameObject);
        }
    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy" && isPlayer)
        {
            other.gameObject.GetComponent<EnemyHealth>().Damage(dmg);
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Player" && !isPlayer)
        {
            other.gameObject.GetComponent<PlayerHealth>().Damage(dmg);
            Destroy(gameObject);
        }
    }

}
