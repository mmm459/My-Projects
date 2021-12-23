using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    float speed = 10f;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 1 * Time.deltaTime * speed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GameBoarders")
        {
            Destroy(gameObject);
        }
    }
}
