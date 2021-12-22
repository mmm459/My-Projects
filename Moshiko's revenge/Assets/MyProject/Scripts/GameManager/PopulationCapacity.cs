using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulationCapacity : MonoBehaviour
{
    public Text capacity;
    [HideInInspector]public int numOfSoldiers;
    [HideInInspector]public int maxNumOfSoldier;

    private void Start()
    {
        numOfSoldiers = 0;
        maxNumOfSoldier = 0;
    }
    // Update is called once per frame
    void Update()
    {
        capacity.text = "(" + numOfSoldiers.ToString() + "/" + maxNumOfSoldier.ToString() + ")";
    }

    public void AddPopulation(int _add)
    {
        int temp = numOfSoldiers + _add;
        if(temp < maxNumOfSoldier)
        {
            if (numOfSoldiers < 0)
            {
                numOfSoldiers = 0;
            }
            else
            {
                numOfSoldiers += _add;
            }
        }
    }

    public void AddMaxPopulation(int _add)
    {
        maxNumOfSoldier += _add;
    }
}
