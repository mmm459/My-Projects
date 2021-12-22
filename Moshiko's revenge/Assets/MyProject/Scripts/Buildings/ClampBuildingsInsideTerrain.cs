using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClampBuildingsInsideTerrain : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, 0, 195), transform.position.y, Mathf.Clamp(transform.position.z,5,195));
    }
}
