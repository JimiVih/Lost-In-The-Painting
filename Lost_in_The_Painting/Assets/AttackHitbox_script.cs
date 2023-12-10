using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackHitbox_script : MonoBehaviour
{
    public PlayerAttack p_attack;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.transform.tag == "EnemyHitbox")
        {
            Enemy_healthsystem e_health = other.GetComponentInParent<Enemy_healthsystem>();
            p_attack.DoDamage(e_health);
            print("done damage to enemy");
        }
    }
}
