using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayer : MonoBehaviour
{
    public GameObject playerCenterPoint;
    public float circleSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.RotateAround(playerCenterPoint.transform.position, Vector3.back, circleSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.RotateAround(playerCenterPoint.transform.position, Vector3.forward, circleSpeed * Time.deltaTime);
        }*/
    }
}
