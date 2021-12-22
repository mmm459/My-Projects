using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject backGroundPause;
    [SerializeField]bool enablePause = false;
    bool exitPause = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || exitPause)
        {
            enablePause = !enablePause;
            if(enablePause)
            {
                Time.timeScale = 0f;
                backGroundPause.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                backGroundPause.SetActive(false);
            }
        }
    }

    public void ReturnToGame()
    {
        enablePause = !enablePause;
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
