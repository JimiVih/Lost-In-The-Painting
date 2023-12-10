using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    PlayerInputs playerInputs;
    PlayerMovement playerMovement;

    Animator animator;

    public SphereCollider attackHitbox;

    public float timeCounter;
    public float timerAmount;

    public float damageAmount;

    bool attack;
    public bool cooldown;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
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
            animator.SetTrigger("Attack");
            attackHitbox.enabled = true;
            cooldown = true;
        }
    }

    public void DoDamage(Enemy_healthsystem e_Health)
    {
        e_Health.TakeDamage(damageAmount);
    }

    void CooldownTimer()
    {
        if (cooldown)
        {
            
            timeCounter -= Time.deltaTime;
            if(timeCounter <= 0)
            {
                
                timeCounter = timerAmount;
                attackHitbox.enabled = false;
                cooldown = false;
            }
        }
    }
}
