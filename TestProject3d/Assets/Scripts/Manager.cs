using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public bool turn;//false => player || true => comp
    public int counter;

    public GameObject Buttons;
    public GameObject comp;

    MoveGate moveGate;
    Goal goal;
    ShootBall shootBall;

    public Text textLevel;
    public Text movementText;

    // Start is called before the first frame update
    void Start()
    {
        shootBall = FindObjectOfType<ShootBall>();
        goal = FindObjectOfType<Goal>();
        moveGate = FindObjectOfType<MoveGate>();
        turn = false;
        counter = 20;
        moveGate.MovingGate();
        IsGravity();
        movementText.text = SettingsScript.canMove.ToString();
        textLevel.text = SettingsScript.level.ToString();
    }

    private void Update()
    {
        if (counter == 0) ;
        {
            ShowResult();
        }
    }

    public void WhosTurn()
    {
        if (!turn)
        {
            Buttons.SetActive(true);
        }
        else if (turn)
        {
            Buttons.SetActive(false);
            CalcCompShot();
        }
    }

    public void CalcCompShot()
    {
        int chance = Random.Range(0, 101);
        counter--;
        //level
        if(SettingsScript.level == 1)//level1
        {
            if(chance >= 0 && chance <= 30)
            {
                comp.SetActive(true);
                goal.compScroe++;
            }
        }
        else if(SettingsScript.level == 2)//level2
        {
            if(chance >= 0 && chance <= 60)
            {
                comp.SetActive(true);
                goal.compScroe++;
            }
        }
        else if(SettingsScript.level == 3)//level3
        {
            if(chance >= 0 && chance <= 90)
            {
                comp.SetActive(true);
                goal.compScroe++;
            }
        }
        Invoke("StopShowComp", 3);
    }

    public void StopShowComp()
    {
        comp.SetActive(false);
        turn = !turn;
    }

    public void IsGravity()
    {
        if (SettingsScript.withGravity)
        {
            shootBall.rb.useGravity = true;
        }
        else
        {
            shootBall.rb.useGravity = false;
        }
    }


    public void ShowResult()
    {

    }
}
