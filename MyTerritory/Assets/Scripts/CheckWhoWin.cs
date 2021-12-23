using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckWhoWin : MonoBehaviour
{
    MainScript mainScript;
    public Text attackResult;
    public Text deffenceResult;
    int cubePoints;
    int sumDeffence;
    int sumAttack;
    [HideInInspector]public bool winner;//false => player1 win || true => player2 win
    [HideInInspector]public bool deffence, attack;

    private void Start()
    {
        sumAttack = 0;
        sumDeffence = 0;
        deffence = false;
        attack = false;
        mainScript = FindObjectOfType<MainScript>();
    }

    private void Update()
    {
        //if clicked both buttons then enter
        if(attack && deffence)
        {
            FinishResults();

        }
    }

    //roll and show points, sum and result for deffence
    public void Deffence()
    {
        cubePoints = Random.Range(1, 7);
        sumDeffence = mainScript.pointsDeffence + cubePoints;
        deffenceResult.text = mainScript.pointsDeffence.ToString() + " " + "+" + " " + cubePoints.ToString() + " " + "=" + " " + sumDeffence.ToString();
        deffence = true;
    }

    //roll and show points, sum and result for attack
    public void Attack()
    {
        cubePoints = Random.Range(1, 7);
        sumAttack = mainScript.pointsAttack + cubePoints;
        attackResult.text = mainScript.pointsAttack.ToString() + " " + "+" + " " + cubePoints.ToString() + " " + "=" + " " + sumAttack.ToString();
        attack = true;
    }

    //check who won
    public void FinishResults()
    {
        if(sumDeffence < sumAttack && !mainScript.turn)//blue's turn and player1 won
        {
            winner = true;
        }
        else if(sumAttack < sumDeffence && !mainScript.turn)//blue's turn and player2 won
        {
            winner = false;
        }
        else if (sumDeffence < sumAttack && mainScript.turn)//yellow's turn and player2 won
        {
            winner = true;
        }
        else if (sumAttack < sumDeffence && mainScript.turn)//yellow's turn and player1 won
        {
            winner = false;
        }
        else if(sumDeffence == sumAttack)
        {
            StartCoroutine(ClearText());
        }
        if (deffence && attack)
        {
            deffence = false;
            attack = false;
            StartCoroutine(mainScript.clearResults());
        }

    }

    //in case there is a tie then try again and clear text
    IEnumerator ClearText()
    {
        deffence = false;
        attack = false;
        yield return new WaitForSeconds(3);
        sumAttack = 0;
        sumDeffence = 0;
        attackResult.text = null;
        deffenceResult.text = null;
    }
}
