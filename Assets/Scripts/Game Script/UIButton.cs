using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButton : MonoBehaviour
{
    public void OnLevel()
    {
        SceneManager.LoadScene("Level Selector");
    }

    public void OnReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void OnResume()
    {
        GameObject.Find("GameController").GetComponent<GameSystem>().Resume();
    }

    public void OnExit()
    {
        Application.Quit();

    }

    public void OnMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void OnNext()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        string split = sceneName.Substring(6);
        SceneManager.LoadScene("Level " + (int.Parse(split) + 1));
    }
}
