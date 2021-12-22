using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildBuilding : MonoBehaviour
{
    [HideInInspector]public Collider terrain;
    bool flatGround = true;

    MeshRenderer meshRenderer;

    BuildingCapacitySystem buildingCapacitySystem;
    BuildingAnimation buildingsAnimation;
    BluePrintBuilding bluePrintBuilding;
    ClickOnBuilding clickOnBuilding;
    PopulationCapacity populationCapacity;
    
    private void Start()
    {
        clickOnBuilding = FindObjectOfType<ClickOnBuilding>();
        bluePrintBuilding = FindObjectOfType<BluePrintBuilding>();
        buildingsAnimation = GetComponentInChildren<BuildingAnimation>();
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        buildingCapacitySystem = FindObjectOfType<BuildingCapacitySystem>();
        populationCapacity = FindObjectOfType<PopulationCapacity>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        CheckHigh();

        if (Physics.Raycast(ray, out hit))
        {
            terrain = hit.collider;
            if (terrain.transform.name == "Terrain")
            {
                transform.position = hit.point;
            }

            MouseOptions();

            if (buildingCapacitySystem.numBuildings >= buildingCapacitySystem.maxNumBuilding)
            {
                meshRenderer.material.color = Color.red;
            }
        }
    }

    //checking that im building on flat ground
    public void CheckHigh()
    {
        if (transform.position.y > 0.45f)
        {
            meshRenderer.material.color = Color.red;
        }
        else if (transform.position.y <= 0.45f && flatGround)
        {
            meshRenderer.material.color = Color.blue;
        }
    }

    public void MouseOptions()
    {
        if (Input.GetMouseButtonUp(0) && transform.position.y <= 0.42f && meshRenderer.material.color == Color.blue && buildingCapacitySystem.numBuildings < buildingCapacitySystem.maxNumBuilding)
        {
            if(bluePrintBuilding.tempNum == 3 || bluePrintBuilding.tempNum == 4 || bluePrintBuilding.tempNum == 5 || bluePrintBuilding.tempNum == 6)
            {
                populationCapacity.AddMaxPopulation(20);
            }
            buildingCapacitySystem.AddBuilding(1);
            buildingsAnimation.enabled = true;
            clickOnBuilding.enabled = true;
        }
        else if (Input.GetMouseButtonDown(1))
        {
            bluePrintBuilding.BringMoneyBack();
            clickOnBuilding.enabled = true;
            Destroy(gameObject);
        }
    }

    //checking that im not building on something
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Buildings" || other.gameObject.tag == "Unit" || other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyBuilding")
        {
            meshRenderer.material.color = Color.red;
            flatGround = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Buildings" || other.gameObject.tag == "Unit" || other.gameObject.tag == "Enemy" || other.gameObject.tag == "EnemyBuilding")
        {
            meshRenderer.material.color = Color.blue;
            flatGround = true;
        }
    }
}