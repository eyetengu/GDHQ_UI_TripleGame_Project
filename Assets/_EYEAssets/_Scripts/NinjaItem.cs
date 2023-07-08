using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NinjaItem : MonoBehaviour
{
    [SerializeField] private Sprite[] _images;
    private Image _thisImage;

    void Start()
    {
        _thisImage = GetComponent<Image>();
        _thisImage.sprite = _images[Random.Range(0, _images.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
