using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneySystem : MonoBehaviour
{
    public Text money;
    [HideInInspector]public int moneyCounter;
    [HideInInspector]public int income;
    [HideInInspector]public int max;

    // Start is called before the first frame update
    void Start()
    {
        max = 100000;
        income = 250;
        moneyCounter = 100000;
        Invoke("StaticCCMoney", 20);
    }

    // Update is called once per frame
    void Update()
    {
        money.text = "(" + moneyCounter.ToString() + "/" + max.ToString() + ")";
    }

    public void StaticCCMoney()
    {
        //save the money counter plus the income you get into a temp
        int tempMoney = moneyCounter + income;

        if (tempMoney < max)
        {
            moneyCounter += income;
        }
        Invoke("StaticCCMoney", 20);
    }

    public void ChangeAmountOfMoney(int _money)
    {
        int tempMoney = moneyCounter + _money;
        if (tempMoney <= max)
        {

            moneyCounter += _money;
        }
        else if(tempMoney > max)
        {
            moneyCounter = max;
        }
    }

    public void ChangeAmountOfMaxMoney(int _money)
    {
        max += _money;
    }
}