using UnityEngine;
using System.Collections;

public class sounds : MonoBehaviour
{

    public AudioClip SoundToPlay1;
    public float Volume1;
    new AudioSource audio1;
   

    void OnTriggerEnter()
    {
        audio1 = GetComponent<AudioSource>();
        audio1.PlayOneShot(SoundToPlay1, Volume1);
            //alreadyPlayed = true;
        
        
        
    }
}