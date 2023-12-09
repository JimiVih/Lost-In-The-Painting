using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    EnemyAI enemyAI;
    EnemyCollider m_EnemyCollider;
    public Transform enemySprite;
    public Transform playerTrans;

    public SphereCollider AttackHitbox;
    bool seePlayer;
    public bool facingRight;

    float spriteScale;
    private void Start()
    {
        spriteScale = enemySprite.localScale.x;
        enemyAI = GetComponent<EnemyAI>();
        playerTrans = enemyAI.playerTrans; 
        m_EnemyCollider = GetComponentInChildren<EnemyCollider>();
    }
    private void Update()
    {
        seePlayer = m_EnemyCollider.seePlayer;

        if (seePlayer)
        {
            FaceTowards();
        }
    }

    void FaceTowards()
    {
        if(transform.position.x > playerTrans.position.x)
        {
            facingRight = false;
            enemySprite.localScale = new Vector3(-spriteScale, enemySprite.localScale.y, enemySprite.localScale.z);
        }
        if(transform.position.x < playerTrans.position.x)
        {
            facingRight = true;
            enemySprite.localScale = new Vector3(spriteScale, enemySprite.localScale.y, enemySprite.localScale.z);
        }
    }
}
