using UnityEngine;
using System.Collections;


public class soundBall : MonoBehaviour
{

    public AudioClip SoundToPlay;
    public float Volume;
    new AudioSource audio;
    public bool alreadyPlayed = false;

  
    void OnTriggerEnter()
    {
        if (!alreadyPlayed)
        {
            audio = GetComponent<AudioSource>();
            audio.PlayOneShot(SoundToPlay, Volume);
            alreadyPlayed = true;
        }


    }
}