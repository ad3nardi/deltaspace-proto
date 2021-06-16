using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameManager gm;
    public GameObject pauseMenu;
    public void ClickButton(int buttonClicked)
    {
        if (buttonClicked == 1)
            SceneManager.LoadScene("deltaspace");
        if (buttonClicked == 2)
            ExitGame();
        if (buttonClicked == 3)
            SceneManager.LoadScene("control_menu");
        if (buttonClicked == 4)
            SceneManager.LoadScene("menu_main");
        if (buttonClicked == 5)
        {
            Time.timeScale = 1;
            gm.GameStateChange(GS.inGame);
            gm.gS = GS.inGame;
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
