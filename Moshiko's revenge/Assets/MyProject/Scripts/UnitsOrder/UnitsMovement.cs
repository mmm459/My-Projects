using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitsMovement : MonoBehaviour
{
    ControlingSystem controlingSystem;
    NavMeshAgent agent;
    UnitOrderManager unitOrderManager;
    UnitDefende unitDefende;

    void Awake()
    {
        unitDefende = GetComponent<UnitDefende>();
    }

    void Start()
    {
        unitOrderManager = GetComponent<UnitOrderManager>();
        controlingSystem = FindObjectOfType<ControlingSystem>();
        agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        Move();
        WhenDoneToWalk();
    }

    //set the destination to the MoveToLocation taht i saved in unitOrderManager
    public void Move()
    {
        agent.SetDestination(unitOrderManager.MoveToLocation);
    }

    public void StopMovement()
    {
        //set destination to where he is at the moment 
        unitOrderManager.MoveToLocation = transform.position;
    }

    //close the script when got to destination
    public void WhenDoneToWalk()
    {
        if (agent.destination == transform.position)
        {
            this.enabled = false;
        }
    }

    //close the unitDefende script becuse its force me to fight and i will not be able to move 
    void OnEnable()
    {
        unitDefende.enabled = false;
        Invoke("AcitveDefence", 5);
    }

    void AcitveDefence()
    {
        unitDefende.enabled = true;
    }
}
