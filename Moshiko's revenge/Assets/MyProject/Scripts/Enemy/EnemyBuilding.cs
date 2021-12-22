using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBuilding : MonoBehaviour
{
    EnemyManager enemyManager;
    MoneySystem moneySystem;

    public int BuildingHealth;
    int StartHealth;
    public Slider BuldingHealthBar;

    public GameObject[] FireEffect;

    void Start()
    {
        moneySystem = FindObjectOfType<MoneySystem>();
        enemyManager = FindObjectOfType<EnemyManager>();
        enemyManager.enemyBuildings.Add(this.gameObject);
        BuldingHealthBar.maxValue = BuildingHealth;
        StartHealth = BuildingHealth;
    }


    void Update()
    {
        BuldingHealthBar.value = BuildingHealth;
        CheckDamge();
    }

    //calling this function from Shoot script When hit the bulding 
    public void BuildingTakeingDamge(int DamgeToReduce)
    {
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
            moneySystem.ChangeAmountOfMoney(500);
            Instantiate(FireEffect[1], transform.position, Quaternion.identity);
            enemyManager.enemyBuildings.Remove(this.gameObject);
            Destroy(gameObject);
            enemyManager.enemyBuildings.Remove(this.gameObject);
        }
    }
}
