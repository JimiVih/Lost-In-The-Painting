using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    GameMaster gm;
    PlayerMovement p_Move;
    PlayerAnimHandler p_AnimHandler;
    PlayerAttack p_Attack;

    HealthSystem_Player p_Health;

    bool p_IsDead;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

        transform.position = gm.lastCheckpointPos;
    }

    private void Start()
    {
    

        p_Move = GetComponent<PlayerMovement>();
        p_Attack = GetComponent<PlayerAttack>();
        p_Health = GetComponent<HealthSystem_Player>();
        p_Attack = GetComponent<PlayerAttack>();
    }
    private void Update()
    {
        p_IsDead = p_Health.isDead;

        if (p_IsDead)
        {
            p_Move.enabled = false;
            p_Attack.enabled = false;
            p_AnimHandler.enabled = false;
        }
    }
}
