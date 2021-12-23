using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LargeBall : MonoBehaviour
{
    public GameObject ball;
    PaddleMovement isOnPaddle;
    float sizeX, sizeY;

    // Start is called before the first frame update
    void Start()
    {
        isOnPaddle = FindObjectOfType<PaddleMovement>();
        ball = GameObject.Find("Ball");
        sizeX = ball.transform.localScale.x;
        sizeY = ball.transform.localScale.y;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Paddle")
        {
            if(ball.transform.localScale.x < 0.4f && !isOnPaddle.GetComponent<PaddleMovement>().onPaddle)
            {
                ball.transform.localScale = new Vector2(sizeX + 0.1f, sizeY + 0.1f);
            }
            Destroy(gameObject);
        }
    }
}