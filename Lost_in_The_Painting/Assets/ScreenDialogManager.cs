using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScreenDialogManager : MonoBehaviour
{
    public Animator animator;

    public TMP_Text dialog;
    public TMP_Text instructions;
    public string[] text;
    int currentText;
    public float writingSpeed;
    public float waitTime;//wait time before user can click mouse button;

    bool canClick;
    private void Start()
    {
        canClick = false;
        currentText = 0;
        StartCoroutine(WriteText());
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

    IEnumerator WriteText()
    {
        
        dialog.text = "";
        animator.SetBool("FadeIn", true);
        foreach (char c in text[currentText])
        {
            
            dialog.text += c;
            yield return new WaitForSeconds(writingSpeed);
        }
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
        if(currentText > text.Length)
        {

        }
        StartCoroutine(WriteText());
    }
}
