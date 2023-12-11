using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    bool used;
    private void Awake()
    {
        if (used)
        {
            DontDestroyOnLoad(this);
        }
        used = true;
        
    }
}
