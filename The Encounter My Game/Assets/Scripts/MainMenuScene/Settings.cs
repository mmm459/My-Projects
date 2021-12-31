using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public GameObject SettingUI;
    public GameObject optionBG;

    public void StartGame()
    {
        SceneManager.LoadScene("Part1");
    }

    public void Options()
    {
        SettingUI.SetActive(false);
        optionBG.SetActive(true);
    }

    public void Back()
    {
        SettingUI.SetActive(true);
        optionBG.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
