using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGlow : MonoBehaviour
{

    float origScale;
    bool grow;
    float growSpeed;
    float offset;


    // Start is called before the first frame update
    void Start()
    {
        origScale = transform.localScale.x;
        grow = true;
        growSpeed = 0.1f;
        offset = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        //original scale will grow
        if (grow)
        {
            transform.localScale = new Vector2(transform.localScale.x + growSpeed * Time.deltaTime, transform.localScale.x + growSpeed * Time.deltaTime);
        }
        else
        {
            transform.localScale = new Vector2(transform.localScale.x - growSpeed * Time.deltaTime, transform.localScale.x - growSpeed * Time.deltaTime);
        }

        //if bigger than original scale plus offset then enter
        if (transform.localScale.x > (origScale + offset))
        {
            grow = false;
        }
        else if (transform.localScale.x < (origScale - offset))
        {
            grow = true;
        }
    }
}
