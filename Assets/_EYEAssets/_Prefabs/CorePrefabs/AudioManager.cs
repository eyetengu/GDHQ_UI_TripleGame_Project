using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //[SerializeField] AudioSource _audioSource;
    [SerializeField] private AudioSource _audioSourceMusic;
    [SerializeField] private AudioSource _audioSourceGeneral;

    [SerializeField] private AudioClip[] _musicClips;
    [SerializeField] private AudioClip[] _audioClips;

    void Start()
    {
        if (_audioSourceMusic == null)
            _audioSourceMusic = GameObject.Find("MusicManager").GetComponent<AudioSource>();

        if (_audioSourceGeneral == null)
            _audioSourceGeneral = GameObject.Find("GeneralAudioManager").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Music Audio Functions
    public void PlayBackgroundMusic()
    {
        _audioSourceMusic.PlayOneShot(_musicClips[0]);
    }    

    //General Audio Functions
    public void PlayGameOverClip()
    {
        _audioSourceGeneral.PlayOneShot(_audioClips[0]);
    }

    public void PlayPlayerWinClip()
    {
        _audioSourceGeneral.PlayOneShot(_audioClips[5]);
    }

    public void PlayScoreUpClip()
    {
        _audioSourceGeneral.PlayOneShot(_audioClips[1]);

    }

    public void PlayScoreDownClip()
    {
        _audioSourceGeneral.PlayOneShot(_audioClips[2]);

    }

    public void FlipSwitchOn()
    {
        _audioSourceGeneral.PlayOneShot(_audioClips[3]);
    }

    public void FlipSwitchOff()
    {
        _audioSourceGeneral.PlayOneShot(_audioClips[4]);
    }


}
