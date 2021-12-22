using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    GameDifficulty gameDifficulty;

    public List<GameObject> enemyUnits = new List<GameObject>();

    public List<GameObject> SendedEnemy;

    public List<GameObject> enemyBuildings = new List<GameObject>();

    public GameObject YouWonText;

    public GameObject EnemuUnderAttack;
    public GameObject UnitToGrupAttack;

    public Transform [] PatrolPoint;

    public int RangeForHelp;

    public int WaitToAttack;
    public int NumberOfEnemyToSend;

    public int RemainBuildings;

    void Start()
    {
        gameDifficulty = FindObjectOfType<GameDifficulty>();
        CheckDifficulty();
        Invoke("SendAttack", WaitToAttack);
    }


    void Update()
    {
        CheckIfSomeoneUnderAttack();
        YouWon();
    }

    //when someone under attack check if the are any nearby enemy to send him help 
    public void CheckIfSomeoneUnderAttack()
    {
        if(EnemuUnderAttack != null)
        {
            foreach (GameObject MyEnemys in enemyUnits)
            {
                if (Vector3.Distance(EnemuUnderAttack.transform.position, MyEnemys.transform.position) < RangeForHelp)
                {
                    MyEnemys.GetComponent<EnemyAtaccking>().UnitToAttack = UnitToGrupAttack;
                    MyEnemys.GetComponent<EnemyAtaccking>().enabled = true;
                }
            }
        }


        EnemuUnderAttack = null;
    }

    //check wich unit to send the other enemy to atacck
    public void ThisEnemyIsUnderAttack(GameObject thisEnemy)
    {
        EnemuUnderAttack = thisEnemy;
        UnitToGrupAttack = EnemuUnderAttack.GetComponent<EnemyAtaccking>().UnitToAttack;
    }

    public void SendAttack()
    {
        if (enemyUnits.Count > 5)
        {
            SendedEnemy = new List<GameObject>();

            for (int i = 0; i <= NumberOfEnemyToSend; i++)
            {
                SendedEnemy.Add(enemyUnits[i]);
            }
        }

        if(SendedEnemy.Count > 0)
        {
            int WichPatrol = Random.Range(0, 2);

            foreach(GameObject gameObject in SendedEnemy)
            {
                gameObject.GetComponent<EnemyMovement>().moveToLocation = PatrolPoint[WichPatrol].position;
                gameObject.GetComponent<EnemyMovement>().enabled = true;
            }
        }
        CheckDifficulty();
        Invoke("SendAttack", WaitToAttack);
    }

    public void CheckDifficulty()
    {
        if (gameDifficulty.Easy)
        {
            NumberOfEnemyToSend = Random.Range(2, 4);
            WaitToAttack = Random.Range(220, 340);
            RangeForHelp = 4;
        }
        else if (gameDifficulty.Mideum)
        {
            NumberOfEnemyToSend = Random.Range(4, 5);
            WaitToAttack = Random.Range(200, 320);
            RangeForHelp = 6;
        }
        else if (gameDifficulty.Hard)
        {
            NumberOfEnemyToSend = Random.Range(5, 9);
            WaitToAttack = Random.Range(180, 300);
            RangeForHelp = 8;
        }
        else if (gameDifficulty.Insane)
        {
            NumberOfEnemyToSend = Random.Range(7, 12);
            WaitToAttack = Random.Range(30, 60);
            RangeForHelp = 12;
        }
    }

    public void YouWon()
    {
        RemainBuildings = 0;

        foreach(GameObject gameObject in enemyBuildings)
        {
            if(gameObject != null)
            {
                RemainBuildings++;
            }
        }

        if (RemainBuildings == 0)
        {
            YouWonText.SetActive(true);
            Invoke("LoadMainScene", 3);
        }
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene(0);
    }
}
