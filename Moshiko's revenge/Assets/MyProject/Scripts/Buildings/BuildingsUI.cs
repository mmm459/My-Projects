using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsUI : MonoBehaviour
{
    public GameObject ui;

    private void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            this.enabled = false;
        }
    }

    private void OnEnable()
    {
        ui.SetActive(true);
    }

    private void OnDisable()
    {
        ui.SetActive(false);
    }
}
