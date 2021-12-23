using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreasePaddle : MonoBehaviour
{
    public GameObject paddle;
    PaddleMovement onPaddle;
    float scaleY,scaleX;

    // Start is called before the first frame update
    void Start()
    {
        paddle = GameObject.Find("PlayerPaddle");
        onPaddle = FindObjectOfType<PaddleMovement>();
        scaleY = paddle.transform.localScale.y;
        scaleX = paddle.transform.localScale.x;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Paddle")
        {
            if(paddle.transform.localScale.x > 5f && onPaddle.onPaddle == false)
            {
                paddle.transform.localScale = new Vector2(scaleX - 2.5f, scaleY);
            }
            Destroy(gameObject);
        }
    }
}