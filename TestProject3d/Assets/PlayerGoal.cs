using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoal : MonoBehaviour
{
    UIData uIData;
    Manager manager;
    Power power;
    public GameObject ball;
    public GameObject startPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        power = FindObjectOfType<Power>();
        uIData = FindObjectOfType<UIData>();
        manager = FindObjectOfType<Manager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            uIData.playerNum++;
            ball.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            ball.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
            ball.transform.position = startPosition.transform.position;
            power.power = 0;
            Invoke("CompTurn", 3);
        }
    }

    public void CompTurn()
    {
        if(uIData.playerNum != 10)
        {
            manager.CompLevel();
        }
    }
}
