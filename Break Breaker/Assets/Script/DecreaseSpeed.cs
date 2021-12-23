using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecreaseSpeed : MonoBehaviour
{
    public GameObject paddle;

    // Start is called before the first frame update
    void Start()
    {
        paddle = GameObject.Find("PlayerPaddle");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Paddle")
        {
            if(paddle.GetComponent<PaddleMovement>().speed > 20)
            {
                paddle.GetComponent<PaddleMovement>().speed -= 5f;
            }
            Destroy(gameObject);
        }
    }
}