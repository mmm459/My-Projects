using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchDiamond : MonoBehaviour
{
    public GameObject circlePower;

    PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Diamond")
        {
            playerMovement.isCirclePower = true;
            Destroy(collision.gameObject);
            Instantiate(circlePower, new Vector3(transform.position.x + 0.3f,transform.position.y - 0.3f,transform.position.z), Quaternion.identity);
        }
    }
}
