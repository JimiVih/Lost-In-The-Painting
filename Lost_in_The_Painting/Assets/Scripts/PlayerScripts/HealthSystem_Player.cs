using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem_Player : MonoBehaviour
{
    Animator animator;

    public Image healthBar;

    float maxHealth = 1;
    public float health;
    public float recoveryTime; //player recovery after attack
    public float spikeRecoveryTime;

    public bool damageTaken = false;
    public bool isDead = false;
    public bool stopInputs;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health;
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            isDead = true;
            animator.SetTrigger("Die");
            print("You are dead!");
        }
        if (!isDead && !damageTaken)
        {
            animator.SetTrigger("GetHit");
            damageTaken = true;
            stopInputs = true;
            StartCoroutine(Recovery(recoveryTime));
            print("Damage taken");
        }
        
    }

    public void TakeDamageFromSpikes()
    {
        health -= .3f;

        if (health <= 0)
        {
            isDead = true;
            stopInputs = true;
            animator.SetTrigger("Spike");
            animator.SetBool("IsDead", true);
            print("You are dead!");
        }
        if (!isDead && !damageTaken)
        {
            animator.SetTrigger("Spike");
            damageTaken = true;
            StartCoroutine(Recovery(spikeRecoveryTime));
            print("Damage taken");
        }
    }

    IEnumerator Recovery(float recoveryTime)
    {
        yield return new WaitForSeconds(recoveryTime);
        animator.SetTrigger("Spawn");
        animator.SetBool("IsDead", false);
        stopInputs = false;
        damageTaken = false;
    }
}
