using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsAnimation : MonoBehaviour
{
    Animator animator;
    UnitsMovement unitsMovement;
    UnitOrderManager unitOrderManager;
    UnitAttack unitAttack;

    public GameObject MuzzleEffect;

    void Start()
    {
        animator = GetComponent<Animator>();
        unitsMovement = GetComponent<UnitsMovement>();
        unitOrderManager = GetComponent<UnitOrderManager>();
        unitAttack = GetComponent<UnitAttack>();
    }


    void Update()
    {
        CheckIfIsAlive();
        //check if the movement script on and turn on walk animation 
        if (unitsMovement.enabled)
        {
            animator.Play("Infantry_Walk");
        }
        // check the movement and attack is off and turn on idle animation 
        else if(this.enabled && !unitsMovement.enabled && !unitAttack.enabled)
        {
            animator.Play("Infantry_Idle");
        }
    }


    //i call this function from attack animation 
    public IEnumerator ActiveMuzzle()
    {
        MuzzleEffect.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        MuzzleEffect.SetActive(false);
    }

    public void CheckIfIsAlive()
    {
        if(unitOrderManager.UnitHealth <= 0)
        {
            this.enabled = false;
        }
    }
}
