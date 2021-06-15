using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int gameScore = 0;
    public int envPartCount = 0;
    public int envPartDepth = 0;
    public float playerPosCount = 0;
    public GameObject player;
    public Text score;
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
    public void ScoreUp()
    {
        score.text = (++gameScore).ToString();
    }

}
