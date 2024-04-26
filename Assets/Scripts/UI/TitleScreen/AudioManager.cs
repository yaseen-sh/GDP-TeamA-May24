using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource music;
    private AudioSource buttonSfx;

    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("AudioManager").Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(transform.gameObject);
            music = GetComponents<AudioSource>()[0];
            buttonSfx = GetComponents<AudioSource>()[1];
        }
    }
    public void PlayMusic()
    {
        if (music.isPlaying) return;
        music.Play();
    }
    public void StopMusic()
    {
        music.Stop();
    }
    public void PlaySFX()
    {
        if (buttonSfx.isPlaying) return;
        buttonSfx.Play();
    }
}
