using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScorio1 : MonoBehaviour
{
    public GameObject scorpio1;
    public GameObject elevator;

    private void Start()
    {
        elevator = GameObject.Find("ElevatorPlatform");
        Shoot();
    }

    private void Shoot()
    {
        if (elevator.GetComponent<MagicElevator>().isActive)
        {
            Instantiate(scorpio1, new Vector2(transform.position.x, transform.position.y), scorpio1.transform.rotation);
        }
        Invoke("Shoot", Random.Range(10, 15));
    }
}
