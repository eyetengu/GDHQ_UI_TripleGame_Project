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
    private bool _isLightOn;

    [SerializeField] private AudioManager _audioManager;

    void Start()
    {
        Debug.Log("SwitchScript started");
        //_audioSource = GameObject.Find("AudioManager").GetComponent<AudioSource>();
        if (_audioManager == null)
            _audioManager = FindObjectOfType<AudioManager>();
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
            _audioManager.FlipSwitchOn();
        }
        else 
        { 
            _switch.value = 0;
            _audioManager.FlipSwitchOff();
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
