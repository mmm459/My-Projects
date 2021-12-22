using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitDefende : MonoBehaviour
{
    EnemyManager enemyManager;
    Animator animator;
    UnitAttack unitAttack;
    UnitOrderManager unitOrderManager;
    UnitsMovement unitsMovement;

    GameObject EnemyToAtaack;


    void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
        animator = GetComponent<Animator>();
        unitsMovement = GetComponent<UnitsMovement>();
        unitOrderManager = GetComponent<UnitOrderManager>();
        unitAttack = GetComponent<UnitAttack>();
    }


    void Update()
    {
        FindNearbyEnemy();
    }

    //check in the enemy list if there in enemy nearby to attack him 
    public void FindNearbyEnemy()
    {
        foreach(GameObject gameObject in enemyManager.enemyUnits)
        {
            if(Vector3.Distance(transform.position, gameObject.transform.position) < unitAttack.ShootingRange)
            {
                if (unitAttack.EnemyToAtaack == null)
                {
                    unitsMovement.enabled = false;
                    unitOrderManager.AttackThisEnemy = gameObject;
                    unitAttack.enabled = true;
                }
            }
        }
    }
}
