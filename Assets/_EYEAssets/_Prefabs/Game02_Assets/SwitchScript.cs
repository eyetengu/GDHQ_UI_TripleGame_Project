using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SwitchScript : MonoBehaviour
{
    [SerializeField] private Slider _switch;
    [SerializeField] private GameObject _onLight;
    [SerializeField] private AudioClip _switchFlipOn;
    [SerializeField] private AudioClip _switchFlipOff;
    private AudioSource _audioSource;
    private bool _isLightOn;

    void Start()
    {
        _audioSource = GameObject.Find("AudioManager").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        LightStatus();
    }

    public void SwitchAction()
    {
        _isLightOn = !_isLightOn;
        if(_isLightOn ) 
        { 
            _switch.value = 1; 
            _audioSource.PlayOneShot(_switchFlipOn);
        }
        else 
        { 
            _switch.value = 0;
            _audioSource.PlayOneShot(_switchFlipOff);
        }
    }

    private void LightStatus()
    {
        if(_switch.value == 0)
        {
            _onLight.SetActive(false);
        }
        else if(_switch.value == 1) 
        {
            _onLight.SetActive(true);
        }
    }
}
