using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour
{
    SceneManager scene;
    public GameObject cube;

    [HideInInspector]public GameObject[,] board = new GameObject [4,4];
    public int i, j;
    public int tempi1, tempj1;
    public int tempi2, tempj2;

    public int pointsAttack;
    public int pointsDeffence;
    int counterBlue;
    int counterYellow;

    public bool turn;//false mean player 1 and true mean player 2
    public bool attackDeffence;//attack  => false || deffence => true
    [HideInInspector]public int counter;
    public int max;

    public GameObject player1Light;
    public GameObject player2Light;
    public GameObject attackButton;
    public GameObject deffenceButton;

    CheckWhoWin checkWhoWin;
    PlayerChooseSquare playerChooseSquare;

    // Start is called before the first frame update
    void Start()
    {
        counterBlue = 0;
        counterYellow = 0;
        pointsAttack = 0;
        pointsDeffence = 0;
        //transform.GetComponentInChildren<CheckWhoWin>(includeInactive: true);
        playerChooseSquare = FindObjectOfType<PlayerChooseSquare>();
        checkWhoWin = FindObjectOfType<CheckWhoWin>();
        counter = 0;
        turn = false;
        attackDeffence = false;
        CreateBoard();
        player2Light.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(EndGame());
    }

    //create mat
    public void CreateBoard()
    {
        for (i = 0; i < 4; i++)
        {
            for (j = 0; j < 4; j++)
            {
                board[i,j] = Instantiate(cube, new Vector2(i,j), Quaternion.identity);
            }
        }
    }

    //show the buttons in canvas
    public void ShowButtons()
    {
        attackButton.SetActive(true);
        deffenceButton.SetActive(true);
    }

    //after 3 seconds clear everything
    public IEnumerator clearResults()
    {
        yield return new WaitForSeconds(3);
        checkWhoWin.attackResult.text = null;
        checkWhoWin.deffenceResult.text = null;
        checkWhoWin.attack = false;
        checkWhoWin.deffence = false;
        attackButton.SetActive(false);
        deffenceButton.SetActive(false);
        pointsAttack = 0;
        pointsDeffence = 0;

        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                board[i,j].transform.GetChild(0).gameObject.SetActive(false);
                board[i, j].transform.GetChild(1).gameObject.SetActive(false);
            }
        }
        WinnerGetsCube();
        attackDeffence = false;
        turn = !turn;
    }

    //change the loser's cube to the winner color
    public void WinnerGetsCube()
    {
        if(!turn && !checkWhoWin.winner)//player2win
        {
            board[tempi1, tempj1].GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else if(!turn && checkWhoWin.winner)//plyer1win
        {
            board[tempi2, tempj2].GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else if(turn && !checkWhoWin.winner)//player1win
        {
            board[tempi2, tempj2].GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else if(turn && checkWhoWin.winner)//player2win
        {
            board[tempi1, tempj1].GetComponent<SpriteRenderer>().color = Color.yellow;
        }
    }

    IEnumerator EndGame()
    {

        for(int i = 0; i<4;i++)
        {
            for(int j =0; j<4;j++)
            {
                if(board[i,j].GetComponent<SpriteRenderer>().color == Color.blue)
                {
                    counterBlue++;
                }
                else if(board[i,j].GetComponent<SpriteRenderer>().color == Color.yellow)
                {
                    counterYellow++;
                }
            }
        }
        if(counterBlue == 16 || counterYellow == 16)
        {
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            counterBlue = 0;
            counterYellow = 0;
        }
    }
}