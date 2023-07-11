using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game01_ItemScript : MonoBehaviour
{
    private Image _thisImage;
    [SerializeField] private NinjaItemManager _ninjaItemManager;


    void Start()
    {
        _ninjaItemManager = GameObject.Find("NinjaItemManager").GetComponent<NinjaItemManager>();
        _thisImage = GetComponent<Image>();
        SelectImage();
    }

    private void SelectImage()
    {
        if(_thisImage.transform.tag == "ninjaOutfit")
        {
            _thisImage.sprite = _ninjaItemManager.GetOutfit();
        }

        if(_thisImage.transform.tag == "ninjaTool")
        {
            _thisImage.sprite = _ninjaItemManager.GetTool();            
        }

        if(_thisImage.transform.tag == "ninjaWeapon")
        {
            _thisImage.sprite = _ninjaItemManager.GetWeapon();
        }
    }    
}
