using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallwaySONG : MonoBehaviour
{
    public Animator animator;
    public AudioSource audio;
    public Animator[] animators;
    public AudioSource[] audioSources;

    public bool isParent;
    public bool isEnd;

    int i;

    private void Start()
    {
        if(isParent || isEnd)
        {
            return;
        }
        else
        {
            animator = GetComponent<Animator>();
            audio = GetComponent<AudioSource>();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isEnd && i == 0) 
            {
                foreach (var animator in animators)
                {
                    animator.SetTrigger("DownFast");
                }
                i++;
            }
            if (!isParent && i == 0) 
            {
               
               
                    audio.mute = false;
                    animator.SetTrigger("UpSlow");
                i++;
            }
            if (isParent && i == 0) 
            {
                foreach(var audio in audioSources)
                {
                    audio.Play();
                }
                i++;
            }
        }
       
        
    }
}
