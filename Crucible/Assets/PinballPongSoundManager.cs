﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballPongSoundManager : MonoBehaviour
{

    public static PinballPongSoundManager S;

    private AudioSource a;

    public AudioClip wallBounceSound;
    public AudioClip paddleBounceSound;

    // Start is called before the first frame update
    void Awake()
    {
        // Singleton definition
        if (PinballPongSoundManager.S)
            Destroy(gameObject);
        else
            S = this; 

        a = gameObject.GetComponent<AudioSource>();
    }

    public void PlayWallBounceSound()
    {
        a.PlayOneShot(wallBounceSound);
    }

    public void PlayPaddleBounceSound()
    {
        a.PlayOneShot(paddleBounceSound);
    }
}
