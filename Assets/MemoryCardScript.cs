using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MemoryCardScript : MonoBehaviour
{
    [SerializeField] private NinjaMemoryBaseScript _baseScript03;
    private string thisCardsName;
    private Transform _thisCardsBack;
    private Image _thisCardsImage;
    private Sprite[] _ninjaItems;


    private void OnEnable()
    {
        _thisCardsBack = transform.Find("Image_Back");
        _thisCardsImage = GetComponent<Image>();
        SelectImage();
    }

    void Start()
    {
        if(_baseScript03 == null)
            _baseScript03 = GameObject.Find("03c_Panel_Game03_NinjaMemory").GetComponent<NinjaMemoryBaseScript>();

        thisCardsName = this.name;

        Debug.Log("Name " + thisCardsName);
    }

    public void SendCardName()
    {
        _thisCardsBack.gameObject.SetActive(false);
        _baseScript03.CardFlipped(thisCardsName);
    }

    private void SelectImage()
    {
        _thisCardsImage.sprite = _ninjaItems[Random.Range(0, _ninjaItems.Length)];


    }
}
