using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_PlaySound : MonoBehaviour
{
    public AudioSource audioSource;

    public void playThisSound()
    {
        audioSource.Play();
    }

}
