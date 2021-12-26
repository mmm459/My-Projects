using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerEngine : MonoBehaviour
{
    public GameObject enemy;
    public GameObject yellowDiamond;
    public GameObject spawnPointEnemy;
    public int level;
    public int enemyCounter;

    // Start is called before the first frame update
    void Start()
    {
        enemyCounter = 0;
        level = 1;
        StartCoroutine(CreateEnemy());
    }


    public void CheckIfNOMoreEnemies()
    {
        if(enemyCounter <= 0)
        {
            level++;
            StartCoroutine(CreateEnemy());
        }
    }

    public IEnumerator CreateEnemy()
    {
        for(int i = 0; i < level; i++)
        {
            Instantiate(enemy, spawnPointEnemy.transform.position, Quaternion.identity);
            enemyCounter++;
            yield return new WaitForSeconds(1);
        }

        if (level%2 == 0)
        {
            int x = Random.Range(-2,8);
            int z = Random.Range(-5, 6);
            Instantiate(yellowDiamond, new Vector3(x,1,z), Quaternion.identity);
        }
    }
}
