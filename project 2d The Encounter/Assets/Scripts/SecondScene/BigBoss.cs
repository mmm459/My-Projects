using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BigBoss : MonoBehaviour
{
    public GameObject player;
    public GameObject rock;
    public GameObject Bullets;
    public GameObject canon;
    Animator animator;
    enemyManager enemyManager;

    //sound
    AudioSource audioSource;
    public AudioClip Hurt;
    public AudioClip Death;
    public AudioClip fire;

    //stats
    public int life;
    int offset = 2;
    int timeToFire = 2;
    float dirX;
    float speed = 5f;
    bool isClose = true;
    bool died = false;
    bool canFire = true;
    bool canShoot = true;
    bool action1 = true;//move to position
    bool action2 = false;//shoot bullets
    bool action3 = true;
    bool oneLastTime = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
        enemyManager = FindObjectOfType<enemyManager>();
        dirX = transform.localScale.x;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Awake()
    {
        life = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 40 && life >= 36 || life <= 10 && life >= 6)
        {
            if(life <= 10)
            {
                if(oneLastTime)
                {
                    action1 = true;
                    action2 = true;
                    oneLastTime = false;
                }
            }

            if (action1)
            {
                //stop throwing rocks while shoot bullets
                timeToFire = 8;
                if (transform.position.y >= 30)
                {
                    transform.Translate(0, -1 * Time.deltaTime * speed, 0);
                }
                else if (transform.position.x <= 9)
                {
                    transform.Translate(1 * Time.deltaTime * speed, 0, 0);
                }
            }

            if (transform.position.y > 28 && transform.position.x > 8)
            {
                if (action3)
                {
                    Instantiate(canon, new Vector2(player.transform.position.x, 48), canon.transform.rotation);
                    action3 = false;
                }
                action2 = true;
                //waiting 2 sec
                Invoke("Action", 2);
            }

            //getting back to original position
            if (!action1)
            {
                if (transform.position.y <= 33)
                {
                    transform.Translate(0, 1 * Time.deltaTime * speed, 0);
                }
                else if (transform.position.x >= -11)
                {
                    transform.Translate(-1 * Time.deltaTime * speed, 0, 0);
                }
            }
        }

        //if player close, enemy shoot
        if (isClose)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isIdle", true);
            if (canFire)
            {
                audioSource.pitch = Random.Range(0.4f, 0.8f);
                audioSource.PlayOneShot(fire);

                //look left to the player
                if (transform.position.x > player.transform.position.x)
                {
                    transform.localScale = new Vector2(dirX, transform.localScale.y);
                    animator.SetBool("isAttacking", true);
                    Instantiate(rock, new Vector2(transform.position.x - Random.Range(1,8), transform.position.y), rock.transform.rotation * Quaternion.Euler(0, 0, 180));
                }
                else//look right to the player
                {
                    transform.localScale = new Vector2(-dirX, transform.localScale.y);
                    animator.SetBool("isAttacking", true);
                    Instantiate(rock, new Vector2(transform.position.x + Random.Range(1, 8), transform.position.y), rock.transform.rotation * Quaternion.Euler(0, 0, 0));
                }
                animator.SetBool("isAttacking", false);
                canFire = false;
                Invoke("CanFireNow", timeToFire);
            }

            //action2 is about to shoot the bullets without throwing rocks
            if (action2)
            {
                transform.localScale = new Vector2(-dirX, transform.localScale.y);
                animator.SetBool("isAttacking", true);
                if (canShoot)
                {
                    int i = 0;
                    while (i < 5)
                    {
                        Instantiate(Bullets, new Vector2(transform.position.x + offset, transform.position.y), Bullets.transform.rotation * Quaternion.Euler(0, 0, 0));
                        i++;
                    }
                    animator.SetBool("isAttacking", false);
                    canShoot = false;
                    action2 = false;
                    Invoke("CanShootNow", 0.2f);
                }
            }
            else
            {
                timeToFire = 2;
            }
        }
    }


    private void Action()
    {
        action1 = false;
    }

    private void CanFireNow()
    {
        canFire = true;
    }

    private void CanShootNow()
    {
        canShoot = true;
        if(action3)
        {
            canFire = true;
            action3 = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Shurikans")
        {
            Destroy(collision.gameObject);
            life--;
            if (life > 0)
            {
                audioSource.pitch = Random.Range(0.4f, 0.8f);
                audioSource.PlayOneShot(Hurt);
            }
            else if (life <= 0)
            {
                animator.SetBool("isDead", true);
                animator.SetTrigger("Die");

                if (animator.GetBool("isDead") && died == false)
                {
                    CancelInvoke();
                    audioSource.pitch = Random.Range(0.4f, 0.8f);
                    audioSource.PlayOneShot(Death);
                    SceneManager.LoadScene("YouWin");
                    Destroy(gameObject.GetComponent<Rigidbody2D>());
                    Destroy(gameObject.GetComponent<Collider2D>());
                    Destroy(gameObject, 2);
                    died = true;
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bombs")
        {
            Destroy(collision.gameObject);
            life -= 2;

            if (life > 0)
            {
                audioSource.pitch = Random.Range(0.4f, 0.8f);
                audioSource.PlayOneShot(Hurt);
            }
            else if (life <= 0)
            {
                animator.SetBool("isDead", true);
                animator.SetTrigger("Die");

                if (animator.GetBool("isDead") && died == false)
                {
                    CancelInvoke();
                    audioSource.pitch = Random.Range(0.4f, 0.8f);
                    audioSource.PlayOneShot(Death);
                    SceneManager.LoadScene("YouWin");
                    Destroy(gameObject.GetComponent<Collider2D>());
                    Destroy(gameObject, 2);
                    died = true;
                }
            }
        }
    }
}