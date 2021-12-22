using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlingSystem : MonoBehaviour
{

    UnitOrderManager unitOrderManager;

    public List<GameObject> SelectedUnits;

    public List<GameObject> UnitsInTheGame = new List<GameObject>();

    public Vector3 ClickPoint;

    bool isDeselectUnits;

    public GameObject GroupLocation;

    public List<GameObject> group = new List<GameObject>();

    public List<GameObject> Buildings = new List<GameObject>();

    public GameObject YouLostText;

    void Start()
    {
        unitOrderManager = FindObjectOfType<UnitOrderManager>();
        isDeselectUnits = false;
    }


    void Update()
    {
        DeselectUnits();
        ClickLocationForcheckGroup();
        LocationForGroup();
        YouLost();
    }

    public void DeselectUnits()
    {
        // start IEnumerator to check that my click was short 
        if (Input.GetMouseButtonDown(1))
        {
            isDeselectUnits = true;
            StartCoroutine(CancleIsDeselectUnits());
        }

        if (Input.GetMouseButtonUp(1) && isDeselectUnits == true)
        {
            foreach (GameObject gameObject in SelectedUnits)
            {
                //close the component if the right click is less than 0.2f seconds
                gameObject.GetComponent<UnitOrderManager>().enabled = false;
            }
            SelectedUnits.Clear();
            SelectedUnits = new List<GameObject>();
        }
    }

    //store in the SelectedUnits list the unit that im giveing this fuonction from ClickSelection script 
    public void ClickSelection(GameObject clickUnit)
    {
        if(SelectedUnits.Capacity == 0)
        {
            SelectedUnits = new List<GameObject>();
            SelectedUnits.Add(clickUnit);
            SelectedUnits[0].GetComponent<UnitOrderManager>().enabled = true;
        }//if you clicked from soldier to another soldier then enable false the last one
        else if(SelectedUnits.Capacity > 0)
        {
            for(int i = 0; i < SelectedUnits.Count; i++)
            {
                SelectedUnits[i].GetComponent<UnitOrderManager>().enabled = false;
            }
            SelectedUnits.Clear();
            SelectedUnits = new List<GameObject>();
            SelectedUnits.Add(clickUnit);
            SelectedUnits[0].GetComponent<UnitOrderManager>().enabled = true;
        }
    }

    //store in the SelectedUnits list the unit that im giveing this fuonction from BoxSelection script 
    public void BoxSelection(GameObject unitToAdd)
    {   
        SelectedUnits.Add(unitToAdd);
        foreach(GameObject gameObject in SelectedUnits)
        {
            gameObject.GetComponent<UnitOrderManager>().enabled = true;
        }
    }

    //brings for WaitToSpwanLocation IEnumerator the location to spwan checkGroup object
    public void ClickLocationForcheckGroup()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                ClickPoint = hit.point;
            }
        }
    }

    public void LocationForGroup()
    {
        if (Input.GetMouseButtonDown(0))
        {//count is more accurate than capacity
            if (SelectedUnits.Count >= 2)
            {//ieunomerator because if not then the clickPoint touch the checkGroup and not the terrain
                StartCoroutine(WaitToSpwanLocation());
            }
        }
    }

    IEnumerator WaitToSpwanLocation()
    {
        foreach (GameObject gameObject in group)
        {//destroy old checkGroup game object 
            Destroy(gameObject);
        }
        group.Clear();
        //wating 1 second and spwaning new checkGroup object and store him in the list 
        yield return new WaitForSeconds(1);
        group = new List<GameObject>();
        GameObject groupCheck = Instantiate(GroupLocation, ClickPoint, Quaternion.identity);
        group.Add(groupCheck);
    }

    IEnumerator CancleIsDeselectUnits()
    {
        yield return new WaitForSeconds(0.2f);
        isDeselectUnits = false;
    }

    public void YouLost()
    {
        if(Buildings[0] == null)
        {
            YouLostText.SetActive(true);
            Invoke("LoadMainSecen", 3);
        }
    }

    public void LoadMainSecen()
    {
        SceneManager.LoadScene(0);
    }
}
