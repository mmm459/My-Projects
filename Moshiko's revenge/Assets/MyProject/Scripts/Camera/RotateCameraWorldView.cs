using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCameraWorldView : MonoBehaviour
{
    public GameObject mainCamera;

    public void EndAnimation()
    {
        mainCamera.SetActive(true);
        Destroy(gameObject);
    }
}
