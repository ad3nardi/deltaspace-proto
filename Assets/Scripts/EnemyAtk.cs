using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAtk : MonoBehaviour
{
    public enum ToggleType { bomber, striker, hunter }
    public ToggleType enemType;
    public GameObject enemRnd;
    public GameObject bomb;
    public float bombPwr;
    public float rndPwr;
    public bool enemRndRdy = true;
    public float enemFR;
    public float bombFR;

    private void OnTriggerStay(Collider other)
    {
        if (enemType == ToggleType.hunter || enemType == ToggleType.striker && other.tag == "Player")
        {
            if (enemRndRdy == true)
            {
                GameObject GO = Instantiate(enemRnd, transform.position, transform.rotation) as GameObject;
                GO.transform.LookAt(GameObject.Find("Player").transform);
                enemRndRdy = false;
                StartCoroutine(resetEnemRnd());
            }
        }
        if (enemType == ToggleType.bomber && other.tag == "Player")
        {

            GameObject GO = Instantiate(bomb, transform.position, Quaternion.identity) as GameObject;
            GO.GetComponent<Rigidbody>().AddForce(bomb.transform.forward * bombPwr, ForceMode.Impulse);
            StartCoroutine(resetEnemBomb());
        }
    }
    private IEnumerator resetEnemRnd()
    {
        yield return new WaitForSeconds(enemFR);
        enemRndRdy = true;
    }
    private IEnumerator resetEnemBomb()
    {
        yield return new WaitForSeconds(bombFR);
        enemRndRdy = true;
    }
}
