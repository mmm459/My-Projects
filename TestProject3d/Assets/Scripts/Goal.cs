using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public Text score;
    public int playerScore;
    public int compScroe;

    bool shot;

    private void Start()
    {
        playerScore = 0;
        compScroe = 0;
        score.text = "(" + playerScore.ToString() + "-" + compScroe.ToString() + ")";
        shot = false;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "(" + playerScore.ToString() + "-" + compScroe.ToString() + ")";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !shot)
        {
            playerScore++;
            shot = !shot;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
