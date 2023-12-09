using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_enemy : MonoBehaviour
{
    public float damageAmount = 0.2f;

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            HealthSystem_Player playerHealth= other.GetComponentInParent<HealthSystem_Player>();

            playerHealth.TakeDamage(damageAmount);
        }
    }
}
