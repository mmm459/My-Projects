using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMovement : MonoBehaviour
{
    float speed = 0.1f;
    bool isRight = true;

    // Update is called once per frame
    void Update()
    {
        if(isRight)
        {
            transform.Translate(1 * Time.deltaTime * speed, 0, 0);
        }
        else
        {
            transform.Translate(-1 * Time.deltaTime *speed, 0, 0);
        }

        if(transform.position.x >= 6)
        {
            isRight = false;
        }
        else if(transform.position.x <= -6)
        {
            isRight = true;
        }
    }
}
