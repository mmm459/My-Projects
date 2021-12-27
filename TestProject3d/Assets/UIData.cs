using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIData : MonoBehaviour
{

    //score
    public Text score;
    public int playerNum;
    public int compNum;

    //level
    public Text Level;

    //gravity
    public Text gravity;

    //movement
    public Text Movement;

    //end game
    public Text endGameScore;
    public GameObject endGameUI;

    // Start is called before the first frame update
    void Start()
    {
        playerNum = 0;
        compNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Level.text = "ComLv:" + " " + Settings.level.ToString();
        gravity.text = "Gravity:" + " " + Settings.gravity.ToString();
        Movement.text = "Movement:" + " " + Settings.isMoving.ToString();
        score.text = "(" + playerNum.ToString() + ":" + compNum.ToString() + ")";
    }

    public void EndGame()
    {
        if (playerNum == 10 || compNum == 10)
        {
            endGameUI.SetActive(true);
            if (playerNum > compNum)
            {
                endGameScore.text = "You have won:" + " " + "(" + playerNum.ToString() + ":" + compNum.ToString() + ")";
            }
            else if(playerNum < compNum)
            {
                endGameScore.text = "The computer have won:" + " " + "(" + playerNum.ToString() + ":" + compNum.ToString() + ")";
            }
            else if(playerNum == compNum)
            {
                endGameScore.text = "It is a tie:" + " " + "(" + playerNum.ToString() + ":" + compNum.ToString() + ")";
            }
        }
    }
}
