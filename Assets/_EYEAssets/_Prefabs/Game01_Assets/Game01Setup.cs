using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game01Setup : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup _glg;
    [SerializeField] private GameObject[] _ninjaItems;

    void Start()
    {
        _glg = GameObject.Find("NinjaGridLayoutGroup").GetComponent<GridLayoutGroup>();

        for (int i = 0; i < 15; i++)
        {
            GameObject ninjaItem = Instantiate(_ninjaItems[Random.Range(0, 3)], _glg.transform.position, _glg.transform.rotation);
            ninjaItem.transform.SetParent(_glg.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
