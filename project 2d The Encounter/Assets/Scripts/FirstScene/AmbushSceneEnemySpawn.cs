using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmbushSceneEnemySpawn : MonoBehaviour
{
    public GameObject ambushBoarder;
    enemyManager enemyManager;


    private void Start()
    {
        enemyManager = FindObjectOfType<enemyManager>();
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Instantiate(ambushBoarder, new Vector2(103, -3), ambushBoarder.transform.rotation);
            Instantiate(ambushBoarder, new Vector2(57, -3), ambushBoarder.transform.rotation);
            enemyManager.AmbushSpawnEnemies();
            Destroy(gameObject);
        }
    }
}