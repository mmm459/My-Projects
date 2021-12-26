using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTarget : MonoBehaviour
{
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 100;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveUP()
    {
        transform.Translate(0, 1 * speed * Time.deltaTime, 0);
    }

    public void MoveDown()
    {
        transform.Translate(0, -1 * speed * Time.deltaTime, 0);
    }

    public void MoveLeft()
    {
        transform.Translate(-1 * speed * Time.deltaTime, 0, 0);
    }

    public void MoveRight()
    {
        transform.Translate(1 * speed * Time.deltaTime, 0, 0);
    }
}