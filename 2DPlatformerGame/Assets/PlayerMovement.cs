using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;
    private float horizontalMove = 0f;
    private bool jump = false;
    // private bool crouch = false;
    private float moveSpeed = 40f;



    private void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        horizontalMove = Input.GetAxisRaw("Horizontal") * moveSpeed;

        animator.SetFloat("speed", Mathf.Abs(horizontalMove));
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
}
