using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingsScript : MonoBehaviour
{
    //scene
    //SceneManager scene;

    //buttons
    public Button button1;
    public Button button2;
    public Button button3;
    public static int level;

    //Gate
    public static bool canMove;

    //gravity
    public static bool withGravity;

    //distance
    public static float dis;
    string disS;


    // Start is called before the first frame update
    void Start()
    {
        //scene = GetComponent<SceneManager>();
        level = 1;
        dis = 10;
        canMove = false;
        withGravity = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelOne()
    {
        level = 1;
    }
    
    public void LevelTwo()
    {
        level = 3;
    }
    
    public void LevelThree()
    {
        level = 3;
    }

    //move or not move the gate
    public void MoveGate()
    {
        canMove = !canMove;
    }

    //with or without gravity
    public void Gravity()
    {
        withGravity = !withGravity;
    }

    //player choose distance
    public void Distance(string d)
    {
        if(disS != null)
        {
            disS = d;
            dis = int.Parse(disS);
        }
    }

    //random distance
    public void RandomDistance()
    {
        dis = Random.Range(10, 31);
    }

    //practice
    public void Practice()
    {
        level = 1;
        dis = 10;
        canMove = false;
        withGravity = true;
        SceneManager.LoadScene("Game");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}