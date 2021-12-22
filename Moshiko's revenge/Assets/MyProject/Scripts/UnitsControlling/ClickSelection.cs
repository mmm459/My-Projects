using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSelection : MonoBehaviour
{
    ControlingSystem controlingSystem;

    // Start is called before the first frame update
    void Start()
    {
        controlingSystem = GetComponent<ControlingSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        OneUnitSelect();
    }

    public void OneUnitSelect()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonUp(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                Collider SelectedUnit = hit.collider;
                if (SelectedUnit.gameObject.tag == "Unit")
                {
                    controlingSystem.ClickSelection(SelectedUnit.gameObject);
                }
            }
        }
    }
}
