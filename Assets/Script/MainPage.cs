using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainPage : MonoBehaviour
{
    public static void GameStart()
    {
        SceneManager.LoadScene("Stage1");
    }
    public static void CloseGame()
    {
        Application.Quit();
    }
}
