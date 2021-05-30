using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// MusicForIntro class in respnsible for the music playing in the background of "Introduction" Scene
public class MusicForIntro : MonoBehaviour
{   
    /// @param BackgroundAudio is the music for "Introduction" Scene
    public AudioSource BackgroundAudio;

    /// Start is called before the first frame update
    /// Start function here is responsible for playing the music
    void Start()
    {
        BackgroundAudio.Play();
    }
}
