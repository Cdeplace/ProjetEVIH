using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{




    bool alreadyAttacked;
    public GameObject bulletPrefab;
    public Transform player;
    public Light myLight;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (myLight.spotAngle == 179)
        {

            
            AttackPlayer();
        }
    }

            private void AttackPlayer()
    {
        transform.LookAt(player);

        if (!alreadyAttacked)
        {
            Rigidbody rb = Instantiate(bulletPrefab, transform.position, transform.rotation).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8, ForceMode.Impulse);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), 1);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}