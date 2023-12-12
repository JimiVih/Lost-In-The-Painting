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
    bool stopInput;

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();

    }

    private void Start()
    {
    
        p_AnimHandler = GetComponent<PlayerAnimHandler>();
        p_Move = GetComponent<PlayerMovement>();
        p_Attack = GetComponent<PlayerAttack>();
        p_Health = GetComponent<HealthSystem_Player>();
        p_Attack = GetComponent<PlayerAttack>();
    }
    private void Update()
    {
        p_IsDead = p_Health.isDead;
        stopInput = p_Health.stopInputs;
        if (p_IsDead || stopInput)
        {
            p_Move.enabled = false;
            p_Attack.enabled = false;
            p_AnimHandler.enabled = false;
        }
        if (!stopInput)
        {
            p_Move.enabled = true;
            p_Attack.enabled = true;
            p_AnimHandler.enabled = true;
        }

        
    }

    public void EnableInputs()
    {
        StartCoroutine(enableInp());
    }

    IEnumerator enableInp()
    {
        yield return new WaitForSeconds(2);
        transform.GetComponent<HealthSystem_Player>().stopInputs = false;
    }

}
