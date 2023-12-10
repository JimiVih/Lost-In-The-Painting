using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HealthSystem_Player p_health = other.GetComponent<HealthSystem_Player>();
            p_health.TakeDamageFromSpikes();
        }
    }

}
