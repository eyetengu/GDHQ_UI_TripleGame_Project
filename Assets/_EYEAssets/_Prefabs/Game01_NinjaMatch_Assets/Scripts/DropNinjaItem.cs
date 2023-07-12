using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class DropNinjaItem : MonoBehaviour, IDropHandler
{
    private Image _thisImage;
    [SerializeField] private bool _isOutfit, _isTool, _isWeapon;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private Game01Setup _gameManager01;


    void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        _gameManager01= FindObjectOfType<Game01Setup>();
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        if (_isOutfit)
        {           
            if (eventData.pointerDrag.tag == "ninjaOutfit")
            {
                eventData.pointerDrag.transform.SetParent(this.transform, true);
                _audioManager.PlayScoreUpClip();
                _gameManager01.IncreaseScore();
            }
            else
            {
                _audioManager.PlayScoreDownClip();
                _gameManager01.DecreaseScore();
            }
        }

        if (_isTool)
        {
            if (eventData.pointerDrag.tag == "ninjaTool")
            {
                eventData.pointerDrag.transform.SetParent(this.transform, true);
                _audioManager.PlayScoreUpClip();
                _gameManager01.IncreaseScore();

            }
            else
            {
                _audioManager.PlayScoreDownClip();
                _gameManager01.DecreaseScore();

            }
        }

        if (_isWeapon)
        {
            if (eventData.pointerDrag.tag == "ninjaWeapon")
            {
                eventData.pointerDrag.transform.SetParent(this.transform, true);
                _audioManager.PlayScoreUpClip();
                _gameManager01.IncreaseScore();
            }
            else
            {
                _audioManager.PlayScoreDownClip();
                _gameManager01.DecreaseScore();

            }
        }
    }

}
