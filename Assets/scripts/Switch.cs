using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool switcher = false;
    public GameObject uiObject;
    // Start is called before the first frame update
    void Start()
    {
        uiObject.SetActive(false);
    }


    // Update is called once per frame
    void OnTriggerStay(Collider other)
    {


        if (Input.GetKey(KeyCode.S) && other.gameObject.name == "Player")
        {
            switcher = true;
        }
        if (other.gameObject.name == "Player")
        {
            uiObject.SetActive(true);
            StartCoroutine("WaitForSec");
        }

    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);

        Destroy(uiObject);
    }


}
