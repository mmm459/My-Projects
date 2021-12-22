using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element1 : MonoBehaviour
{
    public GameObject player;
    public GameObject rock;
    Rigidbody2D rb;
    Animator animator;
    enemyManager enemyManager;

    //sound
    AudioSource audioSource;
    public AudioClip Hurt;
    public AudioClip Death;
    public AudioClip fire;

    int life;
    float Distance = 7f;
    float dirX;
    bool isClose = false;
    bool died = false;
    int offset = 1;
    bool canFire = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
        enemyManager = FindObjectOfType<enemyManager>();
        dirX = transform.localScale.x;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Awake()
    {
        life = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (!died)
        {
            //enemy sense player is nearby
            if (player != null)
            {
                if (Vector2.Distance(player.transform.position, transform.position) <= Distance)
                {
                    isClose = true;
                }
                else
                {
                    isClose = false;
                }

                //if player close, enemy shoot
                if (isClose)
                {
                    animator.SetBool("isWalking", false);
                    animator.SetBool("isIdle", true);
                    if (canFire)
                    {
                        audioSource.PlayOneShot(fire);

                        if (transform.position.x > player.transform.position.x)
                        {
                            transform.localScale = new Vector2(dirX, transform.localScale.y);
                            animator.SetBool("isAttacking", true);
                            Instantiate(rock, new Vector2(transform.position.x - Random.Range(1, 3), transform.position.y), rock.transform.rotation * Quaternion.Euler(0, 0, 180));
                        }
                        else
                        {
                            transform.localScale = new Vector2(-dirX, transform.localScale.y);
                            animator.SetBool("isAttacking", true);
                            Instantiate(rock, new Vector2(transform.position.x + Random.Range(1,3), transform.position.y), rock.transform.rotation * Quaternion.Euler(0, 0, 0));
                        }
                        animator.SetBool("isAttacking", false);
                        canFire = false;
                        Invoke("CanFireNow", 2);
                    }
                }
            }
        }
    }

    private void CanFireNow()
    {
        canFire = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Shurikans")
        {
            Destroy(collision.gameObject);
            life--;
            if (life > 0)
            {
                audioSource.PlayOneShot(Hurt);
            }

            if (life <= 0)
            {
                animator.SetBool("isDead", true);
                animator.SetTrigger("Die");

                if (animator.GetBool("isDead") && died == false)
                {
                    CancelInvoke();
                    audioSource.PlayOneShot(Death);
                    Destroy(gameObject.GetComponent<Rigidbody2D>());
                    Destroy(gameObject.GetComponent<Collider2D>());
                    Destroy(gameObject, 2);
                    died = true;
                }
            }
        }

        if (collision.gameObject.tag == "Bombs")
        {
            Destroy(collision.gameObject);
            life -= 2;
            if (life > 0)
            {
                audioSource.PlayOneShot(Hurt);
            }

            if (life <= 0)
            {
                animator.SetBool("isDead", true);
                animator.SetTrigger("Die");

                if (animator.GetBool("isDead") && died == false)
                {
                    CancelInvoke();
                    audioSource.PlayOneShot(Death);
                    Destroy(gameObject.GetComponent<Rigidbody2D>());
                    Destroy(gameObject.GetComponent<Collider2D>());
                    Destroy(gameObject, 2);
                    died = true;
                }
            }
        }
    }
}
