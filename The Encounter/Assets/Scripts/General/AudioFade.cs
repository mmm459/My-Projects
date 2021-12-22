using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFade : MonoBehaviour
{
    AudioSource Source;
    AudioClip Clip;
    Transform player;

    public float max = 20;

    // Start is called before the first frame update
    void Start()
    {
        Source = GetComponent<AudioSource>();
        
        Clip = Source.clip;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.Find("Player").transform;
        }

        float dist = Vector3.Distance(transform.position, player.position);
        Source.volume = 1 - (dist / max);
    }
}