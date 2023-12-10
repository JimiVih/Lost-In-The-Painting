using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_healthsystem : MonoBehaviour
{
    Animator animator;

    public float maxHealth;
    public float recoveryTime;
    public float health;

    public bool isDead;
    public bool damageTaken;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if (!isDead)
        {
            animator.SetTrigger("GetHit");
            damageTaken = true;
            StartCoroutine(Recovery());
            print("Damage taken");
        }

    }

    IEnumerator Recovery()
    {
        yield return new WaitForSeconds(recoveryTime);
        damageTaken = false;
    }
}
