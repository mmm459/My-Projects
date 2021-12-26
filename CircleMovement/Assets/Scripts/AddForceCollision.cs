using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForceCollision : MonoBehaviour
{
    public PhysicMaterial playerPM;


    // Start is called before the first frame update
    void Start()
    {
        //playerPM.bounciness = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(transform.gameObject.tag == "Enemy")
        {
            //playerPM.bounciness += 5f;  
        }
    }

}
