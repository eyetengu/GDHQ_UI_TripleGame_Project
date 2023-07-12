using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PanelStatsScript : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _playerName;    //text area for name
    [SerializeField] private TMP_Text[] _playerScore;   //text area for score
    [SerializeField] private int[] _playerScoreInt;     

    private void OnEnable()
    {
        ShowPlayerStats();        
    }

    public void ShowPlayerStats()
    {

        //player one stats
        _playerName[0].text = PlayerPrefs.GetString("Player01Name");

        int playerScore = PlayerPrefs.GetInt("Player01Score");
        _playerScore[0].text = "SCORE: " + playerScore. ToString();
        Debug.Log("At Score");
        Debug.Log(_playerScore[0].text);


        //player two stats
        //_playerName[1].text = PlayerPrefs.GetString("Player02Name");
       // _playerScoreInt[1] = PlayerPrefs.GetInt("Player02Score";
        //_playerScore[1].text = _playerScoreInt[1].ToString();


        //player three stats
       // _playerName[2].text = PlayerPrefs.GetString("Player03Name");
       // _playerScoreInt[2] = PlayerPrefs.GetInt("Player03Score");
       // _playerScore[2].text = _playerScoreInt[2].ToString();
    }
}
