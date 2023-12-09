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

    public bool damageTaken = false;
    public bool isDead = false;

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
