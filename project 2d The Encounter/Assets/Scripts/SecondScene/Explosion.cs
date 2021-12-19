using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audioSource;
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);
        Invoke("DestroyObject", 0.5f);
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }

}