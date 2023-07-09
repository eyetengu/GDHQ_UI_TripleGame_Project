using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class DropNinjaItem : MonoBehaviour, IDropHandler
{
    private Image _thisImage;
    [SerializeField] private bool _isOutfit, _isTool, _isWeapon;

    public void OnDrop(PointerEventData eventData) 
    {
        Debug.Log("EventData " + eventData);

        if(_isOutfit)
        {
            if (eventData.pointerDrag.tag == "NinjaOutfit")
            {
                eventData.pointerDrag.GetComponent<DraggableNinjaItem>()._oldPosition = _thisImage.rectTransform.localPosition;
            }
        }
        if(_isTool)
        {
            if (eventData.pointerDrag.tag == "NinjaTool")
            {
                eventData.pointerDrag.GetComponent<DraggableNinjaItem>()._oldPosition = _thisImage.rectTransform.localPosition;
            }
        }
        if (_isWeapon)
        {
            if (eventData.pointerDrag.tag == "NinjaWeapon")
            {
                eventData.pointerDrag.GetComponent<DraggableNinjaItem>()._oldPosition = _thisImage.rectTransform.localPosition;
            }
        }
    }

    void Start()
    {
        _thisImage= GetComponent<Image>();  
    }
}
