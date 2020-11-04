using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorswitch : MonoBehaviour
{
    public GameObject button;
    private button script;
    private Animator _animator;
    public int Scene;

    // Start is called before the first frame update
    void Start()
    {
        script = button.GetComponent<button>();
        _animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (script.activate == true)
        {
            
            _animator.SetBool("Open", true);
            StartCoroutine("WaitForSec");
        }
    }

    IEnumerator WaitForSec()
    {
        yield return new WaitForSeconds(5);
        Scene = SceneManager.GetActiveScene().buildIndex;
        Scene = Scene + 1;
        SceneManager.LoadScene(Scene);

    }
}
