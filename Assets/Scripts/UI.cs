using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameManager gm;

    public void loadDeltaSpace()
    {
        SceneManager.LoadScene("deltaspace");
    }
    public void Controls()
    {
        SceneManager.LoadScene("control_menu");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("menu_main");
    }
    public void UnPause()
    {
        gm.gS = GS.inGame;
        gm.GameStateChange(GS.inGame);
        Debug.Log("inGame");

    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
