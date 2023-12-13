using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndingScript : MonoBehaviour
{
    public HealthSystem_Player healthSystem;
    GameMaster gm;

    public GameObject panelWhite;
    public GameObject panelBlack;

    public Animator animatorWhite, animatorBlack, dialogAnimator;
    public Animator musicFade, rainFade;

    public TMP_Text dialog;
    public TMP_Text instructions;
    public string[] text;
    int currentText;
    public float writingSpeed;
    public float waitTime;//wait time before user can click mouse button;

    bool canClick;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindAnyObjectByType<GameMaster>();
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

    IEnumerator FadeInPanel()
    {
        panelWhite.SetActive(true);
        animatorWhite.SetTrigger("FadeOut");
        yield return new WaitForSeconds(5);
        StartCoroutine(WriteText());
    }

    IEnumerator WriteText()
    {

        dialog.text = "";
        dialogAnimator.SetBool("FadeIn", true);
        dialog.text = text[currentText];
        currentText++;
        yield return new WaitForSeconds(waitTime);
        instructions.text = "Click Left Mouse";
        canClick = true;
    }

    IEnumerator FadeOutText()
    {
        instructions.text = "";
        dialogAnimator.SetBool("FadeIn", false);
        yield return new WaitForSeconds(4);
        if (currentText > text.Length - 1)
        {
            panelBlack.SetActive(true);
            animatorBlack.SetTrigger("FadeOut");
            musicFade.SetTrigger("DownSlow");
            rainFade.SetTrigger("DownSlow");
            StartCoroutine(QuitToMenu());
        }
        else
        {
            StartCoroutine(WriteText());
        }

    }

    IEnumerator QuitToMenu()
    {
        gm.CheckpointUsed = false;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Menu");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            healthSystem.stopInputs = true;
            StartCoroutine(FadeInPanel());
        }
    }
}
