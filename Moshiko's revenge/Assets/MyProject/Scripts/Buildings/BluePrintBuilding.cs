using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BluePrintBuilding : MonoBehaviour
{
    public List<GameObject> bluePrintBuildings;
    MoneySystem moneySystem;
    ClickOnBuilding clickOnBuilding;
    public GameObject ui;
    [HideInInspector]public int tempCost;
    [HideInInspector]public int checkSum;

    public int tempNum;

    //upgrade system
    public bool[] availeableButtons;
    public int level;
    UpdateBuildingLevel updateBuildingLevel;
    int upgradeCost;

    //building system
    BuildingCapacitySystem buildingCapacitySystem;

    public AudioSource InsufficentFund;

    void Start()
    {
        clickOnBuilding = FindObjectOfType<ClickOnBuilding>();
        moneySystem = FindObjectOfType<MoneySystem>();
        updateBuildingLevel = FindObjectOfType<UpdateBuildingLevel>();
        buildingCapacitySystem = FindObjectOfType<BuildingCapacitySystem>();
        level = 3;
        upgradeCost = 700;
        AvaileableButtons();
    }

    //this func calls the blueprint variant
    public void BluePrint(int num)
    {
        //temp the index of building from the list
        tempNum = num;
        //for purchase a building you must have enough money, the button of building must be true and enough availeable building capacity
        if(moneySystem.moneyCounter >= checkSum && availeableButtons[num] && buildingCapacitySystem.numBuildings < buildingCapacitySystem.maxNumBuilding)
        {
            clickOnBuilding.enabled = false;
            ui.SetActive(false);
            Instantiate(bluePrintBuildings[num], transform.position, Quaternion.identity);
            moneySystem.ChangeAmountOfMoney(checkSum * -1);
        }
        else if(!availeableButtons[num])
        {
            //audio source optional
            Debug.Log("you cant build this yet");
        }
    }

    //lower the money according to the cost of a building
    public void BuildingCost(int _cost)
    {
        //check if the cost is lower or equal than what you have
        checkSum = _cost * -1;
        if(moneySystem.moneyCounter < checkSum)
        {
            InsufficentFund.Play();
        }
    }

    //this func called from build buildings script
    public void BringMoneyBack()
    {
        moneySystem.ChangeAmountOfMoney(checkSum);
    }

    public void AvaileableButtons()
    {
        for (int i = 0; i <= level; i++)
        {
            availeableButtons[i] = true;
        }
    }

    
    public void Upgrade()
    {
        if (level < 6 && moneySystem.moneyCounter >= checkSum)
        {
            //upgrade cost
            moneySystem.ChangeAmountOfMoney(-upgradeCost);
            //add maximum building capacity
            buildingCapacitySystem.AddMaxBuilding(20);
            //add more money to the income
            moneySystem.income += 100;
            //multiply the cost of upgrade
            upgradeCost *= 2;
            level++;
            //change text level
            updateBuildingLevel.ShowLevelInUI();
        }
        AvaileableButtons();
    }
}