using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovementType2 : MonoBehaviour
{
    public GameObject player;
    Rigidbody2D rb;
    enemyManager enemyManager;

    //sound
    AudioSource audioSource;
    public AudioClip Hurt;
    public AudioClip Death;

    int life;
    float fireDis = 7f;
    [SerializeField]
    float dirX;
    float speed = 2.5f;
    bool onFloor = false;
    bool isClose = false;
    float jump;
    float x;
    Animator animator;
    bool died = false;
    bool isLeft;


    public void Awake()
    {
        life = 2;
        x = -1;
        isLeft = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = gameObject.GetComponent<AudioSource>();
        //enemyManager = GameObject.Find("EnemyManager").GetComponent<enemyManager>();
        enemyManager = FindObjectOfType<enemyManager>();
        dirX = transform.localScale.x;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        Invoke("Move", 0.5f);
        jump = Random.Range(0.5f, 4.5f);
        Invoke("Jump", jump);
    }

    void Update()
    {
        if (!died)
        {
            if (player != null)
            {
                //enemy patrolling
                if (!isClose)
                {
                    transform.Translate(x * Time.deltaTime * speed, 0, 0);

                    if (x < 0)
                    {
                        transform.localScale = new Vector2(dirX, transform.localScale.y);
                        isLeft = true;
                    }
                    else
                    {
                        transform.localScale = new Vector2(-dirX, transform.localScale.y);
                        isLeft = false;
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
            }

            //enemy sense player is nearby
            if (player != null)
            {
                if (Vector2.Distance(player.transform.position, transform.position) <= fireDis)
                {
                    isClose = true;
                }
                else
                {
                    isClose = false;
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

        if (collision.gameObject.tag == "Floor")
        {
            onFloor = true;
        }

        if (collision.gameObject.tag == "AmbushBoarder" || collision.gameObject.tag == "Damage")
        {
            x *= -1;
        }
    }

    public void ClearAlert()
    {
        GameObject.Find("Alert").GetComponent<Text>().text = "";
    }

    void OnDestroy()
    {
        enemyManager.WhenEnemyDie();
    }
}