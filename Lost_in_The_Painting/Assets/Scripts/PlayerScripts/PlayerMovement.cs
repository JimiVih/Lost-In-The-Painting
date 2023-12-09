using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerInputs playerInputs;
    PlayerAttack playerAttack;
    HealthSystem_Player healthSystem;

    CharacterController controller;
    Animator animator;

    public Transform groundCheck;
    public Transform playerSprite;
    public LayerMask whatIsGround;

    float horizontalMovement;
    float verticalMovement;
    float jumpTimeCounter;
    float playerDefaultScaleX;

    public float playerFallSpeed = -9.81f;
    public float radius;
    public float gravityMultiplier;
    public float jumpTime;
    public float walkingSpeed;
    public float runningSpeed;
    float moveSpeed;
    public float jumpForce;
    float originalMoveSpeed;

    int canRun;

    public bool isGrounded;
    bool jumpButton;
    bool keepJumping;
    bool facingRight = true;
    bool running;
    bool damageTaken;
    bool cooldown;


    Vector3 moveDirection;
    public Vector3 velocity;

    private void Start()
    {
        healthSystem = GetComponent<HealthSystem_Player>();
        originalMoveSpeed = moveSpeed;
        playerAttack = GetComponent<PlayerAttack>();
        animator = GetComponentInChildren<Animator>();
        playerInputs = GetComponent<PlayerInputs>();
        controller = GetComponent<CharacterController>();
        playerDefaultScaleX = playerSprite.localScale.x;
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, radius, whatIsGround);
        moveDirection = playerInputs.moveDirection;
        HandleInputBools();        
        HandleAll();


    }

    void HandleAll()
    {
        
        Movement();
        FlipPlayer();

            
        
    }

    //all player movement is here: Jumping, falling, and walking etc.
    void Movement()
    {
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
            jumpTimeCounter = jumpTime;
            gravityMultiplier = 1;
        }

        if (!isGrounded)
        {
            velocity.y += playerFallSpeed * Time.deltaTime;
        }

        if (!damageTaken)
        {
            if (!running || isGrounded)
            {
                canRun = 0;
                animator.SetFloat("canRun", canRun);
                moveSpeed = walkingSpeed;
            }
            if (running && isGrounded)
            {
                canRun = 1;
                animator.SetFloat("canRun", canRun);
                moveSpeed = runningSpeed;

            }
        }
        if (damageTaken || cooldown)
        {
            canRun = 0;
            animator.SetFloat("canRun", canRun);
            moveSpeed = 3;
        }
        

        PlayerJump();

        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
        controller.Move(velocity * gravityMultiplier * Time.deltaTime);
    }

    void PlayerJump()
    {
        if (isGrounded && jumpButton)
        {
            animator.SetTrigger("jump");
            velocity.y = Mathf.Sqrt(jumpForce * -2f * playerFallSpeed);
            gravityMultiplier = 3;
            print("JUMPING!");
        }

        if(keepJumping && jumpTimeCounter > 0)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * playerFallSpeed);
            jumpTimeCounter -= Time.deltaTime;
            print("Keep Jumping!");
        }
        else
        {
            jumpTimeCounter = 0;
        }
    }


    //Flips players sprite gameobjects X scale
    void FlipPlayer()
    {
        //takes the current moving direction the player is going
        float playerDirection = moveDirection.x;

        if (playerDirection == 1 && facingRight == false)
        {
            playerSprite.localScale = new Vector3(playerDefaultScaleX, playerSprite.localScale.y, playerSprite.localScale.z);
            facingRight = true;
        }
        else if (playerDirection == -1 && facingRight == true)
        {
            playerSprite.localScale = new Vector3(-playerDefaultScaleX, playerSprite.localScale.y, playerSprite.localScale.z);
            facingRight = false;
        }
    }


    //Handles InputBools, that are not affected by this script
    void HandleInputBools()
    {
        jumpButton = playerInputs.jumpButton;  
        keepJumping = playerInputs.keepJumping;
        running = playerInputs.runButton;
        damageTaken = healthSystem.damageTaken;
        cooldown = playerAttack.cooldown;
        
    }
}
