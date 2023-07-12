using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NinjaMemoryBaseScript : MonoBehaviour
{
    //Game Flow
    //player flips a card
    //player flips a second card
    //if card (names) match then score++
    //else score--
    //coroutine waits 2 secs. then cards are removed or they are flipped over
    //player tries again.
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private PlayerPrefsManager _playerPrefsManager;
    [SerializeField] private Transform _gridLayoutGroup;
    [SerializeField] private GameObject _cardPrefab;
    [SerializeField] private int _remainingCards = 18;
    [SerializeField] private GameObject[] _ninjaItems;
    private string cardName01, cardName02;
    private int cardsFlipped;
    private int _score;
    private bool _success, _hasAudioPlayed;


    private void OnEnable()
    {
        if(_audioManager == null)   
            _audioManager = FindObjectOfType<AudioManager>();
        if (_gridLayoutGroup == null) 
            _gridLayoutGroup = GameObject.Find("GLGNinjaMemory").GetComponent<Transform>();
    }

    void Start()
    {

        for(int i = 0; i< 18; i++)
        {
            GameObject ninjaItem = Instantiate(_ninjaItems[Random.Range(0, 3)], _gridLayoutGroup.transform.position, _gridLayoutGroup.transform.rotation);
            ninjaItem.transform.SetParent(_gridLayoutGroup.transform);
        }
    }

    public void CardFlipped(string cardName)
    {
        cardsFlipped++;

        if (cardsFlipped == 1)
        {
            cardName01 = cardName;
            Debug.Log("Card 1 flipped");
        }
        if (cardsFlipped == 2)
        {
            cardName02 = cardName;
            Debug.Log("Card 2 Flipped");
            CompareCards();
        }
    }

    public void CompareCards()
    {
        if (cardName01 == cardName02)
        {
            Debug.Log("Well Done");
            _score++;
            _remainingCards -= 2;
            _success = true;
        }
        else
        {
            Debug.Log("NIce Try");
            _score--;
            _success = false;
        }
        Debug.Log("Cards Compared");
        if (_remainingCards <= 0)
            Debug.Log("Out Of Cards");

        StartCoroutine(TakeAMomentAndBreathe());
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
        SaveScoreToPrefs();
    }





    IEnumerator TakeAMomentAndBreathe()
    {
        yield return new WaitForSeconds(2);

        if (_success == true)
        {
            Debug.Log("Waited on Success");

        }
        else
        {
            Debug.Log("What a load of hype");
        }



    }


}
