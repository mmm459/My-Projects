using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BuildingAnimation : MonoBehaviour
{
    Animator animator;
    public GameObject commandCenter;
    BuildingsUI B1;

    public GameObject building;
    BuildBuilding buildBuilding;

    public AudioSource BuildingInProgres;

    private void Start()
    {
        GetComponentInParent<NavMeshObstacle>().enabled = true;
        commandCenter = GameObject.Find("CommandCenter");
        B1 = commandCenter.GetComponent<BuildingsUI>();
        buildBuilding = GetComponentInParent<BuildBuilding>();
        buildBuilding.enabled = false;
        animator = GetComponent<Animator>();
        animator.SetBool("isBuilding", true);
        BuildingInProgres.Play();
    }


    private void LateUpdate()
    {
        B1.enabled = false;
    }

    public void ConstructionSite()
    {
        Instantiate(building, transform.position, Quaternion.identity);
        Destroy(transform.parent.gameObject);
    }
}
