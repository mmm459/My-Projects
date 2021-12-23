using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [HideInInspector]
    public float speed = 25f;
    public BallEngine ball;
    public GameObject laser;
    [HideInInspector]
    public bool onPaddle = true;
    [HideInInspector]
    public bool isLost = false;
    [HideInInspector]
    public bool shoot = false;
    bool canShoot = true, reset = true;
    public int life = 3;

    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<BallEngine>();
    }

    // Update is called once per frame
    void Update()
    {
        //when ball touch the floor
        if(isLost)
        {
            life--;
            if(life == 0)
            {
                Destroy(ball.gameObject);
            }
            transform.position = new Vector2(-0.5f, -13.1f);
            ball.transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
            isLost = false;
            onPaddle = true;
        }

        //when ball is on the paddle
        if(ball != null)
        {
            if (onPaddle)
            {
                ball.transform.SetParent(this.transform);
            }
            else
            {
                ball.transform.SetParent(null);
                if(shoot && canShoot && Input.GetKeyDown(KeyCode.Space))
                {
                    Instantiate(laser, new Vector2(transform.position.x, transform.position.y + 0.5f), laser.transform.rotation);
                    canShoot = false;
                    Invoke("CanShoot", 1);
                    if(reset)
                    {
                        reset = false;
                        Invoke("StopShoot", 10);
                    }
                }
            }
        }

        //paddle movement
        if (Input.GetKey(KeyCode.D) == true || Input.GetKey(KeyCode.RightArrow) == true)
        {
            transform.Translate(1 * Time.deltaTime * speed, 0, 0);
        }
        else if(Input.GetKey(KeyCode.A) == true || Input.GetKey(KeyCode.LeftArrow) == true)
        {
            transform.Translate(-1 * Time.deltaTime * speed, 0, 0);
        }
    }

    public void CanShoot()
    {
        canShoot = true;
    }

    public void StopShoot()
    {
        shoot = false;
        reset = true;
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            onPaddle = false;
        }
    }
}