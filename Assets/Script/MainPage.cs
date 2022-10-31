using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainPage : MonoBehaviour
{
    public static void GameStart()
    {
        SceneManager.LoadScene("StageSelect");
    }
    public static void CloseGame()
    {
        Application.Quit();
    }
    public static void GoStage1()
    {
        SceneManager.LoadScene("Stage1");
    }
    public static void GoStage2()
    {
        SceneManager.LoadScene("Stage2");
    }
    public static void GoStage3()
    {
        SceneManager.LoadScene("Stage3");
    }
    public static void Back()
    {
        SceneManager.LoadScene("Main");
    }
}
