using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayMusic();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayMusic()
    {
        if(!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    private void StopMusic()
    {
        if(audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void ToggleMusic()
    {
        if (audioSource.isPlaying)
        {
            StopMusic();
        }
        else
        {
            PlayMusic();
        }
    }
}
