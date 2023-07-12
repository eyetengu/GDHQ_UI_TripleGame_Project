using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchTheSpy_BaseScript : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private PlayerPrefsManager _playerPrefsManager;
    [SerializeField] private GameObject _gameScene;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private GameObject[] _securityCameras;
    [SerializeField] private MeshRenderer _spyRenderer;
    [SerializeField] private Button[] _monitorScreen;
    private bool _hasAudioPlayed;
    private int _score;
    private bool _isArray01Switched, _isArray02Switched, _isArray03Switched;



    private void OnEnable()
    {
        if(_gameManager == null)
            _gameManager = FindObjectOfType<GameManager>();

        if (_mainCamera == null)
            _mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

        if (_audioManager == null)
            _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        
        if(_playerPrefsManager == null)
            _playerPrefsManager = FindObjectOfType<PlayerPrefsManager>();
            

        if (_gameScene == null)
            _gameScene = GameObject.Find("GameScene_SpyView");            
        
        _gameScene.SetActive(true);
    }    
    
    public void OnBecameVisible()
    {
        _audioManager.PlayScoreUpClip();
    }

    public void OnBecameInvisible()
    {
        _audioManager.PlayScoreDownClip();
    }

    public void SwitchCameraArray(int cameraArrayID)
    {
        switch(cameraArrayID)
        {
            case 1:
                _isArray01Switched = !_isArray01Switched;
                if (_isArray01Switched)
                {
                    _securityCameras[0].gameObject.SetActive(true);
                    _securityCameras[1].gameObject.SetActive(false);

                }
                else
                {
                    _securityCameras[0].gameObject.SetActive(false);
                    _securityCameras[1].gameObject.SetActive(true);
                }
                break;

            case 2:
                _isArray02Switched = !_isArray02Switched;
                if (_isArray02Switched)
                {
                    _securityCameras[2].gameObject.SetActive(true);
                    _securityCameras[3].gameObject.SetActive(false);
                }

                else
                {
                    _securityCameras[2].gameObject.SetActive(false);
                    _securityCameras[3].gameObject.SetActive(true);
                }
                break;

            case 3:
                _isArray03Switched= !_isArray03Switched;
                if(_isArray03Switched)
                {
                    _securityCameras[4].gameObject.SetActive(true);
                    _securityCameras[5].gameObject.SetActive(false);
                }
                else
                {
                    _securityCameras[4].gameObject.SetActive(false);
                    _securityCameras[5].gameObject.SetActive(true);
                }
                break;  
            default:
                break;
        }
    }

    private void PlayerWins()
    {
        _hasAudioPlayed = true;
        _audioManager.PlayPlayerWinClip();

        StartCoroutine(LetsPlayAGame());
    }

    private void SaveScoreToPrefs()
    {
        _playerPrefsManager.UpdatePlayerScore(_score);
    }    

    IEnumerator LetsPlayAGame()
    {
        yield return new WaitForSeconds(2);
        _gameManager.SelectGame();
    }

    private void OnDisable()
    {
        //_gameScene.SetActive(false);
        //SaveScoreToPrefs();
    }

}
