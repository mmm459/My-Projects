using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTarget : MonoBehaviour
{
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 100;
    }

    public void MoveUp()
    {
        transform.Translate(0, 1 * Time.deltaTime * speed, 0);
    }

    public void MoveDown()
    {
        transform.Translate(0, -1 * Time.deltaTime * speed, 0);
    }

    public void MoveLeft()
    {
        transform.Translate(0, 0, -1 * Time.deltaTime * speed);
    }

    public void MoveRight()
    {
        transform.Translate(0, 0, 1 * Time.deltaTime * speed);
    }
}
