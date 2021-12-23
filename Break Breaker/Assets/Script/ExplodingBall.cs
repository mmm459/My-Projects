using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBall : MonoBehaviour
{
    GameObject explosion;
    PaddleMovement paddle;

    // Start is called before the first frame update
    void Start()
    {
        explosion = GameObject.Find("Ball");
        paddle = FindObjectOfType<PaddleMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Paddle")
        {
            if (paddle.onPaddle == false || !explosion.GetComponent<BallEngine>().explode)
            {
                explosion.GetComponent<BallEngine>().explode = true;
            }
            Destroy(gameObject);
        }
    }
}
