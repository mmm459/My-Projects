using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenceTower : MonoBehaviour
{
    EnemyManager enemyManager;

    public int damge;
    public int ShootingRange;

    public GameObject EnemyToAttack;
    public GameObject Bullet;
    public GameObject Gun;

    bool isShooting;

    void Start()
    {
        enemyManager = FindObjectOfType<EnemyManager>();
        isShooting = true;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForEnemys();
        if (isShooting && EnemyToAttack != null)
        {
            StartCoroutine(Shoot());
            Gun.transform.LookAt(EnemyToAttack.transform.position);
        }
    }

    public void CheckForEnemys()
    {
        foreach(GameObject gameObject in enemyManager.enemyUnits)
        {
            if(Vector3.Distance(transform.position, gameObject.transform.position) < ShootingRange)
            {
                if(EnemyToAttack == null)
                {
                    EnemyToAttack = gameObject;
                }                
            }
        }
    }

    IEnumerator Shoot()
    {
        isShooting = false;
        GameObject S = Instantiate(Bullet, transform.position, Quaternion.identity);
        S.transform.parent = gameObject.transform;
        S.GetComponent<Shoot>().EnemyToShoot = EnemyToAttack;
        S.GetComponent<Shoot>().BulletDamge = damge;
        yield return new WaitForSeconds(1);
        isShooting = true;
    }


}
