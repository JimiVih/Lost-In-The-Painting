using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public GameObject weaponHitboxObject;

    public float coolDownTime;
    float coolDownCounter;

    bool canAttack;
    bool attackButtonPressed;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(coolDownCounter > 0)
        {
            coolDownCounter -= Time.deltaTime;
            
        }
    }

    void Attack()
    {
        if(coolDownCounter == 0)
        {

        }
    }

}
