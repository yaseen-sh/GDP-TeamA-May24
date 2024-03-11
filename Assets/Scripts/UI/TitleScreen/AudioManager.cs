using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource music;

    void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("AudioManager").Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(transform.gameObject);
            music = GetComponent<AudioSource>();
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
}
