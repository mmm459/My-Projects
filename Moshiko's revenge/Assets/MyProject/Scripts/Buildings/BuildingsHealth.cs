using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingsHealth : MonoBehaviour
{
    ControlingSystem controlingSystem;
    BuildingCapacitySystem buildingCapacitySystem;
    PopulationCapacity populationCapacity;
    BluePrintBuilding bluePrintBuilding;
    
    public int BuildingHealth;
    public Slider HealthBar;
    public GameObject[] FireEffect;
    int StartHealth;

    void Start()
    {
        bluePrintBuilding = FindObjectOfType<BluePrintBuilding>();
        populationCapacity = FindObjectOfType<PopulationCapacity>();
        buildingCapacitySystem = FindObjectOfType<BuildingCapacitySystem>();
        controlingSystem = FindObjectOfType<ControlingSystem>();
        StartHealth = BuildingHealth;
        HealthBar.maxValue = BuildingHealth;
    }


    void Update()
    {
        HealthBar.value = BuildingHealth;
        CheckDamge();
    }

    //calling this function from EnemyShoot script When hit the bulding 
    public void BuildingTakeingDamge(int DamgeToReduce)
    {
        Debug.Log("hit");
        BuildingHealth -= DamgeToReduce;
    }

    //spwan damge effect according to damge
    public void CheckDamge()
    {
        if (BuildingHealth <= StartHealth / 2)
        {
            FireEffect[0].SetActive(true);
        }

        if (BuildingHealth <= 0)
        {
            buildingCapacitySystem.AddBuilding(-1);

            //if the building which destroy was a soldier building then lower the population capacity
            if(bluePrintBuilding.tempNum == 3 || bluePrintBuilding.tempNum == 4 || bluePrintBuilding.tempNum == 5 || bluePrintBuilding.tempNum == 6)
            {
                populationCapacity.AddMaxPopulation(-20);
            }

            Instantiate(FireEffect[1], transform.position, Quaternion.identity);
            controlingSystem.Buildings.Remove(this.gameObject);
            Destroy(gameObject);
        }
    }
}
