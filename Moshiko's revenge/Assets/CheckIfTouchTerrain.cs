using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckIfTouchTerrain : MonoBehaviour
{
    NewWayOfBuilding newWayOfBuilding;

    private void Start()
    {
        newWayOfBuilding = FindObjectOfType<NewWayOfBuilding>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Terrain")
        {
            for(int i = 0; i < 4; i++)
            {
                if(newWayOfBuilding.touch[i])
                {
                    newWayOfBuilding.canBuild = true;
                }
            }
        }
    }
}
