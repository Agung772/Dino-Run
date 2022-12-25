using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager singleton;
    public AudioClip[] clips;
    AudioSource audiosoure;
    private void Awake()
    {
        singleton = this;
        audiosoure = GetComponent<AudioSource>();
    }
    public void PlaySound(int clipIndex)
    {
        audiosoure.PlayOneShot(clips[clipIndex]);
    }
}
