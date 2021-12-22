using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawningTheBoss : MonoBehaviour
{
    public GameObject ambushBoarder;
    EnemyManagerScene2 enemyManager;

    public Image bossHealth;
    public Image bossMaxHealth;


    // Start is called before the first frame update
    void Start()
    {
        bossHealth = GameObject.Find("bossHealth").GetComponent<Image>();
        bossMaxHealth = GameObject.Find("bossMaxHealth").GetComponent<Image>();
  
        enemyManager = FindObjectOfType<EnemyManagerScene2>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bossHealth.enabled = true;
            bossMaxHealth.enabled = true;

            Instantiate(ambushBoarder, new Vector2(21, 28), ambushBoarder.transform.rotation);
            enemyManager.SpawnBoss();
            Destroy(gameObject);
        }
    }
}