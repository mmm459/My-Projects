using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialForceAnimation : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        CheckIfIsAlive();
        if (unitsMovement.enabled)
        {
            animator.Play("SpecialForce_Walk");
        }
        else if (this.enabled && !unitsMovement.enabled && !unitAttack.enabled)
        {
            animator.Play("SpecialForce_Idle");
        }
    }


    public IEnumerator ActiveMuzzle()
    {
        MuzzleEffect.SetActive(true);
        yield return new WaitForSeconds(0.2f);
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
