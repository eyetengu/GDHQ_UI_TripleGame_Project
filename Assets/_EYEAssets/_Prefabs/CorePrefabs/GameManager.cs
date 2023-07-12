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
            _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
            _audioManager.PlayBackgroundMusic();
        }        
    }

    void Start()
    {
        TurnOnPanel(0);
    }

    public void Update()
    {
        GamePause();        
    }
    
    private void GamePause()
    {
        if (_gameIsPaused)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;        
    }

    public void TurnOnPanel(int panelNumber)
    {
        foreach (GameObject panel in _panels)
        {
            panel.SetActive(false);
        }
        _panels[panelNumber].SetActive(true);

        //enable persistent menu
        if (panelNumber >= 5)
            _panels[10].SetActive(true);
        else
            _panels[10].SetActive(false);

        //optional 3D game scene
        if(panelNumber == 7)
            _gameScene.SetActive(true);        
        else
        {
            if(_gameScene != null) 
                _gameScene.SetActive(false);
        }
    }

    public void CreateASaveProfile()    //turns on the overlay menu for saving a profile
    {
        Debug.Log("What to activate?");
        _panels[2].SetActive(true);
        //_panels[4].SetActive(true);
    }

    public void ContinueJourney()
    {
        foreach(GameObject panel in _panels)
        { 
            panel.SetActive(false); 
        }
        _panels[4].SetActive(true);
    }

    public void SelectGame()
    {
        TurnOnPanel(5);
    }
}
