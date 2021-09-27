using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource introMusic;
    public AudioSource backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        introMusic.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (!introMusic.isPlaying && !backgroundMusic.isPlaying) {
            backgroundMusic.Play();
            backgroundMusic.loop = true;
        }
    }
}
