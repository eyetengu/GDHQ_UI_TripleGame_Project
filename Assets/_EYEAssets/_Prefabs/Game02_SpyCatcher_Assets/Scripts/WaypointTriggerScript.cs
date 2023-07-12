using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointTriggerScript : MonoBehaviour
{
    [SerializeField] private SpyBehavior _spyBehavior;
    [SerializeField] private AudioManager _audioManager;

    private void Start()
    {
        _spyBehavior = FindObjectOfType<SpyBehavior>();
        _audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Spy")
        {
            _spyBehavior.TriggerIsHiding();
        }
    }

    private void OnBecameInvisible()
    {
        _audioManager.PlayScoreDownClip();   

    }

    private void OnBecameVisible()
    {
        _audioManager.PlayScoreUpClip();
    }

}
