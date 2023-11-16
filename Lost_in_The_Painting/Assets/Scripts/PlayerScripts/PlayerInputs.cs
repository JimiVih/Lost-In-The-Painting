using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    PlayerAttack playerAttack;
    public Vector3 moveDirection;

    public bool jumpButton;
    public bool keepJumping;
    public bool attack;
    bool cooldown;

    // Start is called before the first frame update
    void Start()
    {
        playerAttack = GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        cooldown = playerAttack.cooldown;
        HandleAllInputs();
    }

    void HandleAllInputs()
    {
        
        
        MoveInput();
        if (!cooldown)
        {
            JumpInput();
        }      
        AttackInput();
    }

    //reads Horizontal and Vertical inputs that are taken by the "moveDirection" Vector3
    void MoveInput()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.z = Input.GetAxisRaw("Vertical");
    }
    void JumpInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpButton = true;
            print("Jump!");
        }
        else
        {
            jumpButton = false;
        }

        //this is for jumpTime
        //if space is kept pressed, players up velocity will increase for a certain time
        //if space is let go, players up velocity will stop
        if (Input.GetKey(KeyCode.Space))
        {
            keepJumping = true;
        }
        if (Input.GetKeyUp(KeyCode.Space)) 
        {
            keepJumping = false;
        }
    }
    void AttackInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            attack = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            attack = false;
        }
    }
}
