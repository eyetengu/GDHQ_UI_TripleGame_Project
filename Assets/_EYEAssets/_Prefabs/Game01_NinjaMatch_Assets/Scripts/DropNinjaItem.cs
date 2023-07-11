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
    private int _itemsRemaining = 15;
    private bool _hasAudioPlayed;


    void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
        _gameManager01= FindObjectOfType<Game01Setup>();
    }

    private void Update()
    {
        Debug.Log(_itemsRemaining);
        if (_itemsRemaining <= 10 && _hasAudioPlayed == false)
        {
            _hasAudioPlayed = true;
            _audioManager.PlayPlayerWinClip();
        }
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
                _itemsRemaining--;
            }
            else
            {
                //eventData.pointerDrag.GetComponent<DraggableNinjaItem>()._oldPosition = _thisImage.rectTransform.localPosition;
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
                _itemsRemaining--;

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
                _itemsRemaining--;
            }
            else
            {
                _audioManager.PlayScoreDownClip();
                _gameManager01.DecreaseScore();

            }
        }
    }

}
