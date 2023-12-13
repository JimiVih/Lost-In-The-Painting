using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem_Player : MonoBehaviour
{
    GameOver_script gameOverSCRIPT;

    Animator animator;
    public AudioSource audioHit, audioDeath, audioSpikeDeath;
    public GameObject playerLight;
    public Image healthBar;

    float maxHealth = 1;
    public float health;
    public float recoveryTime; //player recovery after attack
    public float spikeRecoveryTime;

    public bool damageTaken = false;
    public bool isDead = false;
    public bool stopInputs;

    private void Awake()
    {
        
        gameOverSCRIPT = GameObject.FindAnyObjectByType<GameOver_script>();
    }
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

        if (health <= 0 && !isDead)
        {
            audioHit.Play();
            audioDeath.Play();
            isDead = true;
            animator.SetTrigger("Die");
            gameOverSCRIPT.GameOVER();
            print("You are dead!");
        }
        if (!isDead && !damageTaken)
        {
            audioHit.Play();
            animator.SetTrigger("GetHit");
            damageTaken = true;
            StartCoroutine(Recovery(recoveryTime));
            print("Damage taken");
        }
        
    }

    public void TakeDamageFromSpikes(float damageAmount)
    {
        
        health -= damageAmount;

        if (health <= 0 && !isDead)
        {
            audioSpikeDeath.Play();
            audioDeath.Play();
            isDead = true;
            stopInputs = true;
            animator.SetTrigger("Spike");
            animator.SetBool("IsDead", true);
            playerLight.SetActive(false);
            print("You are dead!");
            gameOverSCRIPT.GameOVER();
        }
        if (!isDead && !damageTaken)
        {
            audioSpikeDeath.Play();
            animator.SetTrigger("Spike");
            animator.SetBool("IsDead", true);
            damageTaken = true;
            stopInputs = true;
            playerLight.SetActive(false);
            StartCoroutine(RecoveryFromSpike(spikeRecoveryTime));
            print("Damage taken");
        }
    }

    IEnumerator Recovery(float recoveryTime)
    {
        yield return new WaitForSeconds(recoveryTime);
        damageTaken = false;
    }

    IEnumerator RecoveryFromSpike(float recoveryTime)
    {
        yield return new WaitForSeconds(recoveryTime);
        animator.SetTrigger("Spawn");
        animator.SetBool("IsDead", false);
        stopInputs = false;
        damageTaken = false;
        playerLight.SetActive(true);
    }
}
