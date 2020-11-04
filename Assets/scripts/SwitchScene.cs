using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public GameObject Switch;
    private Switch script;
    public int Scene;
   

    // Start is called before the first frame update
    void Start()
    {
        script = Switch.GetComponent<Switch>();

    }

    // Update is called once per frame
    void Update()
    {
        if (script.switcher == true)
        {
            SceneSwitcher();
        }

    }

    public void SceneSwitcher()
    {
        Scene = SceneManager.GetActiveScene().buildIndex;
        Scene = Scene + 1;
        SceneManager.LoadScene(Scene); 
    }
}
