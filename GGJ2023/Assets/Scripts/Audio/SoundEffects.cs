using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundEffects : MonoBehaviour
{

    public AudioSource sfxSource;                   //Drag a reference to the audio source which will play the sound effects.
    public AudioSource musicSource;                 //Drag a reference to the audio source which will play the music.       
    public float lowPitchRange = .95f;              //The lowest a sound effect will be randomly pitched.
    public float highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.

    [SerializeField]
    AudioClip[] moo;
    [SerializeField]
    AudioClip cowbell;
    [SerializeField]
    AudioClip walkling;
    [SerializeField]
    AudioClip menuMusic;
    [SerializeField]
    AudioClip themeMusic;
    [SerializeField]
    AudioClip chaseMusic;

    float _maxVolume = 1.0f;

    private void Awake()
    {
        sfxSource = GetComponent<AudioSource>();
        SetVolume();
    }

    private void SetVolume()
    {
        throw new System.NotImplementedException();
    }

    private void OnEnable()
    {
        //subscribe to events
        FollowWayPoints.Chase += ChangeTheme;
    }


    private void OnDisable()
    {
        //unsubscribe to events
        FollowWayPoints.Chase -= ChangeTheme;
    }

    public void Moo()
    {
        RandomizeSfx(moo);
    }

    public void Cowbell()
    {
        PlaySingle(cowbell);
    }

    public void Stomp()
    {
        PlaySingle(walkling);
    }

    //Used to play single sound clips.
    public void PlaySingle(AudioClip clip)
    {
        //Set the clip of our efxSource audio source to the clip passed in as a parameter.
        sfxSource.clip = clip;

        //Play the clip.
        sfxSource.Play();
    }


    //RandomizeSfx chooses randomly between various audio clips and slightly changes their pitch.
    public void RandomizeSfx(params AudioClip[] clips)
    {
        //Generate a random number between 0 and the length of our array of clips passed in.
        int randomIndex = UnityEngine.Random.Range(0, clips.Length);

        //Choose a random pitch to play back our clip at between our high and low pitch ranges.
        float randomPitch = UnityEngine.Random.Range(lowPitchRange, highPitchRange);

        //Set the pitch of the audio source to the randomly chosen pitch.
        sfxSource.pitch = randomPitch;

        //Set the clip to the clip at our randomly chosen index.
        sfxSource.clip = clips[randomIndex];

        //Play the clip.
        sfxSource.PlayDelayed(.05f);
    }

    public void ChangeTheme()
    {
        if(musicSource != null && musicSource!= chaseMusic)
        {
            musicSource.clip = chaseMusic;
        }
        
    }

}
