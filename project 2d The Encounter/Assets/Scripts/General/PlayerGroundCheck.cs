using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    GameObject player;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.transform.parent.gameObject; // player is the parent of this gameobject
        animator = gameObject.transform.parent.GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Damage")
        {
            player.GetComponent<PlayerMovement>().canJump = true;
            animator.SetBool("isJumping", false);

        }
    }
}
