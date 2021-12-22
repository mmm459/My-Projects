using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyUnit : MonoBehaviour
{
    NavMeshAgent agent;
    EnemyManager enemyManager;
    Animator animator;
    EnemyAtaccking enemyAtaccking;
 
    public AudioSource DeadSound;

    public int EnemyHealth;
    public Slider HealthBar;

    public bool ExplosiveDeath;
    public GameObject ExlosionEffect;
    [HideInInspector]public Vector3 moveToLocation;


    void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        enemyAtaccking = GetComponent<EnemyAtaccking>();
        enemyManager.enemyUnits.Add(this.gameObject);
        EnemyHealth = 100;
        HealthBar.value = EnemyHealth;
    }


    void Update()
    {
        HealthBar.value = EnemyHealth;
    }


    //check if smoeone shoot me and turn on the EnemyAtaccking Script and give him how shoot me 
    //to attack him back 
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shoot")
        {
            //check that im allready not attacking someone
            if (enemyAtaccking.UnitToAttack == null)
            {
                enemyAtaccking.enabled = true;
                enemyAtaccking.UnitToAttack = other.GetComponent<Transform>().parent.gameObject;
            }
        }
    }

    //calling this function from Shoot script when collide with this object
    public void ReduceHealth(int HealthToReduce)
    {
        EnemyHealth -= HealthToReduce;
        if(EnemyHealth <= 0)
        {
            DeadSound.Play();
            agent.speed = 0;
            enemyManager.enemyUnits.Remove(this.gameObject);
            if (ExplosiveDeath)
            {
                Instantiate(ExlosionEffect, transform.position, Quaternion.identity);
                Destroy(gameObject,1);
            }
        }
    }

    //calling this function from Enemydie Animation
    public void WhenEnemyDie()
    {
        Destroy(gameObject);
    }
         
}
