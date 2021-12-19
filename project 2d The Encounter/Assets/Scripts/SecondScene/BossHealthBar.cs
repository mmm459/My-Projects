using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    Image bossHealth;
    Image bossMaxHealth;

    public float scaleX;

    public float health;
    public float maxHealth;


    // Start is called before the first frame update
    void Start()
    {
        maxHealth = gameObject.GetComponent<BigBoss>().life;
        health = maxHealth;

        bossHealth = GameObject.Find("bossHealth").GetComponent<Image>();
        bossMaxHealth = GameObject.Find("bossMaxHealth").GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        scaleX = health / maxHealth;
        health = gameObject.GetComponent<BigBoss>().life;
        
        bossHealth.rectTransform.localScale = new Vector2(scaleX, 1);
    }
}
