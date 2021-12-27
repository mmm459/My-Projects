using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{
    public float power;
    public bool isHold;
    public bool kick;

    [SerializeField]
    private Text powerNum;

    BallEngine ballEngine;
    Manager manager;

    private void Start()
    {
        manager = FindObjectOfType<Manager>();
        ballEngine = FindObjectOfType<BallEngine>();
        isHold = false;
        kick = false;
        power = 0;
    }

    private void Update()
    {
        if (power < 100 && isHold)
        {
            power += 1f;
            //move to ball addforce
        }

        powerNum.text = power.ToString();
    }

    public void StartPowerShoot()
    {
        //enter if this is player turn
        if(!manager.turn)
        {
            Debug.Log("start power");
            isHold = true;
        }
    }

    public void StopPowerShoot()
    {
        if(!manager.turn)
        {
            Debug.Log("stop power");
            isHold = false;
            ballEngine.MoveToTarget();
            manager.turn = !manager.turn;
        }
    }
}
