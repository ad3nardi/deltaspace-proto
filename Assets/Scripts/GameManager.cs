using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int Score = 0;
    public int envPartCount = 0;
    public int envPartDepth = 0;
    public float playerPosCount = 0;
    public GameObject player;
    public List<GameObject> envParts = new List<GameObject>();
    void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            BuildEnv();
        }
    }
    public void BuildEnv()
    {
        Instantiate(envParts[Random.Range(0, envParts.Count)],
            Vector3.forward * envPartCount * envPartDepth, Quaternion.identity);
        envPartCount++;
    }
    void Update()
    {
        if (player.transform.position.z > playerPosCount)
        {
            playerPosCount += envPartDepth;
            BuildEnv();
        }
    }
}
