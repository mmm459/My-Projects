using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissPenalty : MonoBehaviour
{
    public GameObject ball;
    public GameObject startPosition;

    BallEngine ballEngine;
    Manager manager;
    UIData uIData;

    private void Start()
    {
        uIData = FindObjectOfType<UIData>();
        manager = FindObjectOfType<Manager>();
        ballEngine = FindObjectOfType<BallEngine>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ballEngine.rb.velocity = new Vector3(0, 0, 0);
            ballEngine.rb.angularVelocity = new Vector3(0, 0, 0);
            ball.transform.position = startPosition.transform.position;
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
