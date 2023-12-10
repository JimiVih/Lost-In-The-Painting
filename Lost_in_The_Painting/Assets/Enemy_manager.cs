using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_manager : MonoBehaviour
{
    NavMeshAgent agent;

    EnemyMovement e_move;
    EnemyCollider e_colScript;
    Attack_enemy e_attack;
    EnemyAI e_ai;

    Enemy_healthsystem e_healthsystem;

    public Transform hitbox;

    bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        e_ai = GetComponent<EnemyAI>();
        agent = GetComponent<NavMeshAgent>();
        e_healthsystem = GetComponent<Enemy_healthsystem>();
        e_move = GetComponent<EnemyMovement>();
        e_colScript = GetComponentInChildren<EnemyCollider>();
        e_attack = GetComponentInChildren<Attack_enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        isDead = e_healthsystem.isDead;

        if (isDead)
        {
            e_move.enabled = false;
            e_attack.enabled = false;
            e_colScript.enabled = false;
            e_ai.enabled = false;
            agent.enabled = false;
            hitbox.gameObject.SetActive(false);
        }
    }
}
