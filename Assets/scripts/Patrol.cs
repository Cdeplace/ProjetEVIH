
using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class Patrol : MonoBehaviour
{

    public Transform[] points;
    public float knockbackTime = 1;
    public float kick = 1.8f;
    private bool hit;
    private float timer;
    private int destPoint = 0;
    private NavMeshAgent agent;
    public Vector3 pos;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = knockbackTime;
        agent.autoBraking = false;
        GotoNextPoint();

    }


    void GotoNextPoint()
    {
        // Returns if no points have been set up
        if (points.Length == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = points[destPoint].position;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        destPoint = (destPoint + 1) % points.Length;
    }


    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();

        if (hit == true)
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<NavMeshAgent>().isStopped = true;
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
                gameObject.GetComponent<NavMeshAgent>().isStopped = false;
               
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