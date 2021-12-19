using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCannon : MonoBehaviour
{
    public GameObject fireBall;
    public GameObject player;
    [SerializeField]
    BigBoss bossLife;


    [SerializeField]
    int dirX;
    int speed = 10;
    int offset = 1;
    [SerializeField]
    bool action1;

    public void Awake()
    {
        action1 = true;
        dirX = -1;
    }

    private void Start()
    {
        player = GameObject.Find("Player");
        bossLife = FindObjectOfType<BigBoss>();//gameobject("BigBoss(Clone)");
        StartCoroutine(Move());
        Invoke("Throw", 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (action1)
        {
            if (transform.position.x >= 20 || transform.position.x <= -20)
            {
                dirX *= -1;
            }
            transform.Translate(dirX * Time.deltaTime * speed, 0, 0);
        }

        if(bossLife.GetComponent<BigBoss>().life <= 30)
        {
            Debug.Log("check");
            action1 = false;
            if(player.transform.position.x <= transform.position.x)
            {
                transform.Translate(-1 * Time.deltaTime * speed, 0, 0);
            }
            else if(player.transform.position.x >= transform.position.x)
            {
                transform.Translate(1 * Time.deltaTime * speed, 0, 0);
            }
        }
    }

    IEnumerator Move()
    {
        dirX = 1;
        yield return new WaitForSeconds(Random.Range(3, 6));
        dirX = -1;
        yield return new WaitForSeconds(Random.Range(3, 6));
        StartCoroutine(Move());
    }

    public void Throw()
    {
        Instantiate(fireBall, new Vector2(transform.position.x, transform.position.y - offset), fireBall.transform.rotation);
        Invoke("Throw", 2);
    }
}
