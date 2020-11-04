using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    public bool activate = false;
    public GameObject uiObject;
    // Start is called before the first frame update
    void Start()
    {
        uiObject.SetActive(false);
    }


    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {


        if (Input.GetKey(KeyCode.E) && other.tag == "Player")
        {
            
            activate = true;
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
