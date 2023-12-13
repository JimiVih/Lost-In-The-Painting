using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteMusic : MonoBehaviour
{
    public AudioSource music;
    public Animator musicAnim;

    int i;

    private void OnTriggerEnter(Collider other)
    {
        if (i == 0 && other.CompareTag("Player"))
        {
            StartCoroutine(FadeMusic());
        }
    }

    IEnumerator FadeMusic()
    {
        musicAnim.SetTrigger("DownSlow");
        yield return new WaitForSeconds(4);
        music.Stop();
    }
}
