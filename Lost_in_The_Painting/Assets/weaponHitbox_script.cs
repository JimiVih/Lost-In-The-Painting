using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponHitbox_script : MonoBehaviour
{

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Enemy")
        {
            DoDamage(collider.transform);
        }
    }

    void DoDamage(Transform enemy)
    {
        //get enemy health script
        print("Enemy took damage!");
    }
}
