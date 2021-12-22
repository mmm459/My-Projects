using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemySoldiers : MonoBehaviour
{
    GameDifficulty gameDifficulty;
    
    public Transform setPoint;
    public GameObject soldier;
    public int waitingTime;

    // Start is called before the first frame update
    void Start()
    {
        waitingTime = 100;
        gameDifficulty = FindObjectOfType<GameDifficulty>();
        CheckDifficulty();
    }

    public void SpawnSoldiers()
    {
        GameObject s1 = Instantiate(soldier, transform.position, Quaternion.identity);
        s1.GetComponent<EnemyMovement>().moveToLocation = setPoint.position;
        s1.GetComponent<EnemyMovement>().enabled = true;
        CheckDifficulty();
    }

    public void CheckDifficulty()
    {
        if (gameDifficulty.Easy)
        {
            waitingTime = Random.Range(100, 220);
        }
        else if (gameDifficulty.Mideum)
        {
            waitingTime = Random.Range(80, 200);
        }
        else if (gameDifficulty.Hard)
        {
            waitingTime = Random.Range(60, 180);
        }
        else if (gameDifficulty.Insane)
        {
            waitingTime = Random.Range(30, 120);
        }
        Invoke("SpawnSoldiers", waitingTime);
    }
}
