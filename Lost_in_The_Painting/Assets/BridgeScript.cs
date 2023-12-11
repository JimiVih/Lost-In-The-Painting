using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeScript : MonoBehaviour
{
    Animator animator;

    public BoxCollider trigger, floor;
    GameObject parent;

    private void Start()
    {
        
        animator = GetComponentInChildren<Animator>();
        trigger = GetComponent<BoxCollider>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            print("PlayerHit");
            StartCoroutine(FallBridge());
        }
    }

    IEnumerator FallBridge()
    {
        //yield return new WaitForSeconds(.2f);
        animator.SetBool("Fall", true);
        yield return new WaitForSeconds(.8f);
        trigger.enabled = false;
        floor.enabled = false;
    }
}
