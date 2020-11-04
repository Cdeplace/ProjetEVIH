using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dooropen : MonoBehaviour
{
    public GameObject button;
    private button script;
    private Animator _animator;
    public Material material;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        script = button.GetComponent<button>();
        _animator = GetComponent<Animator>();
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (script.activate == true)
        {
            
            rend.sharedMaterial = material;
       
            _animator.SetBool("Open", true);
        }
    }
}
