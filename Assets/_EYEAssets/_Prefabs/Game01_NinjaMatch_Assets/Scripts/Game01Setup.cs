using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Game01Setup : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup _glg;
    [SerializeField] private GameObject[] _ninjaItems;
    [SerializeField] private int _score;
    [SerializeField] private TMP_Text _scoreText;

    void Start()
    {
        if(_scoreText == null)
            _scoreText = GameObject.Find("Text_ScoreValue").GetComponent<TMP_Text>();
        
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

    public void IncreaseScore()
    {
        _score++;
        UpdatePlayerScore();
    }

    public void DecreaseScore()
    {
        _score--;
        UpdatePlayerScore();
    }

    public void UpdatePlayerScore()
    {
        _scoreText.text = _score.ToString();
    }
}
