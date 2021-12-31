using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeText : MonoBehaviour
{
    public Text logo;
    float alpha;

    void Start()
    {
        alpha = 0;
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        yield return new WaitForSeconds(0.1f);
        logo.color = new Color(1, 1, 1, alpha);
        alpha += 0.02f;
        StartCoroutine(Fade());
    }
}
