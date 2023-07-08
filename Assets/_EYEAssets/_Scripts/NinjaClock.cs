using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NinjaClock : MonoBehaviour
{
    [SerializeField] private VerticalLayoutGroup _vertLayout;
    [SerializeField] private GameObject _clockImage;
    [SerializeField] private float _maxHeight = 1845.0f;
    private Vector3 startPos;
    private bool _growingDarkness;

    [SerializeField] private float _moveSpeed = 1f;
    //[SerializeField] private float _xPosition = 0.05000305f;
    private float _sunRotation = 24.0f;
    private float _moonRotation = 23.25f;

    //[SerializeField] private Image _overlay;

    // Start is called before the first frame update
    void Start()
    {
        startPos = _clockImage.transform.position;
        Debug.Log(startPos);
        _growingDarkness= false;
    }

    // Update is called once per frame
    void Update()
    {
        _clockImage.transform.Translate(new Vector2(0, _moveSpeed));
        if(_clockImage.transform.position.y >= _maxHeight)
        { 
            _clockImage.transform.position = startPos; 
        }

        if(_clockImage.transform.position.y == 40.0f)
        {
            _growingDarkness= true;
        }

        if(_growingDarkness)
        {
            //var darkness = _overlay.color;
            //darkness.a = 1f;
        }
        Debug.Log(_clockImage.transform.position.y);
    }
}
