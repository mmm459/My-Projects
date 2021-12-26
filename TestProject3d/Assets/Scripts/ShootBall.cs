using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootBall : MonoBehaviour
{
    public Rigidbody rb;
    public Text powerText;
    [SerializeField]
    float power;

    public Transform target;

    Manager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<Manager>();
        rb = GetComponent<Rigidbody>();
        power = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        powerText.text = power.ToString();
    }

    public void Shoot()
    {
        power = 100;

        rb.AddForce(-transform.right * power);

        if (target.position.y > 0)
        {
            Debug.Log("up");
            rb.AddForce(transform.up * power * 10, ForceMode.Acceleration);
        }

        if (target.position.y < 0)
        {
            Debug.Log("down");
            rb.AddForce(-transform.up * power * 10, ForceMode.Acceleration);
        }

        if(target.position.x > 0)
        {
            Debug.Log("left");
            rb.AddForce(-transform.forward * power * 10, ForceMode.Acceleration);
        }

        if (target.transform.position.x < 0)
        {
            Debug.Log("right");
            rb.AddForce(transform.forward * power * 10, ForceMode.Acceleration);
        }
        manager.turn = !manager.turn;
        manager.counter--;
        manager.WhosTurn();
    }

    public void PowerShoot()
    {
        Invoke("Shoot", 5);
        if (power < 100)
        {
            power += 1f;
        }
    }
}
