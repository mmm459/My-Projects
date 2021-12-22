using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGroup : MonoBehaviour
{
    ControlingSystem controlingSystem;
    int counter;

    private void Start()
    {
        counter = 0;
        controlingSystem = FindObjectOfType<ControlingSystem>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Unit")
        {
            counter++;
            transform.localScale += new Vector3(0.08f, 0.1f, 0.08f);
            //stop the animation and the movement for unit that collide With that 
            other.GetComponent<UnitsMovement>().StopMovement();
            other.GetComponent<UnitOrderManager>().StopWalkAnimation();
            //destroy that object when all selected unit collide with him 
            if (controlingSystem.SelectedUnits.Count == counter)
            {
                Destroy(gameObject,1);
            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Unit")
        {
            if (other.GetComponent<UnitsMovement>().enabled)
            {
                other.GetComponent<UnitOrderManager>().StopWalkAnimation();
                other.GetComponent<UnitsMovement>().StopMovement();
            }
        }
    }
}
