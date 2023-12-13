using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameMaster gm;
    StartManager startManager;
    HealthSystem_Player healthSystem;

    public AudioSource music;

    public Transform Player;

    Vector3 checkpointPos;
    Vector3 playerPos;
    //UI elements\\
    public Transform playerUI;
    public Transform panel;
    public Transform GameOver_text;
    public Transform continue_text;
    //--------------------------\\

    bool canClick;
    public bool playIntro;

    // Start is called before the first frame update
    void Start()
    {
        healthSystem = Player.GetComponent<HealthSystem_Player>();
        StartCoroutine(Check());
    }

  

    IEnumerator Check()
    {
        yield return new WaitForSeconds(2);
        print("Checking");
        gm = GameObject.FindAnyObjectByType<GameMaster>();
        startManager = GameObject.FindAnyObjectByType<StartManager>();
        print(gm.CheckpointUsed);

        if (gm && startManager != null)
        {
            if (gm.CheckpointUsed == true)
            {
                playIntro = false;
                ContinueGame();
            }
            if (gm.CheckpointUsed == false)
            {
                playIntro = true;
                startManager.StartIntro();

            }
        }
        else
        {
            Check();
        }

    }

    void ContinueGame()
    {
        checkpointPos = gm.lastCheckpointPos;
        playerPos = checkpointPos;
        

        print("lastCheckpointPos: " + gm.lastCheckpointPos);
        print("checkpointPos: " + checkpointPos);
        print("playerPos: "+ playerPos);

        
        if(playerPos != checkpointPos)
        {
            
            ContinueGame();
        }
        else
        {

            Player.transform.position = playerPos;
            print("player.position: " + Player.position);
            print("playerPos: " + playerPos);
            Player.GetComponent<PlayerManager>().EnableInputs();
            StartCoroutine(FadeInPanel());
        }


    }

    IEnumerator FadeInPanel()
    {
        music.Play();
        yield return new WaitForSeconds(1.5f);
        panel.GetComponent<Animator>().SetTrigger("FadeIn");
    }
    
}
