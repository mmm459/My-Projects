using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnBuilding : MonoBehaviour
{
    BuildingClickSelection buildingClickSelection;

    private void Start()
    {
        buildingClickSelection = FindObjectOfType<BuildingClickSelection>();
    }

    private void Update()
    {
        OneBuildingSelect();
    }

    public void OneBuildingSelect()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonUp(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                Collider SelectedBuilding = hit.collider;
                if (SelectedBuilding.gameObject.tag == "Buildings" && SelectedBuilding.gameObject.name != "DeffenceTower(Clone)" && SelectedBuilding.gameObject.name != "Bank(Clone)")
                {
                    buildingClickSelection.OneBuildingSelected(SelectedBuilding);
                }
            }
        }
    }
}
