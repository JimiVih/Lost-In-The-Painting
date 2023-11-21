using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    EnemyCollider enemyCollider;

    NavMeshAgent agent;
    public Transform playerTrans;

    bool seePlayer;

    Quaternion lockRotation;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyCollider = GetComponentInChildren<EnemyCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = lockRotation;
        seePlayer = enemyCollider.seePlayer;

        if (seePlayer)
        {
            ChasePlayer();
        }
        
    }

    void ChasePlayer()
    {
        agent.SetDestination(playerTrans.position);
    }
}
