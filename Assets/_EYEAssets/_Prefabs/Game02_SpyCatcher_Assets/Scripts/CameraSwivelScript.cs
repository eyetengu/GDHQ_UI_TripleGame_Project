using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwivelScript : MonoBehaviour
{
    [SerializeField] private float _rotation;
    [SerializeField] private float _speed = .1f;
    private bool _rotateRight;
    private float _lagTime = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
        _rotation = _speed * Time.deltaTime;
        StartCoroutine(RotateRight());
    }

    // Update is called once per frame
    void Update()
    {
        if(_rotateRight == true)
            _rotation = 1 * _speed;
        if(_rotateRight == false)
            _rotation = -1 * _speed;
        
        RotateCamera();
    }

    private void RotateCamera()
    {
        transform.Rotate(0, _rotation, 0);
    }

    IEnumerator RotateRight()
    {
        yield return new WaitForSeconds(_lagTime);
        _rotateRight = !_rotateRight;
        StartCoroutine(RotateRight());
    }
}
