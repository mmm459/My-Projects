using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesManager : MonoBehaviour
{
    MoneySystem moneySystem;
    public int shield = 0;
    public int attack = 0;
    public float range = 0;

    void Start()
    {
        moneySystem = FindObjectOfType<MoneySystem>();
    }
}
