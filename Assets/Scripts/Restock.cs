using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restock : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Find("Player").GetComponent<PlayerWeapons>().torpAmmo = GameObject.Find("Player").GetComponent<PlayerWeapons>().maxTorpAmmo;
            GameObject.Find("Player").GetComponent<PlayerWeapons>().mizAmmo = GameObject.Find("Player").GetComponent<PlayerWeapons>().maxMizAmmo;
            Destroy(gameObject);
        }
    }
}
