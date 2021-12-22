using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToBuildingList : MonoBehaviour
{
    ControlingSystem controlingSystem;

    void Start()
    {
        controlingSystem = FindObjectOfType<ControlingSystem>();
        controlingSystem.Buildings.Add(this.gameObject);
    }

}
