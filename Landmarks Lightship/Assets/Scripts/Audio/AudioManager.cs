using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [Header ("-----Audio Source")]
    [SerializeField] AudioSource musicSource, sfxSource;

	[Header("-----Audio Clip")]
	public AudioClip playerFootsteps;
    public AudioClip hoverSound;
    public AudioClip clickSound;


	// Start is called before the first frame update
	private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Play();
    }

    public void Stop(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Stop();
    }

    public void PlaySFXOneShot(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public bool isPlaying()
    {
        if(sfxSource.isPlaying)
        {
            return true;
        }
        if(musicSource.isPlaying)
        {
            return true;
        }

        return false;
    }
}
