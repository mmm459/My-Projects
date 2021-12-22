using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAtaccking : MonoBehaviour
{
    Animator animator;
    NavMeshAgent agent;

    public GameObject UnitToAttack;

    public bool isExplosive;

    public float ShootingRange;

    public int EnemyDamge;
    public Transform GunEgge;
    public GameObject EnemyShoot;
    public GameObject MuzzleEffect;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        CheckIfDoneToAttack();
        if (UnitToAttack != null)
        {
            if (Vector3.Distance(transform.position, UnitToAttack.transform.position) < ShootingRange)
            {
                agent.SetDestination(transform.position);
                transform.LookAt(UnitToAttack.transform);
                animator.SetBool("isWalking", false);
                animator.SetBool("isAttacking", true);
            }
            else
            {
                agent.SetDestination(UnitToAttack.transform.position);
                animator.SetBool("isWalking", true);
                animator.SetBool("isAttacking", false);
            }
        }

    }

    //call this script from the enemy attack animation 
    public void SpwanBullet()
    {
        GameObject S = Instantiate(EnemyShoot, GunEgge.position, Quaternion.identity);
        S.gameObject.transform.parent = gameObject.transform;
        S.GetComponent<EnemyShoot>().BulletDamge = EnemyDamge;
        S.GetComponent<EnemyShoot>().UnitToShoot = UnitToAttack;
        if (isExplosive)
        {
            S.GetComponent<EnemyShoot>().Explosive = true;
        }
    }

    //call this script from the enemy attack animation 
    public IEnumerator ActiveMuzzle()
    {
        MuzzleEffect.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        MuzzleEffect.SetActive(false);
    }

    public void CheckIfDoneToAttack()
    {
        //if im not storeing ant unit ti attack close animations and this script 
        if(UnitToAttack == null)
        {
            
            animator.SetBool("isAttacking", false);
            animator.SetBool("isWalking", false);
            animator.Play("EnemyInfantry_Idle");
            agent.SetDestination(transform.position);
            this.enabled = false;
        }
    }
}
