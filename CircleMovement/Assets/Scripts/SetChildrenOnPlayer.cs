using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetChildrenOnPlayer : MonoBehaviour
{
    public GameObject player;

    PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        Destroy(gameObject,10);
    }

    private void Awake()
    {
        player = GameObject.Find("Player");
        transform.SetParent(player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        //mean the object will stop rotate and freez on his own rotation
        transform.rotation = Quaternion.identity;
        transform.position = player.transform.position;
    }

    private void OnDestroy()
    {
        playerMovement.isCirclePower = false;
    }
}
