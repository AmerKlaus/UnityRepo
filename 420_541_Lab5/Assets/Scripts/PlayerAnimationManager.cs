using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement movement;
    public void Start()
    {
        animator = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
    }
    public void LateUpdate()
    {
        if (animator == null || movement == null)
        {
            return;
        }

        animator.SetFloat("CharacterSpeed", movement.GetMoveSpeed());
        animator.SetBool("IsFalling", !movement.isGrounded);
        if (Input.GetButtonUp("Fire1"))
        {
            animator.SetTrigger("doRoll");
        }
        if (Input.GetButtonUp("Fire2"))
        {
            animator.SetTrigger("doPunch");
        }


    }

}
