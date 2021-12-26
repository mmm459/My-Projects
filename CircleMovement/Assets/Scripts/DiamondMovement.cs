using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondMovement : MonoBehaviour
{
    public GameObject center;
    public float speed;
    public GameObject player;

    ManagerEngine managerEngine;

    private void Start()
    {
        managerEngine = FindObjectOfType<ManagerEngine>();
        center = GameObject.Find("StartPosition");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(managerEngine.enemyCounter <= 0 || player.transform.position.y <= -3)
        {
            Destroy(gameObject);
        }

        transform.RotateAround(center.transform.position, Vector3.down, speed * Time.deltaTime);
    }
}
