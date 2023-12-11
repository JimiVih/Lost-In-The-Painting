using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameMaster gm;
    Animator animator;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        gm = GameObject.FindObjectOfType<GameMaster>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            gm.lastCheckpointPos = transform.position;
            gm.CheckpointUsed = true;
            animator.SetBool("active", true);
        }
    }
}
