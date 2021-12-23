using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameCircle : MonoBehaviour
{
    public GameObject flame;
    PaddleMovement paddle;
    BallEngine ballEngine;

    // Start is called before the first frame update
    void Start()
    {
        paddle = FindObjectOfType<PaddleMovement>();
        flame = GameObject.Find("Ball");
        ballEngine = FindObjectOfType<BallEngine>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Paddle")
        {
            if(paddle.onPaddle == false)
            {
                ballEngine.CollisionOn();
            }
            Destroy(gameObject);
        }
    }
}
