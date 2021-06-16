using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GS gS;
    public GameObject pauseMenu;
    public GameObject preMenu;
    public GameObject deathMenu;
    public GameObject inHUD;
    public int gameScore = 0;
    public int envPartCount = 0;
    public int envPartDepth = 0;
    public float playerPosCount = 0;
    public GameObject player;
    public Text score;
    public Text deathScore;
    public List<GameObject> envParts = new List<GameObject>();
    void Start()
    {        
        GameStateChange(GS.preGame);
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
    public void GameStateChange(GS gS)
    {
        if(gS == GS.preGame)
        {
            preMenu.SetActive(true);
            pauseMenu.SetActive(false);
            deathMenu.SetActive(false);
            inHUD.SetActive(false);
            Time.timeScale = 1;
        }
        if(gS == GS.inGame)
        {
            preMenu.SetActive(false);
            pauseMenu.SetActive(false);
            deathMenu.SetActive(false);
            inHUD.SetActive(true);
            Time.timeScale = 1;
        }
        if(gS == GS.inMenu)
        {
            preMenu.SetActive(false);
            pauseMenu.SetActive(true);
            deathMenu.SetActive(false);
            inHUD.SetActive(false);
            Time.timeScale = 0;
        }
        if(gS == GS.isDead)
        {
            Time.timeScale = 0;
            preMenu.SetActive(false);
            pauseMenu.SetActive(false);
            deathMenu.SetActive(true);
            inHUD.SetActive(false);
            deathScore.text = (gameScore).ToString();
        }
    }
}
public enum GS { inMenu, preGame, inGame, isDead }

