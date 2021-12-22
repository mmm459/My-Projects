using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitAttack : MonoBehaviour
{
    EnemyManager enemyManager;
    Animator animator;
    NavMeshAgent agent;
    UnitOrderManager unitOrderManager;
    UpgradesManager upgradesManager;
    UnitsMovement unitsMovement;

    public bool isExplosive;
    public float ShootingRange;
    public int UnitDamge;
    public GameObject EnemyToAtaack;

    public Transform GunEgge;
    
    public GameObject Shoot;

    bool isShooting;

    void Start()
    {
        upgradesManager = FindObjectOfType<UpgradesManager>();
        enemyManager = FindObjectOfType<EnemyManager>();
        unitOrderManager = GetComponent<UnitOrderManager>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        unitsMovement = GetComponent<UnitsMovement>();
        isShooting = false;
    }


    void Update()
    {
        AttackEnemy();
    }


    public void AttackEnemy()
    {
        // takeing the EnemyToAtaack from unitOrderManager
        EnemyToAtaack = unitOrderManager.AttackThisEnemy;

        if(EnemyToAtaack != null)
        {
            //check if im in shooting range stop my unit rotate my to enemy and start animation attack
            if (Vector3.Distance(transform.position, EnemyToAtaack.transform.position) < ShootingRange + upgradesManager.range)
            {
                agent.SetDestination(transform.position);
                animator.SetBool("Attacking", true);
                transform.LookAt(EnemyToAtaack.transform);
            }
            //if im nor in shooting range its start walking animation and set my destination to the enemy 
            else
            {
                animator.SetBool("Attacking", false);
                //agent.SetDestination(EnemyToAtaack.transform.position);
                //this make sure that he will activate walk animation
                unitOrderManager.MoveToLocation = EnemyToAtaack.transform.position;
                unitsMovement.enabled = true;
            }
        }
        else
        {
            this.enabled = false;
        }
    }

    //i call this founction from the animation attack 
    public void SpwanBullet()
    {
        GameObject S = Instantiate(Shoot, GunEgge.position, Quaternion.identity);
        S.gameObject.transform.parent = gameObject.transform;
        //give the bullet the unit damge
        S.GetComponent<Shoot>().BulletDamge = UnitDamge + upgradesManager.attack;
        //storeing enemy to move to and im taking this variable in Shoot script 
        S.GetComponent<Shoot>().EnemyToShoot = EnemyToAtaack;
        //if they unit use explosive so the shoot is explosive too
        if (isExplosive)
        {
            S.GetComponent<Shoot>().Explosive = true;
        }
    }

    //when this script turn off im turnnig the attack animation off 
    void OnDisable()
    {
        animator.SetBool("Attacking", false);
    }
}
