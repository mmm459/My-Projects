using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [HideInInspector]
    public float x;
    public bool startswithfire = false;
    bool canFire = false;
    bool canThrow = false;
    float speed;
    float scale;
    [SerializeField]
    public bool canJump;
    [SerializeField]
    int jumpForce;
    float offset; //for distance from player
    float fireRate = 1.4f;
    bool isDead;
    bool firstTime = true;
    bool doubleShoot = false;

    Animator animator; // to play animations
    Rigidbody2D playerRB; //for jumping
    public GameObject shurikan;
    public GameObject bomb;
    public GameObject Playercamera;

    //sound
    public AudioSource audioSource;
    public AudioClip shurikanPickup;
    public AudioClip shurikanShoot;
    public AudioClip hurtSound;
    public AudioClip bombThrowing;

    //Alert box
    public Text Alert;

    // Health
    public Image HP1;
    public Image HP2;
    public Image HP3;

    public Image HPFull;
    public Image HPEmpty;

    [HideInInspector]
    public int health;
    int maxHealth;
    public int startHealth = 3;
    bool invulnerable;
    bool flickering;
    public Transform Spawnpoint;

    //boss health

    public Image bossHealth;
    public Image bossMaxHealth;

    void Start()
    {
        bossHealth = GameObject.Find("bossHealth").GetComponent<Image>();
        bossMaxHealth = GameObject.Find("bossMaxHealth").GetComponent<Image>();

        //boss scene
        bossHealth.enabled = false;
        bossMaxHealth.enabled = false;

        Alert.text = "";
        x = 0;
        speed = 5;
        jumpForce = 400;
        offset = 1;
        canJump = true;
        canFire = startswithfire;
        isDead = false;
        scale = transform.localScale.x;

        Playercamera = GameObject.Find("Main Camera");
        animator = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody2D>();

        // health
        health = startHealth;
        maxHealth = 3;
        invulnerable = false;
    }

    void Update()
    {
        if (Playercamera.GetComponent<CameraPosition>().follow)
        {
            if (isDead)
            {
                Invoke("Die", 2);
            }

            if (!animator.GetBool("isDead")) // can only do stuff if isn't dead
            {
                //  ---------- Movement Input ----------
                x = Input.GetAxis("Horizontal")/* * Time.deltaTime * speed*/;
                transform.Translate(x * Time.deltaTime * speed, 0, 0);

                // Jump
                if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && canJump)
                {
                    animator.SetBool("isRunning", false);
                    animator.SetBool("isJumping", true);
                    playerRB.AddForce(new Vector2(0, jumpForce));
                    canJump = false;
                }

                //  ---------- Animations ----------

                // Idle
                if (x == 0 && !animator.GetBool("isJumping"))
                {
                    animator.SetBool("isRunning", false);
                }

                // Right
                if (x > 0)
                {
                    transform.localScale = new Vector3(scale, scale, scale);

                    // Run Right
                    if (!animator.GetBool("isJumping"))
                    {
                        animator.SetBool("isRunning", true);
                    }

                }
                // Left
                if (x < 0)
                {
                    transform.localScale = new Vector3(-scale, scale, scale);

                    // Run Left
                    if (!animator.GetBool("isJumping"))
                    {
                        animator.SetBool("isRunning", true);
                    }
                }

                //shoot
                if (Input.GetKey(KeyCode.Space))
                {
                    if (canFire)
                    {
                        audioSource.PlayOneShot(shurikanShoot);
                        animator.SetBool("isThrowing", true);

                        //shooting when idle
                        if (transform.localScale.x > 0 && animator.GetBool("isRunning") == false && animator.GetBool("isJumping") == false)
                        {
                            //right
                            Shoot(true);
                        }
                        else if (transform.localScale.x < 0 && animator.GetBool("isRunning") == false && animator.GetBool("isJumping") == false)
                        {
                            //left
                            Shoot(false);
                        }
                        //shooting when running
                        else if (transform.localScale.x > 0 && animator.GetBool("isRunning") == true && animator.GetBool("isJumping") == false)
                        {
                            //right
                            Shoot(true);
                        }
                        else if (transform.localScale.x < 0 && animator.GetBool("isRunning") == true && animator.GetBool("isJumping") == false)
                        {
                            //left
                            Shoot(false);
                        }//shooting when Jumping
                        else if (transform.localScale.x > 0 && animator.GetBool("isRunning") == false && animator.GetBool("isJumping") == true)
                        {
                            //right
                            Shoot(true);
                        }
                        else if (transform.localScale.x < 0 && animator.GetBool("isRunning") == false && animator.GetBool("isJumping") == true)
                        {
                            //left
                            Shoot(false);
                        }

                        canFire = false;
                        Invoke("CanThrowShurikan", fireRate);
                        Invoke("FinishThrowAnim", 0.3f);
                    }
                }

                if (Input.GetKey(KeyCode.B))
                {
                    if (canThrow)
                    {
                        audioSource.PlayOneShot(bombThrowing);
                        animator.SetBool("isThrowing", true);

                        //throwing when idle
                        if (transform.localScale.x > 0 && animator.GetBool("isRunning") == false && animator.GetBool("isJumping") == false)
                        {
                            //right
                            Throw(true);
                        }
                        else if (transform.localScale.x < 0 && animator.GetBool("isRunning") == false && animator.GetBool("isJumping") == false)
                        {
                            //left
                            Throw(false);
                        }
                        //throwing when running
                        else if (transform.localScale.x > 0 && animator.GetBool("isRunning") == true && animator.GetBool("isJumping") == false)
                        {
                            //right
                            Throw(true);
                        }
                        else if (transform.localScale.x < 0 && animator.GetBool("isRunning") == true && animator.GetBool("isJumping") == false)
                        {
                            //left
                            Throw(false);
                        }//throwing when Jumping
                        else if (transform.localScale.x > 0 && animator.GetBool("isRunning") == false && animator.GetBool("isJumping") == true)
                        {
                            //right
                            Throw(true);
                        }
                        else if (transform.localScale.x < 0 && animator.GetBool("isRunning") == false && animator.GetBool("isJumping") == true)
                        {
                            //left
                            Throw(false);
                        }

                        canThrow = false;
                        Invoke("CanThrowBomb", 10f);
                        Invoke("FinishThrowAnim", 0.3f);
                    }
                }
            }
        }

        Health();

        Invulnerable();
        
        Flickering();
    }

    private void Health()
    {
        // edit heart sprites
        if (health == 0)
        {
            HP1.GetComponent<Image>().sprite = HPEmpty.GetComponent<Image>().sprite;
            HP2.GetComponent<Image>().sprite = HPEmpty.GetComponent<Image>().sprite;
            HP3.GetComponent<Image>().sprite = HPEmpty.GetComponent<Image>().sprite;
        }
        else if (health == 1)
        {
            HP1.GetComponent<Image>().sprite = HPFull.GetComponent<Image>().sprite;
            HP2.GetComponent<Image>().sprite = HPEmpty.GetComponent<Image>().sprite;
            HP3.GetComponent<Image>().sprite = HPEmpty.GetComponent<Image>().sprite;
        }
        else if (health == 2)
        {
            HP1.GetComponent<Image>().sprite = HPFull.GetComponent<Image>().sprite;
            HP2.GetComponent<Image>().sprite = HPFull.GetComponent<Image>().sprite;
            HP3.GetComponent<Image>().sprite = HPEmpty.GetComponent<Image>().sprite;
        }
        else if (health == 3)
        {
            HP1.GetComponent<Image>().sprite = HPFull.GetComponent<Image>().sprite;
            HP2.GetComponent<Image>().sprite = HPFull.GetComponent<Image>().sprite;
            HP3.GetComponent<Image>().sprite = HPFull.GetComponent<Image>().sprite;
        }
    }

    private void Flickering()
    {
        if (flickering)
        {
            Color color;
            color = gameObject.GetComponent<SpriteRenderer>().color;
            color.a = 0.5f;
            gameObject.GetComponent<SpriteRenderer>().color = color;
        }
        else
        {
            Color color;
            color = gameObject.GetComponent<SpriteRenderer>().color;
            color.a = 1;
            gameObject.GetComponent<SpriteRenderer>().color = color;
        }
    }

    private void Invulnerable()
    {
        if (invulnerable)
        {
            flickering = true;
            Invoke("Vulnerable", 2);
        }
    }

    //end scene
    public void Die()
    {
        SceneManager.LoadScene("GameOver");
    }

    //shooting right or left
    public void Shoot(bool right)
    {
        if (right)
        {
            Instantiate(shurikan, new Vector2(transform.position.x + offset, transform.position.y), shurikan.transform.rotation * Quaternion.Euler(0, 0, 0));
        }
        else//Left
        {
            Instantiate(shurikan, new Vector2(transform.position.x - offset, transform.position.y), shurikan.transform.rotation * Quaternion.Euler(0, 0, 180));
        }
        //if have double shoot ability then shot another at the same time above the original
        if (doubleShoot)
        {
            if (right)
            {
                Instantiate(shurikan, new Vector2(transform.position.x + offset, transform.position.y + offset), shurikan.transform.rotation * Quaternion.Euler(0, 0, 0));
            }
            else//Left
            {
                Instantiate(shurikan, new Vector2(transform.position.x - offset, transform.position.y + offset), shurikan.transform.rotation * Quaternion.Euler(0, 0, 180));
            }
        }
    }

    public void Throw(bool right)
    {
        if (right)
        {
            Instantiate(bomb, new Vector2(transform.position.x + offset, transform.position.y), bomb.transform.rotation * Quaternion.Euler(0, 0, 0));
        }
        else//Left
        {
            Instantiate(bomb, new Vector2(transform.position.x - offset, transform.position.y), bomb.transform.rotation * Quaternion.Euler(0, 0, 180));
        }
    }

    //weapon fire rate
    private void CanThrowShurikan()
    {
        canFire = true;
    }

    private void CanThrowBomb()
    {
        canThrow = true;
    }

    //animation
    private void FinishThrowAnim()
    {
        animator.SetBool("isThrowing", false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Damage" && !invulnerable)
        {
            DamagePlayer();
        }
        else if (collision.gameObject.tag == "Bullet")
        {
            if (!invulnerable)
            {
                DamagePlayer();
                Destroy(collision.gameObject);
            }
            else Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Shurikan")
        {
            if (firstTime)
            {
                Alert.text = "Press 'Space' to fire Shuriken.";
                Invoke("ClearAlert", 5);
                firstTime = false;
            }
            fireRate -= 0.4f;
            audioSource.PlayOneShot(shurikanPickup);
            Destroy(collision.gameObject);
            canFire = true;
        }
        else if(collision.gameObject.tag == "Heart")
        {
            health = maxHealth;            
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(shurikanPickup);
        }
        else if(collision.gameObject.tag == "PitOfDeath")
        {
            health--;
            audioSource.PlayOneShot(hurtSound);
            gameObject.transform.position = Spawnpoint.transform.position;

            if (health > 0)
            {
                invulnerable = true;
            }
            else if (health <= 0)//if no health then die
            {
                isDead = true;
                animator.SetBool("isDead", true);
                animator.SetTrigger("Die");
            }
        }
        else if(collision.gameObject.tag == "Double")
        {
            doubleShoot = true;
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "Bomb")
        {
            Alert.text = "Press 'B' to fire bomb.";
            Invoke("ClearAlert", 5);
            audioSource.PlayOneShot(shurikanPickup);
            Destroy(collision.gameObject);
            canThrow = true;
        }
        else if(collision.gameObject.tag == "EndScene")
        {
            SceneManager.LoadScene("Level2");
        }
    }

    public void ClearAlert()
    {
        Alert.text = "";
    }

    public void Vulnerable()
    {
        flickering = false;
        invulnerable = false;
    }
    public void DamagePlayer()
    {
        health--;
        audioSource.PlayOneShot(hurtSound);

        if (health > 0)
        {
            invulnerable = true;
        }

        //if no health then die
        if (health == 0)
        {
            isDead = true;
            animator.SetBool("isDead", true);
            animator.SetTrigger("Die");
        }
    }
}