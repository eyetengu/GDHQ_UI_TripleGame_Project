using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBlink : MonoBehaviour
{
    [SerializeField] private GameObject _redLight;
    private bool _isLightOn;

    void Start()
    {
        StartCoroutine(BlinkingLight());
    }

    // Update is called once per frame
    void Update()
    {
        if(_isLightOn)
        {
            _redLight.SetActive(true);
        }
        else
            _redLight.SetActive(false);
    }
    IEnumerator BlinkingLight()
    {
       _isLightOn= true;
        yield return new WaitForSeconds(.5f);

        _isLightOn = false;
        yield return new WaitForSeconds(.5f);
        StartCoroutine(BlinkingLight());


    }
}
