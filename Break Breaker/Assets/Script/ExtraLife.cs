using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLife : MonoBehaviour
{
    PaddleMovement life;

    // Start is called before the first frame update
    void Start()
    {
        life = FindObjectOfType<PaddleMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Paddle")
        {
            if(life.life < 5)
            {
                life.life++;
            }
            Destroy(gameObject);
        }
    }
}
