using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCam_onTrig : MonoBehaviour
{
    public GameObject PlayerCam, OtherCam;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OtherCam.SetActive(true);
            PlayerCam.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCam.SetActive(true);
            OtherCam.SetActive(false);
        }
    }
}
