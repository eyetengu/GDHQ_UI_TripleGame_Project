using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private bool _gameIsPaused;
    [SerializeField] private GameObject[] _panels;
    [SerializeField] private GameObject _gameScene;
    [SerializeField] private int _score;


    private void OnEnable()
    {
        //GameScene
        if(_gameScene == null)
            _gameScene = GameObject.Find("GameScene_SpyView");

        //Audio
        if(_audioManager == null)
        {
            _audioManager = FindObjectOfType<AudioManager>();
            _audioManager.PlayBackgroundMusic();
        }        
    }

    void Start()
    {
        //Panels Initialize
        foreach (GameObject panel in _panels)
        {
            panel.SetActive(false);
        }
        _panels[0].SetActive(true);

    }

    public void Update()
    {
        GamePause();
        
    }


    public void TurnOnPanel(int panelNumber)
    {
        _panels[panelNumber].SetActive(true);

        if(panelNumber == 7)
            _gameScene.SetActive(true);        
        else
        {
            if(_gameScene != null) 
                _gameScene.SetActive(false);
        }
    }

    public void CreateASaveProfile()
    {
        Debug.Log("What to activate?");
        _panels[2].SetActive(true);
        //_panels[4].SetActive(true);
    }

    private void GamePause()
    {
        if (_gameIsPaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;        
    }

    public void ContinueJourney()
    {
        foreach(GameObject panel in _panels)
        { 
            panel.SetActive(false); 
        }
        _panels[4].SetActive(true);
    }

}
