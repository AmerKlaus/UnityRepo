using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Vector3 playerVelocity;
    Vector3 move;

    public float walkSpeed = 5;
    public float runSpeed = 8; 
    public float jumpHeight = 2;
    public int maxJumpCount = 1;
    public float gravity = -9.18f;
    public bool isGrounded;
    public bool isRunning;
    private CharacterController controller;
    private Animator animator;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    
    public void Update()
    {
        isGrounded = controller.isGrounded;
        // Only process input and movement if root motion is not applied
        if (!animator.applyRootMotion)
        {
            ProcessMovement();
        }
        
        // Always process gravity regardless of root motion
        ProcessGravity();
    }


    void ProcessMovement()
    { 
        move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // Turns the player toward where they want to go
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
        // Check input to know if running is getting pressed
        isRunning = Input.GetButton("Run");
        if (Input.GetButtonDown("Jump") && isGrounded) // Code to jump
        {
            playerVelocity.y +=  Mathf.Sqrt(jumpHeight * -3.0f * gravity);
        }
        controller.Move(move * Time.deltaTime * ((isRunning) ? runSpeed : walkSpeed));
    }

    public void ProcessGravity()
    {
        // Since there is no physics applied on character controller, apply gravity manually
        if (isGrounded)
        {
            if (playerVelocity.y < 0.0f) // Ensure player stays grounded when on the ground
            {
                playerVelocity.y = -1.0f;
            }
        }
        else // If not grounded
        {
            playerVelocity.y += gravity * Time.deltaTime;
        }

        controller.Move(playerVelocity * Time.deltaTime);
        
        
    }

    private void OnAnimatorMove()
    {
        // If root motion is enabled, apply the animation's motion directly to the controller
        if (animator.applyRootMotion)
        {
            Vector3 velocity = animator.deltaPosition;
            velocity.y = playerVelocity.y * Time.deltaTime; // Preserve vertical movement (gravity, jump)
            controller.Move(velocity);
        }
        
        
    }

    public float GetMoveSpeed()
    {
        if (isRunning && (move != Vector3.zero)) // Left shift is held for running
        {
            return runSpeed;
        }
        else if (move != Vector3.zero)
        {
            return walkSpeed;
        }
        else 
        {
            return 0f;
        }
    }
}
