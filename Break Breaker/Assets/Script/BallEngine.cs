using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallEngine : MonoBehaviour
{
    Rigidbody2D ballForce;
    Rigidbody2D rb;
    public PaddleMovement paddle;
    public GameObject explosion;
    [HideInInspector]
    public bool hit;
    bool isForce = false;
    [HideInInspector]
    public bool explode = false;
    public bool onFlame = false;
    CircleCollider2D colliderComponent;
    //public CircleCollider2D Trigger;
    public GameObject flame;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ballForce = GetComponent<Rigidbody2D>();
        colliderComponent = GetComponent<CircleCollider2D>();
        hit = false;
        transform.localScale = new Vector2(0.3f, 0.3f);
        flame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && isForce == false)
        {
            ballForce.AddForce(new Vector2(Random.Range(-100, 100),1500));
        }
    }


    public void CanExplode()
    {
        explode = false;
    }

    public void CollisionOn()
    {
        colliderComponent.enabled = false;
        onFlame = true;
        //Trigger.enabled = true;
        flame.SetActive(true);
        Invoke("CollisionOff", 10);
    }

    public void CollisionOff()
    {
        onFlame = false;
        colliderComponent.enabled = true;
        flame.SetActive(false);
        //Trigger.enabled = false;
    }

    public void NewLevel()
    {
        isForce = false;
        rb.velocity = new Vector2(0, 0);
        transform.localScale = new Vector2(0.3f, 0.3f);
        paddle.transform.position = new Vector2(-0.5f, -13.1f);
        transform.position = new Vector2(paddle.transform.position.x, paddle.transform.position.y + 0.5f);
        paddle.onPaddle = true;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Floor")
        {
            isForce = false;
            paddle.GetComponent<PaddleMovement>().isLost = true;
            rb.velocity = new Vector2(0, 0);
            transform.localScale = new Vector2(0.3f, 0.3f);
            paddle.onPaddle = true;
        }
        else if (col.gameObject.tag == "Brick")
        {
            hit = true;
            if (explode)
            {
                Instantiate(explosion, new Vector2(transform.position.x, transform.position.y), explosion.transform.rotation);
                Invoke("CanExplode", 10f);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Paddle")
        {
            isForce = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Laser")
        {
            colliderComponent.enabled = false;
        }
        else if(collision.gameObject.tag == "Paddle")
        {
            colliderComponent.enabled = true;
        }
        else if(collision.gameObject.tag == "GameBoarders")
        {
            colliderComponent.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Laser")
        {
            colliderComponent.enabled = true;
        }

        //check if still on flame
        if (onFlame)
        {
            if (collision.gameObject.tag == "Paddle")
            {
                colliderComponent.enabled = false;
            }
            else if(collision.gameObject.tag == "GameBoarders")
            {
                colliderComponent.enabled = false;
            }
        }
    }
}