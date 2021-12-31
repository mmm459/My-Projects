using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public Button Button;
    float alpha;

    // Start is called before the first frame update
    void Start()
    {
        alpha = 0;
        StartCoroutine(Fade());
        Button.interactable = false;
    }
    
    IEnumerator Fade()
    {
        yield return new WaitForSeconds(0.1f);
        Button.GetComponentInChildren<Text>().color = new Color(1, 1, 1, alpha);
        alpha += 0.02f;
        StartCoroutine(Fade());
    }

    private void Update()
    {
        if(alpha >= 1)
        {
            Button.interactable = true;
        }
    }
}
