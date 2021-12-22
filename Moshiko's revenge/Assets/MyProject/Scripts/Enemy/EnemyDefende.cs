using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefende : MonoBehaviour
{
    ControlingSystem controlingSystem;
    EnemyAtaccking enemyAtaccking;
    EnemyMovement enemyMovement;

    void Start()
    {
        controlingSystem = FindObjectOfType<ControlingSystem>();
        enemyAtaccking = GetComponent<EnemyAtaccking>();
        enemyMovement = GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        FindNearbyUnit();
        FindNearbyBuildings();
    }

    //check in the enemy list if there in unit nearby to attack him 
    public void FindNearbyUnit()
    {
        foreach (GameObject gameObject in controlingSystem.UnitsInTheGame)
        {
            if (Vector3.Distance(transform.position, gameObject.transform.position) < enemyAtaccking.ShootingRange)
            {
                enemyMovement.enabled = false;
                enemyAtaccking.UnitToAttack = gameObject;
                enemyAtaccking.enabled = true;
            }
        }
    }

    public void FindNearbyBuildings()
    {
        foreach(GameObject gameObject in controlingSystem.Buildings)
        {
            if (Vector3.Distance(transform.position, gameObject.transform.position) < enemyAtaccking.ShootingRange)
            {
                enemyMovement.enabled = false;
                enemyAtaccking.UnitToAttack = gameObject;
                enemyAtaccking.enabled = true;
            }
        }
    }
}
