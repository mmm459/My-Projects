using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitOrderManager : MonoBehaviour
{
    Animator animator;
    ControlingSystem controlingSystem;
    UnitsMovement unitsMovement;
    UnitAttack unitAttack;
    PopulationCapacity populationCapacity;
    UpgradesManager upgradesManager;

    public Vector3 MoveToLocation;
    public GameObject AttackThisEnemy;

    public GameObject LocalCanvas;

    public Slider HealthBar;

    public int UnitHealth;

    public bool ExplosiveDeath;
    bool isDead = false;
    public GameObject ExlosionEffect;

    //Audio
    public AudioSource attackingEnemy;
    public AudioSource clickOnSoldier;


    void Awake()
    {
        controlingSystem = FindObjectOfType<ControlingSystem>();
        controlingSystem.UnitsInTheGame.Add(this.gameObject);
    }

    void Start()
    {
        unitsMovement = GetComponent<UnitsMovement>();
        unitAttack = GetComponent<UnitAttack>();
        animator = GetComponent<Animator>();
        populationCapacity = FindObjectOfType<PopulationCapacity>();
        upgradesManager = FindObjectOfType<UpgradesManager>();
    }


    void Update()
    {
        CheckWichObjectClicked();
        //make the health bar ui be equle to the accualy health
        HealthBar.value = UnitHealth;
    }

    //checking if i clicked a enemy or the enviourment
    public void CheckWichObjectClicked()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonUp(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                Collider HitedObject = hit.collider;
                //if i clicked the enviourment its closeing attack script and opening movement scripte 
                //and save the click loacation in MoveToLocation (then im using it in UnitsMovement script)
                if (HitedObject.gameObject.tag == "Enviourment")
                {
                    unitAttack.enabled = false;
                    unitsMovement.enabled = true;
                    MoveToLocation = hit.point;
                }
                // if i clicked enemy its closeing movement script and turning on attack script
                // and save the enemy object in AttackThisEnemy (then im using it in UnitAttack script)
                else if (HitedObject.gameObject.tag == "Enemy" || HitedObject.gameObject.tag == "EnemyBuilding")
                {
                    unitsMovement.enabled = false;
                    unitAttack.enabled = true;
                    Collider ClickEnemy = hit.collider;
                    AttackThisEnemy = ClickEnemy.gameObject;
                    attackingEnemy.Play();
                }
            }
        }
    }

    //im colling this function from EnemyShoot Script and then give back how much i want to damge  
    public void ReduceHealth(int HealthToReduce)
    {
        HealthToReduce -= upgradesManager.shield;

        //if armour is empty start takeing damge from health 
        if(UnitHealth > 0)
        {
            UnitHealth -= HealthToReduce;
        }
        
        //when health is done im taking this object from all the lists in contrilling systeam 
        //and destroy it 
        if (UnitHealth <= 0)
        {
            if(!isDead)
            {
                populationCapacity.AddPopulation(-1);
                isDead = true;
            }
            controlingSystem.SelectedUnits.Remove(this.gameObject);
            controlingSystem.UnitsInTheGame.Remove(this.gameObject);
            if (ExplosiveDeath)
            {
                Instantiate(ExlosionEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            animator.SetTrigger("Die");
        }
    }

    public void WhenDie()
    {
        Destroy(gameObject);
    }

    public void StopWalkAnimation()
    {
        animator.SetTrigger("StopWalk");
    }

    //tuen on unit loacl canvas when is selected 
    void OnEnable()
    {
        clickOnSoldier.Play();
        LocalCanvas.SetActive(true);
    }
    //close unit loacl canvas when is selected 
    void OnDisable()
    {
        LocalCanvas.SetActive(false);
    }

}

