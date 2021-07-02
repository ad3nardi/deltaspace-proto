using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class EnemSpawn : MonoBehaviour
{
    public List<GameObject> enemType = new List<GameObject>();
    public List<Transform> spawnLoc = new List<Transform>();
    public GameManager gm;
    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && gm.gS == GS.inGame)
        {
            Instantiate(enemType[Random.Range(0, enemType.Count)], spawnLoc[Random.Range(0, spawnLoc.Count)].position, spawnLoc[Random.Range(0, spawnLoc.Count)].rotation);
        }
    }
}
