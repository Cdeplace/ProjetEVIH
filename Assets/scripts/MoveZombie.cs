using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveZombie : MonoBehaviour
{
    public Transform goal;
   
    private UnityEngine.AI.NavMeshAgent agent;
    public float knockbackTime = 1;
    public float kick = 1.8f;
    private bool hit;
    private float timer;
    private int destPoint = 0;
    public Vector3 pos;
    public Light myLight;
   
    private float ShotTime = 0;
   

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

   
    // Update is called once per frame
    void Update()
    {
        if (myLight.spotAngle == 179)
        {

            agent.SetDestination(goal.position);
            



            if (hit == true)
            {
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = true;
                gameObject.GetComponent<Rigidbody>().AddForceAtPosition(Camera.main.transform.forward * kick, pos, ForceMode.Impulse);
                hit = false;
                timer = 0;
            }
            else
            {
                timer += Time.deltaTime;
                if (knockbackTime < timer)
                {
                    gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = false;

                }
            }

        }

    }


    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Bullet"))
        {


            hit = true;
            pos = transform.position;



        }
    }

 
}