using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameplay_Manager : MonoBehaviour
{
    public GameObject[] LevelM1;
    public GameObject[] LevelM2;
    public GameObject[] character;
    private int currentLevel;
    private int pressCount;
    
    
    void Start()
    {
        pressCount = 0;
        ActivateModeAndLevel();
        activateSelectedCharacter();
        InitiationDebug();
        
    }

    private void Update()
    {
        pressFunctionality();
        levelFunctionality();
    }

    public void activateSelectedCharacter()
    {
        character[PlayerPrefs.GetInt("selectedcharacter")].SetActive(true);
        //Will activate the selected character with the help of a character[] array where characters are stored.
        
    }
    public void ActivateModeAndLevel()
    {
        if (PlayerPrefs.GetString("Mode")=="Mode1")
        {
            LevelM1[PlayerPrefs.GetInt("SelectedLevelM1")].SetActive(true);
            //PlayerPrefs.GetInt("M1PressLimit");
            currentLevel = PlayerPrefs.GetInt("SelectedLevelM1");
            UI_Manager.instance.M1pressLimitAssign(PlayerPrefs.GetInt("M1PressLimit"));

        }
        else if (PlayerPrefs.GetString("Mode")=="Mode2")
        {
            LevelM2[PlayerPrefs.GetInt("SelectedLevelM2")].SetActive(true);
            currentLevel = PlayerPrefs.GetInt("SelectedLevelM2");
            UI_Manager.instance.M2pressLimitAssign(PlayerPrefs.GetInt("M2PressLimit"));
        }
        //This function will simply check for the saved "Mode". Whether the player clicked on "Mode1" or "Mode2". 
        // The level[] will then be activated using the playerprefs that saved the level data, which level was clicked 
        // and the clicked level will be activated. "currentLevel" is set to be same as the value of selected level, it can
        // be later used for other purposes such as level lock and unlock system, level objectives assignment etc.
    }

    public void InitiationDebug()
    {
        Debug.Log(PlayerPrefs.GetString("SelectedCharacter"));
        Debug.Log("Index for selected character is "+ PlayerPrefs.GetInt("selectedcharacter"));
        Debug.Log("Selected Mode is  "+ PlayerPrefs.GetString("Mode"));
        Debug.Log("Selected Level Index== "+ currentLevel);
        Debug.Log("Press Count is " + pressCount);
    }

    public void pressFunctionality()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space Pressed");
            pressCount++;
            Debug.Log(pressCount);
            if (PlayerPrefs.GetString("Mode")=="Mode1")
            {
                Debug.Log(PlayerPrefs.GetInt("M1PressLimit"));
            }
            else if(PlayerPrefs.GetString("Mode")=="Mode2")
            {
                Debug.Log(PlayerPrefs.GetInt("M2PressLimit"));
            }
            //This is a basic level functionality. Press xyz key to increment the presscount, which will be used to check if
            //it has reached the press count limit.
        }
    }

    public void levelFunctionality()
    {
        if (PlayerPrefs.GetString("Mode")=="Mode1")
        {
            if (pressCount==PlayerPrefs.GetInt("M1PressLimit"))
            {
                Debug.Log("M1 Level Complete");
            }
        }
        else if (PlayerPrefs.GetString("Mode")=="Mode2")
        {
            if (pressCount==PlayerPrefs.GetInt("M2PressLimit"))
            {
                Debug.Log("M2 Level Complete");
            }
        }
        //Level Complete functionality. Level is completed based on user input, each spacebar press increments the presscount,
        //when presscount reaches presscount limit for that level, level is completed.
        
    }

    public void lvLCompletePanelNextBTN()
    {
        if (PlayerPrefs.GetString("Mode")=="Mode1")
        {
            Debug.Log(" Click Functional For Mode 1");
            //PlayerPrefs.SetInt("SelectedLevelM1",PlayerPrefs.GetInt("SelectedLevelM1"+1));
            LevelM1[PlayerPrefs.GetInt("SelectedLevelM1")].SetActive(false);
            PlayerPrefs.SetInt("SelectedLevelM1",PlayerPrefs.GetInt("SelectedLevelM1")+1);
            SceneManager.LoadScene("Gameplay");
            //PlayerPrefs.GetInt("M1PressLimit");
            LevelM1[PlayerPrefs.GetInt("SelectedLevelM1")+1].SetActive(true);
            PlayerPrefs.SetInt("M1PressLimit",PlayerPrefs.GetInt("M1PressLimit")+1);
            //UI_Manager.instance.M1pressLimitAssign(PlayerPrefs.GetInt("M1PressLimit"));
        }
        else if (PlayerPrefs.GetString("Mode")=="Mode2")
        {
            Debug.Log(" Click Functional For Mode 2");
            //PlayerPrefs.SetInt("SelectedLevelM1",PlayerPrefs.GetInt("SelectedLevelM1"+1));
            LevelM2[PlayerPrefs.GetInt("SelectedLevelM2")].SetActive(false);
            PlayerPrefs.SetInt("SelectedLevelM2",PlayerPrefs.GetInt("SelectedLevelM2")+1);
            SceneManager.LoadScene("Gameplay");
            //PlayerPrefs.GetInt("M1PressLimit");
            LevelM1[PlayerPrefs.GetInt("SelectedLevelM2")+1].SetActive(true);
            PlayerPrefs.SetInt("M2PressLimit",PlayerPrefs.GetInt("M2PressLimit")+1);
            //UI_Manager.instance.M1pressLimitAssign(PlayerPrefs.GetInt("M1PressLimit"));
        }
    }

    public void HomeButtonClick()
    {
        SceneManager.LoadScene("Main Menu");
    }

   
    
    
}
