using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changecolor : MonoBehaviour
{
    public int hitNumber = 0;
    public int hitDead = 5;
    public Vector3 pos;
    public GameObject particle;
    public Material material;
    public Material material2;
    Renderer rend;
    public bool ChangeMat;
    private GameObject go;


    void Start()
    {
        rend = GetComponent<Renderer>();
        go = GameObject.FindWithTag("go");

    }

    void Update()
    {
        if (ChangeMat == true)
        {
            rend.sharedMaterial = material;
            StartCoroutine("WaitForSec");
        }
        if (ChangeMat == false)
        {
            rend.sharedMaterial = material2;
        
        }

        if (hitNumber == hitDead)
        {
            Destroy(transform.parent.gameObject);
            Destroy(go);

        }
    }
    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Bullet"))
        {
            hitNumber++;
            ChangeMat = true;
            pos = transform.position;
            Instantiate(particle, pos, Quaternion.identity);


        }

       

    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(1);
        ChangeMat = false;


    }
}
