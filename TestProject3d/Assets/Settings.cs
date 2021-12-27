using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    //level
    public static int level;
    public Image image1, image2, image3;

    //distance
    public static int dis;
    public static bool random;
    string disS;

    //movement gate
    public static bool isMoving;

    //gravity
    public static bool gravity;

    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        random = false;
        dis = 10;
        isMoving = false;
        gravity = true;
    }

    public void Button1()
    {
        level = 1;
        image1.color = new Color(0, 255, 0, 255);
        image2.color = new Color(0, 0, 0, 0);
        image3.color = new Color(0, 0, 0, 0);
    }

    public void Button2()
    {
        level = 2;
        image1.color = new Color(0, 0, 0, 0);
        image2.color = new Color(255, 138, 0, 255);
        image3.color = new Color(0, 0, 0, 0);
    }

    public void Button3()
    {
        level = 3;
        image1.color = new Color(0,0,0,0);
        image2.color = new Color(0,0,0,0);
        image3.color = new Color(255,0,0,255);
    }

    public void Distance(string s)
    {
        disS = s;
        dis = int.Parse(disS);
        Debug.Log(dis);
    }

    public void RandomDistance()
    {
        dis = Random.Range(10, 31);
    }

    public void GateIsMoving()
    {
        isMoving = !isMoving;
    }

    public void Gravity()
    {
        Debug.Log(gravity);
        gravity = !gravity;
        Debug.Log(gravity);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Practice()
    {
        level = 0;
        dis = 10;
        gravity = false;
        isMoving = false;
        SceneManager.LoadScene("Game");
    }
}