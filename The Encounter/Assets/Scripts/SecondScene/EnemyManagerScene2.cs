using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManagerScene2 : MonoBehaviour
{
    public GameObject[] enemyTypes;
    Text alert;

    private void Start()
    {
        alert = GameObject.Find("Alert").GetComponent<Text>();
        Instantiate(enemyTypes[4], new Vector2(15, -8), enemyTypes[4].transform.rotation);
        Instantiate(enemyTypes[3], new Vector2(27, -2), enemyTypes[3].transform.rotation);
        Instantiate(enemyTypes[2], new Vector2(55, 2), enemyTypes[2].transform.rotation);
        Instantiate(enemyTypes[0], new Vector2(37, -7), enemyTypes[0].transform.rotation);
        Instantiate(enemyTypes[0], new Vector2(47, -7), enemyTypes[0].transform.rotation);
        Instantiate(enemyTypes[0], new Vector2(63, -5), enemyTypes[0].transform.rotation);
        Instantiate(enemyTypes[0], new Vector2(83, -5), enemyTypes[0].transform.rotation);
        Instantiate(enemyTypes[2], new Vector2(47, 0), enemyTypes[2].transform.rotation);
        Instantiate(enemyTypes[2], new Vector2(38, 0), enemyTypes[2].transform.rotation);
        Instantiate(enemyTypes[2], new Vector2(65, 4), enemyTypes[2].transform.rotation);
        Instantiate(enemyTypes[2], new Vector2(88, 14), enemyTypes[2].transform.rotation);
        Instantiate(enemyTypes[3], new Vector2(74, 4), enemyTypes[3].transform.rotation);
        Instantiate(enemyTypes[3], new Vector2(83, 4), enemyTypes[3].transform.rotation);
        Instantiate(enemyTypes[4], new Vector2(98, 7), enemyTypes[4].transform.rotation);
        Instantiate(enemyTypes[5], new Vector2(115, 10), enemyTypes[5].transform.rotation);
        Instantiate(enemyTypes[5], new Vector2(115, 12), enemyTypes[5].transform.rotation);
        Instantiate(enemyTypes[5], new Vector2(115, 15), enemyTypes[5].transform.rotation);
        Instantiate(enemyTypes[3], new Vector2(73, 19), enemyTypes[3].transform.rotation);
        Instantiate(enemyTypes[4], new Vector2(56, 21), enemyTypes[4].transform.rotation);
        Instantiate(enemyTypes[3], new Vector2(69, 25), enemyTypes[3].transform.rotation);
        Instantiate(enemyTypes[2], new Vector2(60, 32), enemyTypes[2].transform.rotation);
    }

    public void SpawnBoss()
    {
        Instantiate(enemyTypes[6], new Vector2(-11, 33), enemyTypes[6].transform.rotation);
    }

    public void ClearAlert()
    {
        alert.text = "";
    }
}