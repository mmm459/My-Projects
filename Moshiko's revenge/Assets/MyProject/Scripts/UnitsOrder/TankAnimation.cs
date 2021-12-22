using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAnimation : MonoBehaviour
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
        if (unitsMovement.enabled)
        {
            animator.Play("Tank_Moveing");
        }
        else if (this.enabled && !unitsMovement.enabled && !unitAttack.enabled)
        {
            animator.Play("Tank_Idle");
        }
    }


    public IEnumerator ActiveMuzzle()
    {
        MuzzleEffect.SetActive(true);
        yield return new WaitForSeconds(2f);
        MuzzleEffect.SetActive(false);
    }

    public void CheckIfIsAlive()
    {
        if (unitOrderManager.UnitHealth <= 0)
        {
            this.enabled = false;
        }
    }
}
