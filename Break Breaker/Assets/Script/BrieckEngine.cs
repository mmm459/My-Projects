using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrieckEngine : MonoBehaviour
{
    public GameObject[] prefab;
    [HideInInspector]
    public float i,j, space = 9f;
    GameObject ball;
    BallEngine hit;
    int choice;
//    [HideInInspector]
    public int countBrick = 0;
    int lvl = 2;
   
    // Start is called before the first frame update
    void Start()
    {
        /*for (i = -15; i < 15; i += 3f)
        {
            for (j = 1; j <= 9; j++)
            {
                if (j % 2 == 0)
                {
                    Instantiate(prefab[0], new Vector2(i, j), prefab[0].transform.rotation);
                    countBrick += 1;
                }
            }
        }*/
        ball = GameObject.Find("Ball");
        hit = FindObjectOfType<BallEngine>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ball != null)
        {
            if (hit.GetComponent<BallEngine>().hit)
            {
                choice = Random.Range(1, 100);
                if (choice == 1)//fixed
                {
                    Instantiate(prefab[1], new Vector2(ball.transform.position.x, ball.transform.position.y), prefab[1].transform.rotation);
                }
                else if (choice == 2)
                {
                    Instantiate(prefab[2], new Vector2(ball.transform.position.x, ball.transform.position.y), prefab[2].transform.rotation);
                }
                else if (choice == 3)
                {
                    Instantiate(prefab[3], new Vector2(ball.transform.position.x, ball.transform.position.y), prefab[3].transform.rotation);
                }
                else if (choice == 4)
                {
                    Instantiate(prefab[4], new Vector2(ball.transform.position.x, ball.transform.position.y), prefab[4].transform.rotation);
                }
                else if (choice == 5)//fixed
                {
                    Instantiate(prefab[5], new Vector2(ball.transform.position.x, ball.transform.position.y), prefab[5].transform.rotation);
                }
                else if (choice == 6)//fixed
                {
                    Instantiate(prefab[6], new Vector2(ball.transform.position.x, ball.transform.position.y), prefab[6].transform.rotation);
                }
                else if (choice == 7)//fixed
                {
                    Instantiate(prefab[7], new Vector2(ball.transform.position.x, ball.transform.position.y), prefab[7].transform.rotation);
                }
                else if (choice == 8)
                {
                    Instantiate(prefab[8], new Vector2(ball.transform.position.x, ball.transform.position.y), prefab[8].transform.rotation);
                }
                else if (choice == 9)//fixed collision between lasers and ball
                {
                    Instantiate(prefab[9], new Vector2(ball.transform.position.x, ball.transform.position.y), prefab[9].transform.rotation);
                }
                else if (choice == 10)//fixed collision between lasers and ball
                {
                    Instantiate(prefab[10], new Vector2(ball.transform.position.x, ball.transform.position.y), prefab[10].transform.rotation);
                }
                hit.GetComponent<BallEngine>().hit = false;
            }
        }

        if(countBrick == 0)
        {
            lvl++;
            if (lvl == 2)
            {
                Lvl2();
            }
            else if(lvl == 3)
            {
                Lvl3();
            }
        }
    }

    private void Lvl2()
    {
        for (i = -15; i < 15; i += 3f)
        {
            if(i%2 == 0)
            {
                for (j = 1.5f; j <= 9.5f; j += 1.5f)
                {
                    Instantiate(prefab[0], new Vector2(i, j), prefab[0].transform.rotation);
                    countBrick += 1;
                }
            }
        }
    }
    private void Lvl3()
    {
        space = 3.2f;
        for (i = -30; i < -15; i += 3f)
        {
            for (j = 1; j <= 9; j++)
            {
                if (j % 2 == 1 && space > j)
                {
                    Instantiate(prefab[0], new Vector2(i, j), prefab[0].transform.rotation);
                    countBrick += 1;
                }
            }            
            space++;
        }

        space = 7.5f;
        for (i = 15; i < 30; i += 3f)
        {
            for (j = 1; j <= 9; j++)
            {
                if (j % 2 == 1 && space > j)
                {
                    Instantiate(prefab[0], new Vector2(i, j), prefab[0].transform.rotation);
                    countBrick += 1;
                }
            }
            space--;
        }
    }
}