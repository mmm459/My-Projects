using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alert : MonoBehaviour
{
    Text alert;
    Transform player;
    public float max = 10;
    public string text;
    bool read = false;

    // Update is called once per frame
    void Update()
    {
        //
        if (player == null)
        {
            player = GameObject.Find("Player").transform;
        }

        //
        if (alert == null)
        {
            alert = GameObject.Find("Alert").GetComponent<Text>();
        }

        float dist = Vector3.Distance(transform.position, player.position);

        if ( 1 > (dist / max) && read == false)
        {
            alert.text = text;
            read = true;
        }
        else if (read == true && (1 < (dist / max)))
        {
            read = false;
            alert.text = "";
        }

    }
    public void ClearText()
    {
        alert.text = "";
    }
}