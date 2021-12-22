using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSoldierDC : MonoBehaviour
{
    MoneySystem moneySystem;
    UpgradesManager upgradesManager;
    public Button[] upgradeButtons;
    private void Start()
    {
        moneySystem = FindObjectOfType<MoneySystem>();
        upgradesManager = FindObjectOfType<UpgradesManager>();
    }

    public void DeffenceButton(int _amount)
    {
        if(moneySystem.moneyCounter >= _amount)
        {
            upgradeButtons[0].interactable = false;
            moneySystem.moneyCounter -= _amount;
            upgradesManager.shield = 2;
        }
    }

    public void AttackButton(int _amount)
    {
        if(moneySystem.moneyCounter >= _amount)
        {
            upgradeButtons[1].interactable = false;
            moneySystem.moneyCounter -= _amount;
            upgradesManager.attack = 2;
        }
    }

    public void RangeButton(int _amount)
    {
        if(moneySystem.moneyCounter >= _amount)
        {
            upgradeButtons[2].interactable = false;
            moneySystem.moneyCounter -= _amount;
            upgradesManager.range = 2.5f;
        }
    }
}