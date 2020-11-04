using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLight : MonoBehaviour
{
    public Light myLight;
    public GameObject uiObject;

    void Start()
    {
        uiObject.SetActive(false);
    }
    void OnTriggerStay(Collider other)
    {


        if (Input.GetKey(KeyCode.E) && other.tag == "Player")
        {
            myLight.spotAngle = 179;
        }

        if (other.gameObject.name == "Player")
        {
            uiObject.SetActive(true);
            StartCoroutine("WaitForSec");
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(2);

        Destroy(uiObject);
    }


}