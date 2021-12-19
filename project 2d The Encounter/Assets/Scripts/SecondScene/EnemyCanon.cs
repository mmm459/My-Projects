using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCanon : MonoBehaviour
{
    public GameObject bullet;
    public GameObject elevator;
    float offset = 2f;
    int shoot;

    private void Start()
    {
        elevator = GameObject.Find("ElevatorPlatform");
        Shoot();
    }

    private void Shoot()
    {
        if (elevator.GetComponent<MagicElevator>().isActive)
        {
            Instantiate(bullet, new Vector2(transform.position.x - offset, transform.position.y + 0.5f), bullet.transform.rotation * Quaternion.Euler(0, 0, 180));
        }
        shoot = Random.Range(1, 5);
        Invoke("Shoot", shoot);
    }
}