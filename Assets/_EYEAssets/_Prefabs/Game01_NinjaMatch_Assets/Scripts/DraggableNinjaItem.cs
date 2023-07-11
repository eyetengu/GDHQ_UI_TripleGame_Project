using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DraggableNinjaItem : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    private Image _image;
    public Vector3 _oldPosition;


    void Start()
    {
        _image = GetComponent<Image>();        
        _oldPosition = _image.rectTransform.localPosition;
    }

    public void ReturnToSender()
    {
        _image.rectTransform.localPosition = _oldPosition;
    }
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        _image.raycastTarget = false;
    }
    
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        _image.raycastTarget = false;

        var transparency = _image.color;
        transparency.a = 0.5f;
        _image.color = transparency;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ReturnToSender();
        _image.raycastTarget = true;
    }

}
