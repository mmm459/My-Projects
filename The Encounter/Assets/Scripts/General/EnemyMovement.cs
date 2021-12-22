using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb;

    //sound
    AudioSource audioSource;
    public AudioClip Hurt;
    public AudioClip Death;

    float Distance = 7f;
    float dirX;
    float speed = 2.5f;
    [SerializeField]bool onFloor = false;
    [SerializeField]bool isClose = false;
    [SerializeField]bool isLeft;
    [SerializeField]
    float jump;
    int life = 2;
    Animator animator;
    bool died =  false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        dirX = transform.localScale.x;
        player = GameObject.FindGameObjectWithTag("Player");
        Invoke("Move", 2f);
        jump = Random.Range(0.5f, 4.5f);
        Invoke("Jump", jump);
    }

    void Update()
    {
        if (animator.GetBool("isDead") && died == false)
        {
            CancelInvoke();
            Destroy(gameObject.GetComponent<Rigidbody2D>());
            Destroy(gameObject.GetComponent<Collider2D>());
            Invoke("destroyObject", 5);
            died = true;
        }
        else if (!animator.GetBool("isDead"))
        {
            if (player != null)
            {
                //patrolling
                if (!isClose)
                {
                    if (isLeft)
                    {
                        transform.localScale = new Vector2(dirX, transform.localScale.y);
                        transform.Translate(-1 * Time.deltaTime * speed, 0, 0);

                    }
                    else
                    {
                        transform.localScale = new Vector2(-dirX, transform.localScale.y);
                        transform.Translate(1 * Time.deltaTime * speed, 0, 0);
                    }
                }

                //if player close, enemy follow
                if (isClose)
                {
                    if (transform.position.x > player.transform.position.x)
                    {
                        transform.localScale = new Vector2(dirX, transform.localScale.y);
                        transform.Translate(-1 * Time.deltaTime * speed, 0, 0);
                        isLeft = true;
                    }
                    else
                    {
                        transform.localScale = new Vector2(-dirX, transform.localScale.y);
                        transform.Translate(1 * Time.deltaTime * speed, 0, 0);
                        isLeft = false;
                    }
                }

                //enemy sense player is nearby
                if (Vector2.Distance(player.transform.position, transform.position) <= Distance)
                {
                    isClose = true;
                    onFloor = true;
                }
                else
                {
                    isClose = false;
                    onFloor = true;
                }
            }
        }
    }

    private void Jump()
    {
        if (isLeft && onFloor)
        {
            rb.AddForce(new Vector2(-100, 200));
            onFloor = false;
        }
        else if (!isLeft && onFloor)
        {
            rb.AddForce(new Vector2(100, 200));
            onFloor = false;
        }

        jump = Random.Range(0.5f, 4.5f);
        Invoke("Jump", jump);
    }

    private void Move()
    {
        if(isLeft)
        {
            isLeft = false;
        }
        else
        {
            isLeft = true;
        }
        Invoke("Move", 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Shurikans")
        {
            life--;
            if (life > 0)
            {
                audioSource.PlayOneShot(Hurt);
            }
            else if (life == 0)
            {
                audioSource.PlayOneShot(Death);
                animator.SetBool("isDead", true);
                animator.SetTrigger("Die");
            }
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Floor")
        {
            onFloor = true;
        }

        if(collision.gameObject.tag == "Explosion")
        {
            life -= 2;
            if (life > 0)
            {
                audioSource.PlayOneShot(Hurt);
            }
            else if (life <= 0)
            {
                audioSource.PlayOneShot(Death);
                animator.SetBool("isDead", true);
                animator.SetTrigger("Die");
            }
            Destroy(collision.gameObject);
        }
    }

    public void destroyObject()
    {
        Destroy(gameObject);
    }
}