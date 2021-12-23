using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    BrieckEngine count;
    BallEngine explode, Flame;
    BrieckEngine jRow;

    //colors
    public Color myColor;
    float rFloat, gFloat, bFloat, aFloat;
    public Renderer myRenderer;
    public Color[] color;

    // Start is called before the first frame update
    void Start()
    {
        count = FindObjectOfType<BrieckEngine>();
        explode = FindObjectOfType<BallEngine>();
        Flame = FindObjectOfType<BallEngine>();
    }

    private void Awake()
    {
        jRow = FindObjectOfType<BrieckEngine>();
        myRenderer = GetComponent<Renderer>();
        
        if(jRow.j == 8f)
        {
            rFloat = 1f;//Random.Range(0f, 1f);
            gFloat = 0f;
            bFloat = 0f;
        }
        else if(jRow.j == 6f)
        {
            gFloat = 0f;
            gFloat = 1f;
            bFloat = 0f;
        }
        else
        {
            bFloat = 0f;
            gFloat = 0f;
            bFloat = 1f;
        }
        aFloat = 1;//Random.Range(0f, 0f);

        myColor = new Color(rFloat, gFloat, bFloat, aFloat);
        myRenderer.material.color = myColor;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            if(rFloat > 0)
            {
                rFloat = 0;
                gFloat = 1;
                bFloat = 0;
            }
            else if(gFloat > 0)
            {
                rFloat = 0;
                gFloat = 0;
                bFloat = 1;
            }
            else
            {
                Destroy(gameObject);//destroy brick
            }
            myColor = new Color(rFloat, gFloat, bFloat, aFloat);
            myRenderer.material.color = myColor;
        }
        else if(collision.gameObject.tag == "Laser")
        {
            if (rFloat > 0)
            {
                rFloat = 0;
                gFloat = 1;
                bFloat = 0;
            }
            else if (gFloat > 0)
            {
                rFloat = 0;
                gFloat = 0;
                bFloat = 1;
            }
            else
            {
                Destroy(gameObject);//destroy brick
            }
            myColor = new Color(rFloat, gFloat, bFloat, aFloat);
            myRenderer.material.color = myColor;
            Destroy(collision.gameObject);//destroy laser
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Flame.onFlame)
        {
            if (collision.gameObject.tag == "Ball")
            {
                Destroy(gameObject);//destroy brick
            }
        }
        else if(explode.explode)
        {
            if(collision.gameObject.tag == "Explosion")
            {
                Destroy(gameObject);//destroy brick
            }
        }
    }

    private void OnDestroy()
    {
        count.countBrick--;
    }
}