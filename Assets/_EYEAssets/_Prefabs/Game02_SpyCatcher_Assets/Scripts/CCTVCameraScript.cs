using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CCTVCameraScript : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private GameObject _gameScene;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private MeshRenderer _spyRenderer;
    [SerializeField] private Button _catchSpyButton;


    private void OnEnable()
    {
        _mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        if (_mainCamera == null)
            Debug.Log("MainCamera is NULL");
        
        if (_gameScene == null)
            _gameScene = GameObject.Find("GameScene_SpyView");            
        
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        if (_audioManager == null)
            Debug.Log("Audio Manager is NULL");

        _gameScene.SetActive(true);
    }

    void Start()
    {
    
    }

    void Update()
    {
        
    }
    
    private void OnDisable()
    {
        _gameScene.SetActive(false);
    }



    //wrong scripts to be applied here. place on character instead
    public void OnBecameVisible()
    {
        _audioManager.PlayScoreUpClip();
    }

    public void OnBecameInvisible()
    {
        _audioManager.PlayScoreDownClip();
    }

}
