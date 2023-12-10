using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameMaster gm;

    private void Start()
    {
        gm = GameObject.FindObjectOfType<GameMaster>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            gm.lastCheckpointPos = transform.position;
        }
    }
}
