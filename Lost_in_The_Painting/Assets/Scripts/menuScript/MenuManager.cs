using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Animator Start, Quit;
    public Transform panel;
    public float FadeTime;

    public void HoverStart()
    {
        Start.SetBool("hover", true);
    }
    public void ExitStart()
    {
        Start.SetBool("hover", false);
    }

    public void HoverQuit()
    {
        Quit.SetBool("hover", true);
    }
    public void ExitQuit()
    {
        Quit.SetBool("hover", false);
    }

    public void StartGame()
    {
        StartCoroutine(FadeAnimationStart());
    }
    public void QuitGame()
    {
        StartCoroutine(FadeAnimationQuit());
        
    }

    IEnumerator FadeAnimationStart()
    {
        panel.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(FadeTime);
        SceneManager.LoadScene("level_0");
    }
    IEnumerator FadeAnimationQuit()
    {
        panel.GetComponent<Animator>().SetTrigger("FadeOut");
        yield return new WaitForSeconds(FadeTime);
        Application.Quit();
    }
}
