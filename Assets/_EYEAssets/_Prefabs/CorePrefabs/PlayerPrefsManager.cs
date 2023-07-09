using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerPrefsManager : MonoBehaviour
{
    //The player prefs manager is responsible for taking in information regarding players name and score for each game.
    //When a player slot is chosen AND it is empty the player will be asked if they want to save their info there.
    //If YES then the player will enter their name which will be displayed in the text field of that slot and their name will be added to a player pref "NAME"
    //If the player slot is 'occupied' by a player name and it is clicked then that players' playerprefs will be loaded and the next screen will be loaded.

    //Variables
    //Players name
    //access to each slot
    [SerializeField] GameObject _createNewProfile;
    [SerializeField] GameObject _continueProfile;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Functions
    //when a slot is clicked then a welcome message appears, would you like to save/load (empty/occupied)

    public void CheckSlotStatus(TMP_Text slotName)
    {
        if (slotName != null)
        {
            if(slotName.text == "")
            {
                EmptySlot();
            }
            else
                OccupiedSlot();
        }
    }

    private void EmptySlot()
    {
        Debug.Log("EmptySlot. Would You Like to save your progress here?");
        _createNewProfile.SetActive(true);
    }

    private void OccupiedSlot()
    {
        Debug.Log("OccupiedSlot. Would you like to continue from where you left off?");
        _continueProfile.SetActive(true);
    }

    public void UpdatePlayerData()
    {
        Debug.Log("Update Info");
    }



}
