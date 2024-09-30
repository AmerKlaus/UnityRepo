using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{

    private AudioSource audioSource;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPunchSound()
    {
        audioSource.Play();
    }
}


