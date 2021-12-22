using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    Transform playerTrn;
    float speed = 8;
    Vector3 cameraFollow;
    [HideInInspector]
    public bool follow = false;

    private void Start()
    {
        playerTrn = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTrn != null)
        {
            if (transform.position.x != playerTrn.transform.position.x && transform.position.y != playerTrn.transform.position.y && !follow)
            {
                cameraFollow = new Vector3(playerTrn.position.x, playerTrn.position.y, playerTrn.position.z - 10);
                transform.position = Vector3.MoveTowards(transform.position, cameraFollow, speed * Time.deltaTime);
            }
            else
            {
                follow = true;
                transform.position = new Vector3(playerTrn.transform.position.x, playerTrn.transform.position.y, -10);
            }
        }
    }
}