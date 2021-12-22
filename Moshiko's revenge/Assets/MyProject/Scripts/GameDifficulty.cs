using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDifficulty : MonoBehaviour
{
    EnemyManager enemyManager;

    static bool E;
    static bool M;
    static bool H;
    static bool I;

    public bool Easy;
    public bool Mideum;
    public bool Hard;
    public bool Insane;

    public GameObject DifficultLevelPanle;

    void Start()
    {
        ChooseEasy();
    }

    void Update()
    {
        if (E)
        {
            Easy = true;
            Mideum = false;
            Hard = false;
            Insane = false;
        }
        else if (M)
        {
            Easy = false;
            Mideum = true;
            Hard = false;
            Insane = false;
        }
        else if (H)
        {
            Easy = false;
            Mideum = false;
            Hard = true;
            Insane = false;
        }
        else if (I)
        {
            Easy = false;
            Mideum = false;
            Hard = false;
            Insane = true;
        }
    }

    public void ChooseEasy()
    {
        E = true;
        M = false;
        H = false;
        I = false;
    }

    public void ChooseMideum()
    {
        E = false;
        M = true;
        H = false;
        I = false;
    }

    public void ChooseHard()
    {
        E = false;
        M = false;
        H = true;
        I = false;
    }

    public void ChooseInsane()
    {
        E = false;
        M = false;
        H = false;
        I = true;
    }

    public void OpenDiffcultPanle()
    {
        DifficultLevelPanle.SetActive(true);
    }

    public void CloseDiffcultPanle()
    {
        DifficultLevelPanle.SetActive(false);
    }

}
