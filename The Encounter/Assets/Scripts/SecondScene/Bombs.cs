using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombs : MonoBehaviour
{
    bool flying = true;
    float speed = 7f;
    public GameObject explosion;

    // Update is called once per frame
    void Update()
    {
        if (flying)
        {
            transform.Translate(1 * Time.deltaTime * speed, 0, 0);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            flying = false;
            Invoke("DestroyObject", 2f);
        }
    }

    public void DestroyObject()
    {
        Instantiate(explosion, new Vector2(transform.position.x, transform.position.y), explosion.transform.rotation);
        Destroy(gameObject);
    }
}