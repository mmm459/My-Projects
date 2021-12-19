using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    UnityEngine.SceneManagement.Scene scene;
    string sceneName;

    private void Start()
    {
        scene = SceneManager.GetActiveScene();
        sceneName = scene.name;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Exit()
    {
        Application.Quit();
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.R) && sceneName != "Menu")
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
