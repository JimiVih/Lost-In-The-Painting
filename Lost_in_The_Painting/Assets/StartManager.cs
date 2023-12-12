using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    public ScreenDialogManager introDialog;

    private void Start()
    {
        
    }

    public void StartIntro()
    {
        introDialog.StartIntro();
        print("StartIntro");
    }
}
