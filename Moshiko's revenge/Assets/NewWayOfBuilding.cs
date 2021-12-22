using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWayOfBuilding : MonoBehaviour
{

    [HideInInspector]public Collider terrain;
    public bool[] touch;
    public bool canBuild = false;

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            terrain = hit.collider;
            if (terrain.transform.name == "Terrain")
            {
                transform.position = hit.point;
            }
        }


        if (canBuild)
        {
            Debug.Log("can build");
        }
        else
        {
            Debug.Log("can not build");
        }
    }
}
