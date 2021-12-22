using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBringHelp : MonoBehaviour
{
    EnemyManager enemyManager;
    EnemyAtaccking enemyAtaccking;


    void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
        enemyAtaccking = GetComponent<EnemyAtaccking>();
    }

    // if im geting shoot send this game object to the enemy manager 
    public void ImUnderAttack()
    {
        enemyManager.ThisEnemyIsUnderAttack(this.gameObject);
    }

    // if im geting shoot send this game object to the enemy manager 
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Shoot")
        {
            ImUnderAttack();
        }
    }
}
