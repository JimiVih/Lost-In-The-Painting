using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    PlayerInputs playerInputs;
    PlayerMovement playerMovement;

    public SphereCollider attackHitbox;

    public float timeCounter;
    public float timerAmount;

    bool attack;
    public bool cooldown;
    // Start is called before the first frame update
    void Start()
    {
        timeCounter = timerAmount;
        playerMovement = GetComponent<PlayerMovement>();
        playerInputs = GetComponent<PlayerInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        attack = playerInputs.attack;
        Attack();
        CooldownTimer();
    }

    void Attack()
    {
        if (!cooldown && attack && playerMovement.isGrounded)
        {
            attackHitbox.enabled = false;
            cooldown = true;
        }
    }
    void CooldownTimer()
    {
        if (cooldown)
        {
            Debug.Log("cooldown started");
            timeCounter -= Time.deltaTime;
            if(timeCounter <= 0)
            {
                Debug.Log("cooldown ended");
                timeCounter = timerAmount;
                attackHitbox.enabled = true;
                cooldown = false;
            }
        }
    }
}
