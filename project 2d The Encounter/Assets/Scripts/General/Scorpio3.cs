using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorpio3 : MonoBehaviour
{
    GameObject player;
    Rigidbody2D rb;

    //sound
    AudioSource audioSource;
    public AudioClip Hurt;
    public AudioClip Death;

    float dirX;
    float speed = 2.5f;
    [SerializeField] bool isLeft;
    [SerializeField] float x = -1f;
    bool died = false;
    int life = 2;
    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        dirX = transform.localScale.x;
        player = GameObject.FindGameObjectWithTag("Player");
        Invoke("Move", 5f);
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
                    if (x == -1)
                    {
                        isLeft = true;
                        transform.localScale = new Vector2(dirX, transform.localScale.y);
                        transform.Translate(x * Time.deltaTime * speed, 0, 0);

                    }
                    else
                    {
                        isLeft = false;
                        transform.localScale = new Vector2(-dirX, transform.localScale.y);
                        transform.Translate(x * Time.deltaTime * speed, 0, 0);
                    }
            }
        }
    }

    private void Move()
    {
        x *= -1;
        if (isLeft)
        {
            transform.localScale = new Vector2(-dirX, transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(dirX, transform.localScale.y);
        }
        Invoke("Move", 5);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Shurikans")
        {
            life--;
            if (life > 0) audioSource.PlayOneShot(Hurt);
            else if (life == 0)
            {
                audioSource.PlayOneShot(Death);
                animator.SetBool("isDead", true);
                animator.SetTrigger("Die");
            }
            Destroy(collision.gameObject);
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        x *= -1;
    }
}