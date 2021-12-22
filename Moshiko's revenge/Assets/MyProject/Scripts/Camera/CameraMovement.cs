using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float SpeedMovement;
    [SerializeField] float MouseX, MouseY;
    
    void Start()
    {
        SpeedMovement = 100;
    }

    void Update()
    {
            //camera movement
            ScrollingCamera();
            MovingCamera();
    }

    public void ScrollingCamera()
    {
        float Scroll = Input.GetAxis("Mouse ScrollWheel");

        if(transform.position.y < 20 && transform.position.y > 10)
        {
            transform.position += new Vector3(0, -Scroll * Time.deltaTime * 1000, 0);
        }

        if(transform.position.y > 20)
        {
            transform.position = new Vector3(transform.position.x,19.8f,transform.position.z);
        }
        else if(transform.position.y < 10)
        {
            transform.position = new Vector3(transform.position.x, 10.8f, transform.position.z);
        }
     }

    public void MovingCamera()
    {
        MouseX = Input.GetAxis("Mouse X");
        MouseY = Input.GetAxis("Mouse Y");
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -70, 200), transform.position.y, Mathf.Clamp(transform.position.z, -70, 200));

        if (Input.GetMouseButton(1))
        {
            transform.position -= new Vector3(MouseX * Time.deltaTime * SpeedMovement, 0, MouseY * Time.deltaTime * SpeedMovement);
        }
    }
}