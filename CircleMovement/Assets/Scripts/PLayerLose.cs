using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerLose : MonoBehaviour
{
    public GameObject startPoint;
    ManagerEngine managerEngine;
    PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        managerEngine = FindObjectOfType<ManagerEngine>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -5)
        {
            transform.position = startPoint.transform.position;
            managerEngine.level = 1;
            playerMovement.rb.velocity = new Vector3(0, 0, 0);
            managerEngine.CreateEnemy();
        }
    }
}
