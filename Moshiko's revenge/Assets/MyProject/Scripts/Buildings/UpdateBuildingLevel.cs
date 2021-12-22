using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateBuildingLevel : MonoBehaviour
{
    public Text level;
    public int numLevel;
    public int upgradeCost;

    // Start is called before the first frame update
    void Start()
    {
        numLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        level.text = "level:" + " " + numLevel.ToString();
    }

    public void ShowLevelInUI()
    {
        numLevel++;
    }
}