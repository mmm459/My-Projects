using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject EnemyToShoot;
    public int BulletDamge;
    public GameObject ExplosionEffect;
    public bool Explosive;


    private void Start()
    {
        Destroy(gameObject, 1.5f);
    }

    void Update()
    {
        //moveing the shoot towards the enemy 
        if(EnemyToShoot != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, EnemyToShoot.transform.position, 75 * Time.deltaTime);
        } 
    }

    //checking how to deal damge with
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            //check that the unit will not keep shot dead enemy 
            if(other.GetComponent<EnemyUnit>().EnemyHealth <= 0)
            {
                if(gameObject.transform.parent.tag != "Buildings")
                {
                    GetComponentInParent<UnitOrderManager>().AttackThisEnemy = null;
                    GetComponentInParent<UnitAttack>().EnemyToAtaack = null;
                }
                else
                {
                    GetComponentInParent<DefenceTower>().EnemyToAttack = null;
                }
            }
            else
            {
                other.GetComponent<EnemyUnit>().ReduceHealth(BulletDamge);
            }
            //if the shoot is explosive spwan explosion effect
            if (Explosive)
            {
                Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
        else if(other.gameObject.tag == "EnemyBuilding")
        {
            other.GetComponent<EnemyBuilding>().BuildingTakeingDamge(BulletDamge);
            if (Explosive)
            {
                Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
            }
        }
    }

}
