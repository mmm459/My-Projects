using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateSoldiers : MonoBehaviour
{
    public GameObject infantry;
    public Button button;
    public Transform setPoint;

    public Image LoadingPanel;
    float TimeToWait = 10;
    bool Wating = false;
    
    PopulationCapacity populationCapacity;
    MoneySystem moneySystem;
    int creat = 1;
    public int checkSum;

    //upgrade system
    public int level;
    UpdateBuildingLevel updateBuildingLevel;
    int upgradeCost;
    bool doubleSoldier;

    public AudioSource UnitInProdres;
    public AudioSource UnitComplete;
    public AudioSource InsufficentFund;

    public Text upgradeBuildingCost;

    void Start()
    {
        moneySystem = FindObjectOfType<MoneySystem>();
        populationCapacity = FindObjectOfType<PopulationCapacity>();
        updateBuildingLevel = FindObjectOfType<UpdateBuildingLevel>();
        level = 1;
        upgradeCost = 500;
    }

    private void Update()
    {
        if(Wating)
        {
            LoadingPanel.fillAmount += 1f / TimeToWait * Time.deltaTime;  
        }
        else
        {
            LoadingPanel.fillAmount = 0;
        }

        upgradeBuildingCost.text = "upgrade building" + " " + upgradeCost.ToString();
    }

    public void TimeToCreateSoldier(int _cost)
    {
        //make the value as absolut number
        checkSum = _cost * -1;
        //check if population is not max and money is above the cost
        if (moneySystem.moneyCounter >= checkSum && populationCapacity.numOfSoldiers < populationCapacity.maxNumOfSoldier)
        {
            populationCapacity.AddPopulation(creat);
            button.interactable = false;
            moneySystem.ChangeAmountOfMoney(_cost);
            StartCoroutine(CreateInfantry());
            UnitInProdres.Play();
        }//if the cost is bigger tham the money
        else if(moneySystem.moneyCounter < _cost)
        {
            InsufficentFund.Play();
        }//if the population is full
        else if(populationCapacity.numOfSoldiers > 20)
        {
            Debug.Log("capacity population is full");
        }
    }

    IEnumerator CreateInfantry()
    {
        Wating = true;
        yield return new WaitForSeconds(TimeToWait);

        if (this.gameObject)
        {
            button.interactable = true;
            GameObject soldier = Instantiate(infantry, transform.position, Quaternion.identity);
            soldier.GetComponent<UnitsMovement>().enabled = true;
            soldier.GetComponent<UnitOrderManager>().MoveToLocation = setPoint.position;
            Wating = false;
            UnitComplete.Play();
            //wait before you creat the second
            yield return new WaitForSeconds(1);
            //create 2 in 1
            if (doubleSoldier)
            {
                GameObject soldier2 = Instantiate(infantry, transform.position, Quaternion.identity);
                soldier2.GetComponent<UnitsMovement>().enabled = true;
                soldier2.GetComponent<UnitOrderManager>().MoveToLocation = setPoint.position;
            }
        }
    }

    public void Upgrade()
    {
        if(level < 3 && moneySystem.moneyCounter >= checkSum)
        {
            moneySystem.ChangeAmountOfMoney(-upgradeCost);
            upgradeCost *= 2;
            TimeToWait--;
            level++;
            updateBuildingLevel.ShowLevelInUI();
            
            if (level == 3)
            {
                doubleSoldier = true;
            }
        }
    }
}
