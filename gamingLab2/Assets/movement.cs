using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    public KeyCode Spacebar;
    public Transform groundCheck;
    public float groundCheckRadius;
    public KeyCode L;
    public KeyCode R;
    private bool grounded;
    public LayerMask WhatIsGrounded;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
       anim = GetComponent<Animator>();  
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(Spacebar) && grounded)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        }
        if(Input.GetKey(L))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        if(Input.GetKey(R))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }


         anim.SetFloat("speed",Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
         anim.SetFloat("Height", GetComponent<Rigidbody2D>().velocity.y);
         anim.SetBool("Grounded", grounded);

    }
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGrounded);
    }
}
