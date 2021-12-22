using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicElevator : MonoBehaviour
{
    public bool isActive = false;
    float speed = 0.8f;
    bool goingUp = true;

    // Update is called once per frame
    void Update()
    {
        if(isActive)
        {
            if(goingUp)
            {
                transform.Translate(0, 1 * Time.deltaTime * speed, 0);
            }
            else
            {
                transform.Translate(0, -1 * Time.deltaTime * speed, 0);
            }
        }

        if(transform.position.y >= 20)
        {
            goingUp = false;
        }
        else if(transform.position.y <= -2)
        {
            goingUp = true;
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isActive = true;
        }
    }
}
