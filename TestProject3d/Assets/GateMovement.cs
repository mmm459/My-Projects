using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateMovement : MonoBehaviour
{
    int speed;
    int x;

    // Start is called before the first frame update
    void Start()
    {
        x = 1;
        speed = 10;
        Movement();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        if(Settings.isMoving)
        {
            transform.Translate(0,0, x * speed * Time.deltaTime);
            if(transform.position.z >= 3 || transform.position.z <= -8)
            {
                ChangeMovement();
            }
        }
    }

    public void ChangeMovement()
    {
        x *= -1;
    }
}
