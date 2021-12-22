using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingClickSelection : MonoBehaviour
{
    public List<Collider> selectedBuilding;

    public void OneBuildingSelected(Collider _building)
    {
        if (selectedBuilding.Capacity == 0)
        {
            selectedBuilding = new List<Collider>();
            selectedBuilding.Add(_building);
            selectedBuilding[0].GetComponent<BuildingsUI>().enabled = true;
        }
        else if (selectedBuilding.Capacity > 0)
        {
            selectedBuilding[0].GetComponent<BuildingsUI>().enabled = false;
            selectedBuilding.Clear();
            selectedBuilding = new List<Collider>();
            selectedBuilding.Add(_building);
            selectedBuilding[0].GetComponent<BuildingsUI>().enabled = true;
        }
    }
}
