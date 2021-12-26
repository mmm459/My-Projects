using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    Transform player;
    ManagerEngine managerEngine;
    Rigidbody rb;


    private float forceMagnitude;
    public float force, enemySpeed;
    bool isForce;

    Vector3 hitDir;
    Vector3 forceToAplly;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isForce = false;
        managerEngine = FindObjectOfType<ManagerEngine>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        forceToAplly = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        CheckIfFall();
    }

    public void FollowPlayer()
    {
        //look at player
        transform.rotation = Quaternion.Slerp(transform.rotation
                                                , Quaternion.LookRotation(player.position - transform.position)
                                                , enemySpeed * Time.deltaTime);
        //move to player
        transform.position += transform.forward * enemySpeed * Time.deltaTime;
        

        /*Vector3 dirToPlayer = player.transform.position - transform.position;
        forceToAplly = enemySpeed * dirToPlayer.normalized;*/
    }

    public void CheckIfFall()
    {
        if(transform.position.y < -5 || player.transform.position.y <= -3)
        {
            Destroy(gameObject);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rigidbody = hit.collider.attachedRigidbody;

        if (rigidbody != null)
        {
            Vector3 forceDir = hit.gameObject.transform.position - transform.position;
            forceDir.y = 0;
            forceDir.Normalize();

            rigidbody.AddForceAtPosition(forceDir * forceMagnitude, transform.position, ForceMode.Impulse);
            
            if(!isForce)
            {
                Invoke("StopForce", 3);
                isForce = true;
            }
        }
    }

    public void StopForce()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        isForce = false;
    }

    private void OnDestroy()
    {
        managerEngine.enemyCounter--;
        managerEngine.CheckIfNOMoreEnemies();
    }
}
