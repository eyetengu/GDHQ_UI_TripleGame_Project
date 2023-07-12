using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Game01Setup : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private PlayerPrefsManager _playerPrefsManager;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private GridLayoutGroup _gridLayoutGroup;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private GameObject[] _ninjaItems;
    [SerializeField] private int _score;
    private int _itemsRemaining = 15;
    private bool _hasAudioPlayed;


    void OnEnable()
    {
        if(_gameManager == null)
            _gameManager = FindObjectOfType<GameManager>();

        if (_playerPrefsManager == null)
            _playerPrefsManager = FindObjectOfType<PlayerPrefsManager>();

        if (_audioManager == null)
            _audioManager = FindObjectOfType<AudioManager>();

        if (_gridLayoutGroup == null)
            _gridLayoutGroup = GameObject.Find("NinjaGridLayoutGroup").GetComponent<GridLayoutGroup>();

        if (_scoreText == null)
            _scoreText = GameObject.Find("Text_ScoreValue").GetComponent<TMP_Text>();
    }

    private void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            GameObject ninjaItem = Instantiate(_ninjaItems[Random.Range(0, 3)], _gridLayoutGroup.transform.position, _gridLayoutGroup.transform.rotation);
            ninjaItem.transform.SetParent(_gridLayoutGroup.transform);
        }
    }
        
    private void Update()
    {
        Debug.Log(_itemsRemaining);

        if (_itemsRemaining <= 0 && _hasAudioPlayed == false)
        {
            PlayerWins();
        }
    }

    public void IncreaseScore()
    {
        _score++;
        _itemsRemaining--;
        UpdatePlayerScore();
        SaveScoreToPrefs();
    }

    public void DecreaseScore()
    {
        _score--;
        UpdatePlayerScore();
    }

    public void UpdatePlayerScore()
    {
        _scoreText.text = _score.ToString();
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

    private void OnDisable()
    {
        SaveScoreToPrefs();
    }

    IEnumerator LetsPlayAGame()
    {
        yield return new WaitForSeconds(2);
        _gameManager.SelectGame();
    }
}
