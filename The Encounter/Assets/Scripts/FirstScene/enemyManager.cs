using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyManager : MonoBehaviour
{
    [SerializeField]
    public int ambushEnemyCount = 10;
    public GameObject[] enemyTypes;
    public Transform enemySpawnPointOne;
    public Transform enemySpawnPointTwo;
    bool Left;
    bool isAmbush;
    Text alert;

    private void Start()
    {
        alert = GameObject.Find("Alert").GetComponent<Text>();
        Instantiate(enemyTypes[0], new Vector2(50, -4), enemyTypes[0].transform.rotation);
        Instantiate(enemyTypes[3], new Vector2(50, 2), enemyTypes[3].transform.rotation);
        isAmbush = false;
        Left = true;
    }

    public void AmbushSpawnEnemies()
    {
        if (!isAmbush)
        {
            alert.text = "Oh no! i've been ambushed!!\ni need to defeat " + ambushEnemyCount + " enemies!";
            Invoke("ClearAlert", 5);

            Instantiate(enemyTypes[1], enemySpawnPointOne.transform.position, enemyTypes[1].transform.rotation);
            Instantiate(enemyTypes[1], enemySpawnPointTwo.transform.position, enemyTypes[1].transform.rotation);
        }
        else if (ambushEnemyCount > 0 && isAmbush)
        {
            if (ambushEnemyCount == 6)
            {
                alert.text = "only 5 more enemies!";
                Invoke("ClearAlert", 5);
            }

            if (Left)
            {
                Instantiate(enemyTypes[1], enemySpawnPointOne.transform.position, enemyTypes[1].transform.rotation);
            }
            else
            {
                Instantiate(enemyTypes[1], enemySpawnPointTwo.transform.position, enemyTypes[1].transform.rotation);
            }
        }
        isAmbush = true;
    }

    public void WhenEnemyDie()
    {

        if (isAmbush)
        {
            if (ambushEnemyCount > 2)
            {
                AmbushSpawnEnemies();
            }

            if (Left)
            {
                Left = false;
            }
            else
            {
                Left = true;
            }

            ambushEnemyCount--;

            if (ambushEnemyCount == 0)
            {
                alert.text = "Phew! got them all, time to keep going...";
                Invoke("ClearAlert", 5);
                isAmbush = false;
            }
        }
    }
    public void ClearAlert()
    {
        alert.text = "";
    }
}