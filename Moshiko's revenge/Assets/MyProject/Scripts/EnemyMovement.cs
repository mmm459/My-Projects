using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;

    [HideInInspector] public Vector3 moveToLocation;
    

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        WhenDoneToWalk();
    }

    public void Movement()
    {
        agent.SetDestination(moveToLocation);
        animator.SetBool("isWalking", true);
    }

    public void WhenDoneToWalk()
    {
        if (agent.destination == transform.position)
        {
            animator.SetBool("isWalking", false);
            this.enabled = false;
        }
    }
}
