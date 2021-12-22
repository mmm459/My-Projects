using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefenceTower : MonoBehaviour
{
    ControlingSystem controlingSystem;

    public int damge;
    public int ShootingRange;

    public GameObject UnitToAttack;
    public GameObject Bullet;
    public GameObject Gun;

    bool isShooting;

    void Start()
    {
        controlingSystem = FindObjectOfType<ControlingSystem>();
        isShooting = true;
    }

    // Update is called once per frame
    void Update()
    {
        CheckForUnit();
        if (isShooting && UnitToAttack != null)
        {
            StartCoroutine(Shoot());
            Gun.transform.LookAt(UnitToAttack.transform.position);
        }
    }

    public void CheckForUnit()
    {
        foreach (GameObject gameObject in controlingSystem.UnitsInTheGame)
        {
            if (Vector3.Distance(transform.position, gameObject.transform.position) < ShootingRange)
            {
                if (UnitToAttack == null)
                {
                    UnitToAttack = gameObject;
                }
            }
        }
    }

    IEnumerator Shoot()
    {
        isShooting = false;
        GameObject S = Instantiate(Bullet, transform.position, Quaternion.identity);
        S.transform.parent = gameObject.transform;
        S.GetComponent<EnemyShoot>().UnitToShoot = UnitToAttack;
        S.GetComponent<EnemyShoot>().BulletDamge = damge;
        yield return new WaitForSeconds(1);
        isShooting = true;
    }
}
