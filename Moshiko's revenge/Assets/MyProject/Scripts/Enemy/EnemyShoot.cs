using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject UnitToShoot;
    public int BulletDamge;
    public GameObject ExplosionEffect;
    public bool Explosive;

    void Start()
    {
        Destroy(gameObject, 1);
    }

    void Update()
    {
        if (UnitToShoot != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, UnitToShoot.transform.position, 100 * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Unit")
        {
            //the bullet damge set when im spwaning this gameobject from EnemyAttacking script
            other.GetComponent<UnitOrderManager>().ReduceHealth(BulletDamge);
            if (Explosive)
            {
                Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
            }
            if(other.GetComponent<UnitOrderManager>().UnitHealth <= 0)
            {
                if(gameObject.transform.parent.tag != "EnemyBuilding")
                {
                    GetComponentInParent<EnemyAtaccking>().UnitToAttack = null;
                }
                else
                {
                    GetComponentInParent<EnemyDefenceTower>().UnitToAttack = null;
                }
                
            }
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Buildings")
        {
            other.GetComponent<BuildingsHealth>().BuildingTakeingDamge(BulletDamge);
            if (Explosive)
            {
                Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
            }
        }
    }
}
