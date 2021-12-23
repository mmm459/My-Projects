using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChooseSquare : MonoBehaviour
{
    MainScript mainScript;
    public int i, j;
    public GameObject greenGlow;
    public GameObject yellowGlow;

    bool adjacentEnemy;


    public Color thisColor;

    private void Awake()
    {
        mainScript = FindObjectOfType<MainScript>();
        i = mainScript.i;
        j = mainScript.j;
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void OnMouseDown()
    {
        if (mainScript.counter < 16)//part 1
        {
            if (GetComponent<SpriteRenderer>().color == Color.white)
            {
                if (!mainScript.turn)
                {
                    GetComponent<SpriteRenderer>().color = Color.blue;
                    mainScript.player1Light.SetActive(false);
                    mainScript.player2Light.SetActive(true);
                    greenGlow = Instantiate(greenGlow, transform.position, Quaternion.identity);
                    greenGlow.SetActive(false);
                }
                else if (mainScript.turn)
                {
                    GetComponent<SpriteRenderer>().color = Color.yellow;
                    mainScript.player2Light.SetActive(false);
                    mainScript.player1Light.SetActive(true);
                    yellowGlow = Instantiate(yellowGlow, transform.position, Quaternion.identity);
                    yellowGlow.SetActive(false);
                }
                mainScript.turn = !mainScript.turn;
                mainScript.counter++;
            }
        }
        else//part 2
        {
            if (mainScript.turn == false && mainScript.attackDeffence == false && mainScript.board[i, j].GetComponent<SpriteRenderer>().color == Color.blue)//player1 attack
            {
                mainScript.tempi1 = i;
                mainScript.tempj1 = j;
                transform.GetChild(0).gameObject.SetActive(true);
                thisColor = Color.blue;
                mainScript.attackDeffence = !mainScript.attackDeffence;
                for (int adjacent = -1; adjacent < 2; adjacent++)
                {
                    if (adjacent == 1 || adjacent == -1)
                    {
                        mainScript.pointsAttack = CheckMatAttack(i, j, adjacent, thisColor);
                    }
                }
            }
            else if (mainScript.turn == false && mainScript.attackDeffence == true && mainScript.board[i, j].GetComponent<SpriteRenderer>().color == Color.yellow)//player2 deffence
            {
                adjacentEnemy = AdjacentEnemyYellow(i,j, adjacentEnemy);
                if(adjacentEnemy)
                {
                    mainScript.tempi2 = i;
                    mainScript.tempj2 = j;
                    transform.GetChild(1).gameObject.SetActive(true);
                    thisColor = Color.yellow;
                    for (int adjacent = -1; adjacent < 2; adjacent++)
                    {
                        if (adjacent == 1 || adjacent == -1)
                        {
                            mainScript.pointsDeffence = CheckMatDeffence(i, j, adjacent, thisColor);
                        }
                    }
                    mainScript.ShowButtons();
                }
            }
            else if(mainScript.turn == true && mainScript.attackDeffence == false && mainScript.board[i, j].GetComponent<SpriteRenderer>().color == Color.yellow)//player2 attack
            {
                mainScript.tempi2 = i;
                mainScript.tempj2 = j;
                transform.GetChild(0).gameObject.SetActive(true);
                thisColor = Color.yellow;
                
                for (int adjacent = -1; adjacent < 2; adjacent++)
                {
                    if (adjacent == 1 || adjacent == -1)
                    {
                        mainScript.pointsAttack = CheckMatAttack(i, j, adjacent, thisColor);
                    }
                }
                mainScript.attackDeffence = !mainScript.attackDeffence;
            }
            else if(mainScript.turn == true && mainScript.attackDeffence == true && mainScript.board[i, j].GetComponent<SpriteRenderer>().color == Color.blue)//player1 deffence
            {
                adjacentEnemy = AdjacentEnemyBlue(i, j, adjacentEnemy);
                if (adjacentEnemy)
                {
                    mainScript.tempi1 = i;
                    mainScript.tempj1 = j;
                    transform.GetChild(1).gameObject.SetActive(true);
                    thisColor = Color.blue;
                    for (int adjacent = -1; adjacent < 2; adjacent++)
                    {
                        if (adjacent == 1 || adjacent == -1)
                        {
                            mainScript.pointsDeffence = CheckMatDeffence(i, j, adjacent, thisColor);
                        }
                    }
                    mainScript.ShowButtons();
                }
            }
        }
    }

    //check if the enemy cube is adjacent
    public bool AdjacentEnemyYellow(int i, int j, bool adjacentEnemy)
    {
        if (i == mainScript.tempi1)
        {
            if(j == mainScript.tempj1 + 1 || j == mainScript.tempj1 - 1)
            {
                return adjacentEnemy = true;
            }
        }
        else if(j == mainScript.tempj1)
        {
            if (i == mainScript.tempi1 + 1 || i == mainScript.tempi1 - 1)
            {
                return adjacentEnemy = true;
            }
        }
        return adjacentEnemy = false;
    }
    
    //check if the enemy cube is adjacent
    public bool AdjacentEnemyBlue(int i, int j, bool adjacentEnemy)
    {
        if (i == mainScript.tempi2)
        {
            if(j == mainScript.tempj2 + 1 || j == mainScript.tempj2 - 1)
            {
                return adjacentEnemy = true;
            }
        }
        else if(j == mainScript.tempj2)
        {
            if (i == mainScript.tempi2 + 1 || i == mainScript.tempi2 - 1)
            {
                return adjacentEnemy = true;
            }
        }
        return adjacentEnemy = false;
    }

    //check how many points the attacker has
    public int CheckMatAttack(int i, int j, int adjacent, Color thisColor)
    {
        if(i >= 0 && i < 3 && adjacent > 0)
        {
            if(mainScript.board[i + adjacent,j].GetComponent<SpriteRenderer>().color == thisColor)
            {
                mainScript.pointsAttack++;
            }
        }
        if(i <= 3 && i > 0 && adjacent < 0)
        {
            if(mainScript.board[i + adjacent,j].GetComponent<SpriteRenderer>().color == thisColor)
            {
                mainScript.pointsAttack++;
            }
        }
        if (j >= 0 && j < 3 && adjacent > 0)
        {
            if (mainScript.board[i, j + adjacent].GetComponent<SpriteRenderer>().color == thisColor)
            {
                mainScript.pointsAttack++;
            }
        }
        if (j <= 3 && j > 0 && adjacent < 0)
        {
            if (mainScript.board[i, j + adjacent].GetComponent<SpriteRenderer>().color == thisColor)
            {
                mainScript.pointsAttack++;
            }
        }
        return mainScript.pointsAttack;
    }

    //check how many teh deffencer has
    public int CheckMatDeffence(int i, int j, int adjacent, Color thisColor)
    {
        if (i >= 0 && i < 3 && adjacent > 0)
        {
            if (mainScript.board[i + adjacent, j].GetComponent<SpriteRenderer>().color == thisColor)
            {
                mainScript.pointsDeffence++;
            }
        }
        if (i <= 3 && i > 0 && adjacent < 0)
        {
            if (mainScript.board[i + adjacent, j].GetComponent<SpriteRenderer>().color == thisColor)
            {
                mainScript.pointsDeffence++;
            }
        }
        if (j >= 0 && j < 3 && adjacent > 0)
        {
            if (mainScript.board[i, j + adjacent].GetComponent<SpriteRenderer>().color == thisColor)
            {
                mainScript.pointsDeffence++;
            }
        }
        if (j <= 3 && j > 0 && adjacent < 0)
        {
            if (mainScript.board[i, j + adjacent].GetComponent<SpriteRenderer>().color == thisColor)
            {
                mainScript.pointsDeffence++;
            }
        }
        return mainScript.pointsDeffence;
    }
}