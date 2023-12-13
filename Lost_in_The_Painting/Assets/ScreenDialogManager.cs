using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScreenDialogManager : MonoBehaviour
{
    public HealthSystem_Player healthSystem;

    public Animator animator;
    Animator panelAnimator;

    public Transform panel;

    public TMP_Text dialog;
    public TMP_Text instructions;
    public string[] text;
    int currentText;
    public float writingSpeed;
    public float waitTime;//wait time before user can click mouse button;

    bool canClick;

    private void Start()
    {
        panelAnimator = panel.GetComponent<Animator>();
    }

    private void Update()
    {
        if (canClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(FadeOutText());
                canClick = false;
            }
        }
    }

    public void StartIntro()
    {
        canClick = false;
        currentText = 0;
        StartCoroutine(WriteText());
    }

    IEnumerator WriteText()
    {
        
        dialog.text = "";
        animator.SetBool("FadeIn", true);
        dialog.text = text[currentText];
        currentText++;
        yield return new WaitForSeconds(waitTime);
        instructions.text = "Click Left Mouse";
        canClick = true;
    }

    IEnumerator FadeOutText()
    {
        instructions.text = "";
        animator.SetBool("FadeIn", false);
        yield return new WaitForSeconds(4);
        if(currentText > text.Length - 1)
        {
            panelAnimator.SetTrigger("FadeIn");
            healthSystem.stopInputs = false;
        }
        else
        {
            StartCoroutine(WriteText());
        }
        
    }
}
