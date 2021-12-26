using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float forceMagnitude;

    public float speedMove, vertical;
    public GameObject playerCenterPoint;
    public GameObject startPosition;
    public Transform cameraTrn;
    public Transform player;
    [HideInInspector]
    public Rigidbody rb;
    public bool isCirclePower;


    // Start is called before the first frame update
    void Start()
    {
        isCirclePower = false;
        rb = GetComponent<Rigidbody>();
        //circleSpeed = 40;
        //speedMove = 8;
        transform.position = startPosition.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxis("Vertical") * speedMove * Time.deltaTime;
        rb.AddForce(cameraTrn.forward * vertical);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            //transform.Translate(new Vector3(0,0, 1 * speedMove * Time.deltaTime),Space.Self);
            //transform.RotateAround(playerCenterPoint.transform.position, Vector3.back, circleSpeed * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.DownArrow))
        {
            //transform.Translate(new Vector3(0, 0, -1 * speedMove * Time.deltaTime), Space.Self );
            //transform.RotateAround(playerCenterPoint.transform.position, Vector3.forward, circleSpeed * Time.deltaTime);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigidbody = hit.collider.attachedRigidbody;

        if(rigidbody != null)
        {
            Vector3 forceDir = hit.gameObject.transform.position - transform.position;
            forceDir.y = 0;
            forceDir.Normalize();

            if(hit.gameObject.tag == "Enemy")
            {
                forceMagnitude = 200;
                if(isCirclePower)
                {
                    forceMagnitude *= 10;
                }
            }

            rigidbody.AddForceAtPosition(forceDir * forceMagnitude, transform.position, ForceMode.Impulse);
        }
    }
}