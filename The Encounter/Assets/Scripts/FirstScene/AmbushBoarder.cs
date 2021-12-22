using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbushBoarder : MonoBehaviour
{
    enemyManager enemyManager;
    float speed = 5f;

    private void Start()
    {
        enemyManager = GameObject.Find("EnemyManager").GetComponent<enemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyManager.GetComponent<enemyManager>().ambushEnemyCount == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(transform.position.x, 10), speed * Time.deltaTime);
            Destroy(gameObject, 3);
        }
    }
}