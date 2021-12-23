using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseBall : MonoBehaviour
{
    public GameObject ball;
    PaddleMovement isOnPaddle;
    float sizeX, sizeY;

    private void Start()
    {
        isOnPaddle = FindObjectOfType<PaddleMovement>();
        ball = GameObject.Find("Ball");
        sizeX = ball.transform.localScale.x;
        sizeY = ball.transform.localScale.y;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "Paddle")
        {
            if(ball.transform.localScale.x > 0.2f && !isOnPaddle.onPaddle)
            {
                ball.transform.localScale = new Vector2(sizeX - 0.1f, sizeY - 0.1f);
            }
            Destroy(gameObject);
        }
    }
}
