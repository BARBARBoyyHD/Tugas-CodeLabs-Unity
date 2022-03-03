using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{

    Rigidbody rb;
    
    CharacterController controller;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] Transform groundcheck;
    [SerializeField] LayerMask ground;
   
     
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalinput = Input.GetAxis("Horizontal");
        float verticalinput = Input.GetAxis("Vertical");
        

        rb.velocity = new Vector3(horizontalinput * movementSpeed, rb.velocity.y, verticalinput * movementSpeed);



        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jump();
        }
        
    }

    void jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }
    
    bool IsGrounded()
    {
        return Physics.CheckSphere(groundcheck.position, .1f, ground);
    }
}
