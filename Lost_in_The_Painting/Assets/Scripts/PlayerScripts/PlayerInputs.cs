using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputs : MonoBehaviour
{
    public Vector3 moveDirection;

    public bool jumpButton;
    public bool keepJumping;
    public bool attackButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleAllInputs();
    }

    void HandleAllInputs()
    {
        MoveInput();
        JumpInput();
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
}
