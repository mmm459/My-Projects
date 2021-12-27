using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    BallEngine ballEngine;
    UIData uIData;

    public GameObject compScored;
    bool scored;
    public bool turn;//false => player || true => computer

    // Start is called before the first frame update
    void Start()
    {
        turn = false;
        scored = false;
        ballEngine = FindObjectOfType<BallEngine>();
        uIData = FindObjectOfType<UIData>();
        Gravity();
    }

    public void CompLevel()
    {
        int chance = Random.Range(1,101);

        if(Settings.level == 1 && chance >= 1 && chance <= 30)
        {
            scored = true;
        }
        else if(Settings.level == 2 && chance >= 1 && chance <= 60)
        {
            scored = true;
        }
        else if(Settings.level == 3 && chance >= 1 && chance <= 90)
        {
            scored = true;
        }

        if (scored)
        {
            compScored.SetActive(true);
            uIData.compNum++;
            scored = false;
        }
        turn = !turn;
        uIData.EndGame();
    }


    public void Gravity()
    {
        if(Settings.gravity)
        {
            ballEngine.rb.useGravity = true;
        }
        else
        {
            ballEngine.rb.useGravity = false;
        }
    }

    public void ExitNotification()
    {
        compScored.SetActive(false);
    }
}
