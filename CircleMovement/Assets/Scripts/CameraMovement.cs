using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject CenterFloor;
    public float speed;

    PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(CenterFloor.transform.position, Vector3.down, speed * Time.deltaTime);
            //playerMovement.transform.Translate(new Vector3(-1 * playerMovement.speedMove * Time.deltaTime, 0, 0), Space.Self);
            playerMovement.transform.RotateAround(playerMovement.playerCenterPoint.transform.position, Vector3.down, speed * Time.deltaTime);

        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(CenterFloor.transform.position, Vector3.up, speed * Time.deltaTime);
            //playerMovement.transform.Translate(new Vector3(1 * playerMovement.speedMove * Time.deltaTime, 0, 0), Space.Self);
            playerMovement.transform.RotateAround(playerMovement.playerCenterPoint.transform.position, Vector3.up, speed * Time.deltaTime);

        }
    }
}
