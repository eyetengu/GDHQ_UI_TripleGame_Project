using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _panels;


    void Start()
    {
        foreach(GameObject panel in _panels)
        {
            panel.SetActive(false);
        }
        _panels[6].SetActive(true);
    }
}
