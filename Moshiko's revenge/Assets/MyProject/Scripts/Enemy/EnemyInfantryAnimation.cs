using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfantryAnimation : MonoBehaviour
{
    Animator animator;
    EnemyUnit enemyUnit;

    void Start()
    {
        enemyUnit = GetComponent<EnemyUnit>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyUnit.EnemyHealth <= 0)
        {
            animator.Play("EnemyInfantry_Die");
        }
    }
}
