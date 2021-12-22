using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shurikans : MonoBehaviour
{
    [HideInInspector]
    public float speed = 20f;
    [HideInInspector]
    public float destroyTimer = 0.3f;
    AudioSource audioSource;
    bool flying = true;
    
    // Update is called once per frame
    void Update()
    {
        if(flying)
        {
            transform.Translate(1 * Time.deltaTime * speed, 0, 0);
        }
        Invoke("DestroyObject", 2); // destroy after 2 seconds
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Shurikan")
        {
            flying = false;
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);

            Invoke("DestroyObject", destroyTimer);
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
