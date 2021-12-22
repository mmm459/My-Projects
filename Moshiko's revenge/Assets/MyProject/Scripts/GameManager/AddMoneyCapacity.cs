using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMoneyCapacity : MonoBehaviour
{
    MoneySystem moneySystem;

    private void Start()
    {
        moneySystem = FindObjectOfType<MoneySystem>();
        moneySystem.ChangeAmountOfMaxMoney(10000);
    }
}
