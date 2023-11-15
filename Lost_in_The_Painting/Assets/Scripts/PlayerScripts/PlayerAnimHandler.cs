using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimHandler : MonoBehaviour
{
    PlayerInputs playerInputs;
    PlayerMovement playerMovement;
    public Animator animator;

    float moveSpeed;
    float fallingSpeed;

    bool grounded;


    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerInputs = GetComponent<PlayerInputs>();
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleFloats();
    }

    void HandleFloats()
    {
        if (playerInputs.moveDirection.x > 0 || playerInputs.moveDirection.z > 0)
        {
            moveSpeed = 1;
        }
        else if (playerInputs.moveDirection.x < 0 || playerInputs.moveDirection.z < 0)
        {
            moveSpeed = 1;
        }
        else
        {
            moveSpeed = 0;
        }

        fallingSpeed = playerMovement.velocity.y;

        grounded = playerMovement.isGrounded;

        animator.SetFloat("fall", fallingSpeed);
        animator.SetFloat("velocity", moveSpeed);
        animator.SetBool("grounded", grounded);
        
    }
}
