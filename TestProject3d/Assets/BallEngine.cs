using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEngine : MonoBehaviour
{
    public GameObject startPosition;
    public Rigidbody rb;
    Power power;

    public GameObject target;
    Vector3 targetPosition;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("SetPosition", 0.1f);
        power = FindObjectOfType<Power>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    /*void Update()
    {
        targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
    }*/

    public void MoveToTarget()
    {
        //transform.position = Vector3.MoveTowards(transform.position, target.transform.position, power.power * Time.deltaTime);
        targetPosition = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        rb.AddForce(targetPosition * power.power);
    }

    public void Move()
    {
        Invoke("SetPosition", 5);
        power.power = 100;


    }
}
