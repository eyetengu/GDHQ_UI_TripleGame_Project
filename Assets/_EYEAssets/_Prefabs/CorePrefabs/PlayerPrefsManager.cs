using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefsManager : MonoBehaviour
{
    //The Game Manager
    [SerializeField] private GameManager _gameManager;

    //UI Screens
    [SerializeField] private GameObject _createNewProfile;
    [SerializeField] private GameObject _continueProfile;

    //Player Prefs
    [SerializeField] private PlayerPrefs _player01;

    //UI Elements
    [SerializeField] private TMP_Text _saveSlot01_Name;
    [SerializeField] private TMP_InputField _newPlayerNameInput;


    void OnEnable()
    {
        if (_gameManager == null)
            _gameManager = FindObjectOfType<GameManager>();

        if (_saveSlot01_Name == null)
            _saveSlot01_Name = GameObject.Find("Text_SaveSlot_p01_Name").GetComponent<TMP_Text>();
    }

    //Player Prefs Functions
    public void CheckToSeeIfSlotIsAvailable()
    {
        string name = PlayerPrefs.GetString("Player01Name");

        if (name == "" || name == " " || name == "Empty Slot")
        {
            CreatePlayerSave();
        }
        else
        {
            Debug.Log("Player01Name has a value of" + name + ".");
            ContinueFromSave();
        }
    }

    public void CreatePlayerSave()
    {
        _gameManager.TurnOnPanel(2);
    }

    public void UpdatePlayerName()
    {
        Debug.Log("Updating Player name");
        _saveSlot01_Name.text = _newPlayerNameInput.text;

        var inputText = _saveSlot01_Name.text;

        PlayerPrefs.SetString("Player01Name", inputText);
        PlayerPrefs.Save();

        Debug.Log(inputText);           
    }

    public void ContinueFromSave()
    {
        Debug.Log("Continuing From Save");
        _gameManager.ContinueJourney();
    }

    //The player prefs manager is responsible for taking in information regarding players name and score for each game.
    //When a player slot is chosen AND it is empty the player will be asked if they want to save their info there.
    //If YES then the player will enter their name which will be displayed in the text field of that slot and their name will be added to a player pref "NAME"
    //If the player slot is 'occupied' by a player name and it is clicked then that players' playerprefs will be loaded and the next screen will be loaded.

    //PlayerPrefs is primarily intended to be used for Player Preferences. It will also work for minor game stats at this stage of your learning. I would not constantly access them. I would set up values in the GameManager (or the main script for your app) to hold the information and update from there. Only access the PlayerPerfs when you intend to Save or Load. -Thomas Kesler 7/8/23

}
