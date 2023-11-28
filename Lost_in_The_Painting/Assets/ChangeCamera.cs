using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform staticCamera;

    bool isStaticCam;

    private void Start()
    {
        if(this.transform.tag == "PlayerCamera")
        {
            isStaticCam = false;
        }
        if (this.transform.tag == "StaticCamera")
        {
            isStaticCam = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "Player")
        {
            if (isStaticCam)
            {
                playerCamera.transform.gameObject.SetActive(false);
                staticCamera.transform.gameObject.SetActive(true);
            }

            if (!isStaticCam)
            {
                staticCamera.transform.gameObject.SetActive(false);
                playerCamera.transform.gameObject.SetActive(true);
            }
        }
    }
}
