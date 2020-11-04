using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{
    public float speed = 5;
    public float jumpPower = 4;
    Rigidbody rb;
    CapsuleCollider col;
    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }
    // Update is called once per frame
    void Update()
    {
        
        float Horizontal = Input.GetAxis("Horizontal") * speed;
        float Vertical = Input.GetAxis("Vertical") * speed;
        Horizontal *= Time.deltaTime;
        Vertical *= Time.deltaTime;
        transform.Translate(Horizontal, 0, Vertical);
        if (isGrounded() && Input.GetButtonDown("Jump"))
        {
             rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }
        if (Input.GetKeyDown("escape"))
           Cursor.lockState = CursorLockMode.None;
    }
    private bool isGrounded()
    {
        return Physics.Raycast(transform.
        position, Vector3.down, col.bounds.extents.y
        + 0.1f);
    }
}