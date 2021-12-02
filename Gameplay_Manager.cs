using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gameplay_Manager : MonoBehaviour
{
    public static Gameplay_Manager instance;
    #region Variables
    
    public GameObject[] LevelM1;
    public GameObject[] LevelM2;
    public GameObject[] character;
    public GameObject LvLCompletePanel;
    public GameObject GameCompletePanel;
    private int currentLevel;
    public int pressCount;
    
    #endregion

    #region Awake/Start/Update

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Debug.Log("Index is ==  "+PlayerPrefs.GetInt("SelectedLevelM1"));
        pressCount = 0;
        ActivateModeAndLevel();
        activateSelectedCharacter();
        InitiationDebug();
        Debug.Log( PlayerPrefs.GetInt("M1UnlockableLevel"));
    }

    private void Update()
    {
        pressFunctionality();
        levelFunctionality();
    }
    
    #endregion

    #region Activate Selected Character
    public void activateSelectedCharacter()
    {
        character[PlayerPrefs.GetInt("selectedcharacter")].SetActive(true);
        //Will activate the selected character with the help of a character[] array where characters are stored.
        
    }
    #endregion

    #region Generic Levels Initialization
    public void ActivateModeAndLevel()
    {
        if (PlayerPrefs.GetString("Mode")=="Mode1"&&PlayerPrefs.GetInt("SelectedLevelM1")<=3)
        {
            LevelM1[PlayerPrefs.GetInt("SelectedLevelM1")].SetActive(true);
            currentLevel = PlayerPrefs.GetInt("SelectedLevelM1");
            UI_Manager.instance.M1pressLimitAssign(PlayerPrefs.GetInt("M1PressLimit"));
        }
        else if (PlayerPrefs.GetString("Mode")=="Mode1"&&PlayerPrefs.GetInt("SelectedLevelM1")==4)
        {
            LevelM1[PlayerPrefs.GetInt("SelectedLevelM1")].SetActive(true);
            currentLevel = PlayerPrefs.GetInt("SelectedLevelM1");
            UI_Manager.instance.M1pressLimitAssign(PlayerPrefs.GetInt("M1PressLimit"));
        }
         
        else if (PlayerPrefs.GetString("Mode")=="Mode2"&&PlayerPrefs.GetInt("SelectedLevelM2")<=3)
        {
            LevelM2[PlayerPrefs.GetInt("SelectedLevelM2")].SetActive(true);
            currentLevel = PlayerPrefs.GetInt("SelectedLevelM2");
            UI_Manager.instance.M2pressLimitAssign(PlayerPrefs.GetInt("M2PressLimit"));
        }

        else   if (PlayerPrefs.GetString("Mode")=="Mode2"&&PlayerPrefs.GetInt("SelectedLevelM2")==4)
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
    #endregion

    #region KeyPress and Presscount increment
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

    public void increment()
    {
        pressCount++;
    }
    //Give levels an actual functionality by increasing pressCount after every coin is collected in >>coinMove script
    

    #endregion

    #region Game/Level Completion
    public void levelFunctionality()
    {
        //If level completion requirement (Pressing the button corresponding to press count of the level) is fulfilled, level completion panel will
        // appear until level 4, after level 4, game completion panel will appear as level 5 is the last level.
      
        if (PlayerPrefs.GetString("Mode")=="Mode1"&&PlayerPrefs.GetInt("SelectedLevelM1")<=3&&pressCount==PlayerPrefs.GetInt("M1PressLimit"))
        {
            LvLCompletePanel.SetActive(true);
            
        }
        
        else if(PlayerPrefs.GetString("Mode")=="Mode1"&&PlayerPrefs.GetInt("SelectedLevelM1")==4&&pressCount==PlayerPrefs.GetInt("M1PressLimit"))
        {
            GameCompletePanel.SetActive(true);
           
        }
        if (PlayerPrefs.GetInt("M1UnlockableLevel")==PlayerPrefs.GetInt("SelectedLevelM1"))
        {
            PlayerPrefs.SetInt("M1UnlockableLevel",PlayerPrefs.GetInt("SelectedLevelM1")+1);
        }
        
        //If level completion requirement (Pressing the button corresponding to press count of the level) is fulfilled, level completion panel will
        // appear until level 4, after level 4, game completion panel will appear as level 5 is the last level. An unlockable level is also set using player prefs,
        //Once a level is completed, it will be unlocked/interactable in the main menu. 
        if (PlayerPrefs.GetString("Mode")=="Mode2"&&PlayerPrefs.GetInt("SelectedLevelM2")<=3&&pressCount==PlayerPrefs.GetInt("M2PressLimit"))
        {
            LvLCompletePanel.SetActive(true);
        }
        else if(PlayerPrefs.GetString("Mode")=="Mode2"&&PlayerPrefs.GetInt("SelectedLevelM2")==4&&pressCount==PlayerPrefs.GetInt("M2PressLimit"))
        {
            GameCompletePanel.SetActive(true);
        }
        if (PlayerPrefs.GetInt("M2UnlockableLevel")==PlayerPrefs.GetInt("SelectedLevelM2"))
        {
            PlayerPrefs.SetInt("M2UnlockableLevel",PlayerPrefs.GetInt("SelectedLevelM2")+1);
        }
        //Level Complete functionality. Level is completed based on user input, each spacebar press increments the presscount,
        //when presscount reaches presscount limit for that level, level is completed.
    }

    

    #endregion

    #region Game/Level Complete Panels Functionality

    public void lvLCompletePanelNextBTN()
    {
        if (PlayerPrefs.GetString("Mode")=="Mode1")
        {
            Debug.Log(" Click Functional For Mode 1");
            PlayerPrefs.SetInt("SelectedLevelM1",PlayerPrefs.GetInt("SelectedLevelM1")+1);
            SceneManager.LoadScene("Gameplay");
            PlayerPrefs.SetInt("M1PressLimit",PlayerPrefs.GetInt("M1PressLimit")+1);
        }
        else if (PlayerPrefs.GetString("Mode")=="Mode2")
        {
            Debug.Log(" Click Functional For Mode 2");
            PlayerPrefs.SetInt("SelectedLevelM2",PlayerPrefs.GetInt("SelectedLevelM2")+1);
            SceneManager.LoadScene("Gameplay");
            PlayerPrefs.SetInt("M2PressLimit",PlayerPrefs.GetInt("M2PressLimit")+1);
        }
        
        // After the press count limit for a level in any of the available modes is reached, the level complete panel will appear
        // with two options, nextlevel or home, if next level is clicked, next level of the respective mode will be loaded.
        // This functionality will also work when selecting a random level from the main menu as long as all levels are unlocked/interactable
    }
    public void HomeButtonClick()
    {
        SceneManager.LoadScene("Main Menu");
    }

    #endregion

    #region Debug.Log

    public void InitiationDebug()
    {
        Debug.Log(PlayerPrefs.GetString("SelectedCharacter"));
        Debug.Log("Selected Level Index== "+ currentLevel);
        Debug.Log("Press Count is " + pressCount);
        Debug.Log("Selected Mode is ==  " + PlayerPrefs.GetString("Mode"));
    }

    #endregion

}
