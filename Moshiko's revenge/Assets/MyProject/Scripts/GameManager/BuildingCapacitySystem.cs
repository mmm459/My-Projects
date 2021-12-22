using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingCapacitySystem : MonoBehaviour
{
    public Text capacity;
    [HideInInspector]public int numBuildings = 0;
    [HideInInspector]public int maxNumBuilding;

    // Update is called once per frame
    void Update()
    {
        capacity.text = "("  + numBuildings.ToString() + "/" + maxNumBuilding.ToString() + ")";
    }

    public void AddBuilding(int _capacity)
    {
        if(maxNumBuilding > numBuildings || _capacity < 0)
        {
            numBuildings += _capacity;
        }
    }

    public void AddMaxBuilding(int _capacity)
    {
        maxNumBuilding += _capacity;
    }
}