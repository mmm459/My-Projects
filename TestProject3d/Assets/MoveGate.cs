using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGate : MonoBehaviour
{
    SettingsScript settingsScript;

    int speed;
    bool leftRight;

    private void Start()
    {
        speed = 10;
    }


    public void MovingGate()
    {
        if(SettingsScript.canMove)
        {
            if(leftRight)
            {
                transform.Translate(0, 0, 1 * speed * Time.deltaTime);
            }
            else
            {
                transform.Translate(0, 0, 1 * speed * Time.deltaTime);
            }
            Invoke("MoveDir", 3);
        }
    }

    

    public void MoveDir()
    {
        leftRight = !leftRight;
        MoveDir();
    }
}
