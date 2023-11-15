using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGmusic : MonoBehaviour
{
    public static BGmusic instance;
    public AudioClip newMusicClip;
    public float volume;
    public bool loop;

    void Awake()
    {


        GameObject musicObject = GameObject.Find("Audio");
        if (musicObject != null)
        {
            DestroyImmediate(musicObject);
            GameObject newMusicObject = new GameObject("NewMusicObject");
            AudioSource audioSource = newMusicObject.AddComponent<AudioSource>();
            audioSource.clip = newMusicClip;
            audioSource.volume = volume;
            audioSource.loop = loop;
            audioSource.Play();
        }
    }
}
