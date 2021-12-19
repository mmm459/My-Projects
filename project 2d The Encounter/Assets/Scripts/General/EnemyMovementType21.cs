using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementType21 : MonoBehaviour
{
    public GameObject player;
    public GameObject fire;
    Rigidbody2D rb;
    enemyManager enemyManager;
    Animator animator;

    //sound
    AudioSource audioSource;
    public AudioClip Hurt;
    public AudioClip Death;
    public AudioClip Fire;

    int life;
    float Distance = 7f;
    float dirX;
    float speed = 2.5f;
    bool isClose = false;
    [SerializeField]
    float x;
    bool died = false;
    int offset = 1;
    bool canFire = true;

    public void Awake()
    {
        life = 2;
        x = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
        enemyManager = FindObjectOfType<enemyManager>();
        dirX = transform.localScale.x;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(SetSpeed2());
    }

    // Update is called once per frame
    void Update()
    {
        if(!died)
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
            
                //enemy patrolling
                if (!isClose && !animator.GetBool("isIdle"))
                {
                    animator.SetBool("isWalking", true);

                    if (x < 0)
                    {
                        transform.localScale = new Vector2(dirX, transform.localScale.y);
                    }
                    else
                    {
                        transform.localScale = new Vector2(-dirX, transform.localScale.y);
                    }
                    transform.Translate(x * Time.deltaTime * speed, 0, 0);
                }

                //if player close, enemy shoot
                if (isClose)
                {
                    animator.SetBool("isWalking", false);
                    animator.SetBool("isIdle", true);
                    if(canFire)
                    {
                        audioSource.PlayOneShot(Fire);

                        if (transform.position.x > player.transform.position.x)
                        {
                            transform.localScale = new Vector2(dirX, transform.localScale.y);
                            animator.SetBool("isAttacking", true);
                            Instantiate(fire, new Vector2(transform.position.x - offset, transform.position.y), fire.transform.rotation * Quaternion.Euler(0, 0, 180));
                        }
                        else
                        {
                            transform.localScale = new Vector2(-dirX, transform.localScale.y);
                            animator.SetBool("isAttacking", true);
                            Instantiate(fire, new Vector2(transform.position.x + offset, transform.position.y), fire.transform.rotation * Quaternion.Euler(0, 0, 0));
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

    //every few seconds change his mode from walking to idle and opposite
    IEnumerator SetSpeed2()
    {
        //need to think about a condition the move left or right and if not close to the edge of the floor
        x = 1;
        animator.SetBool("isIdle", false);
        animator.SetBool("isWalking", true);
        yield return new WaitForSeconds(Random.Range(3, 6));
        x = 0;
        animator.SetBool("isWalking", false);
        animator.SetBool("isIdle", true);
        yield return new WaitForSeconds(Random.Range(2, 5));
        x = -1;
        animator.SetBool("isIdle", false);
        animator.SetBool("isWalking", true);
        yield return new WaitForSeconds(Random.Range(3, 6));
        x = 0;
        animator.SetBool("isWalking", false);
        animator.SetBool("isIdle", true);
        yield return new WaitForSeconds(Random.Range(3, 6));
        StartCoroutine(SetSpeed2());
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Shurikans")
        {
            Destroy(collision.gameObject);
            life--;
            if (life > 0)
            {
                audioSource.PlayOneShot(Hurt);
            }

            if(life == 0)
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

        if(collision.gameObject.tag == "Explosion")
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        x *= -1;
    }
}
