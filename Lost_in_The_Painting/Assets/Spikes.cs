using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    Transform playerTrans;
    public Transform spawnPoint;

    public bool oneShot_Spikes;
    public float spawnTime;
    float damageAmount = 1;

    public Vector3 SpawnPosition;

    private void Start()
    {
        SpawnPosition = spawnPoint.position;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!oneShot_Spikes)
            {
                playerTrans = other.transform;
                HealthSystem_Player p_health = other.GetComponent<HealthSystem_Player>();
                p_health.TakeDamageFromSpikes(.3f);
                if(p_health.isDead == false)
                {
                    StartCoroutine(SpawnPlayer());
                }
                
            }
            if (oneShot_Spikes)
            {
                HealthSystem_Player p_health = other.GetComponent<HealthSystem_Player>();
                p_health.TakeDamageFromSpikes(damageAmount);
            }
            
        }
    }

    IEnumerator SpawnPlayer()
    {
        yield return new WaitForSeconds(spawnTime);
        
        
        playerTrans.position = SpawnPosition;
        
    }

}
