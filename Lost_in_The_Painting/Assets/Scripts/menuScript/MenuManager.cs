using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Animator Start, Quit;



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
        SceneManager.LoadScene("level_0");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
