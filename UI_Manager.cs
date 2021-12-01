using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager instance;
    public GameObject mainMenu;
    public GameObject p_modeSelection;
    public GameObject pm1_LevelSelection;
    public GameObject pm2_LevelSelection;
    public GameObject p_CharacterSelection;
    public GameObject p_m1Lvls;
    public GameObject p_m2Lvls;
    public Button[] Mode1LvLs;
    public Button[] Mode2Lvls;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void CharacterSelection()
    {
        p_CharacterSelection.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void selectedCharacterRed()
    {
        PlayerPrefs.SetString("SelectedCharacter", "Red"); 
        PlayerPrefs.SetInt("selectedcharacter",0); //Saving player data with playerprefs which is later retrieved in  
        Debug.Log("Pressed Red");           //Gameplay_Manager to get the selected character which is red with index 0.
        p_modeSelection.SetActive(true);
        p_CharacterSelection.SetActive(false);
        
        
       
    }
    public void selectedCharacterGreen()
    {
        PlayerPrefs.SetString("SelectedCharacter", "Green");
        PlayerPrefs.SetInt("selectedcharacter",1);  //Saving player data with playerprefs which is later retrieved in
        Debug.Log("Pressed Green");          //Gameplay_Manager to get the selected character which is green with index 1.
        p_modeSelection.SetActive(true);
        p_CharacterSelection.SetActive(false);
    }
    public void selectedCharacterBlue()
    {
        PlayerPrefs.SetString("SelectedCharacter", "Blue");
        PlayerPrefs.SetInt("selectedcharacter",2); //Saving player data with playerprefs which is later retrieved in
        Debug.Log("Pressed Blue");          //Gameplay_Manager to get the selected character which is blue with index 2.
        p_modeSelection.SetActive(true);
        p_CharacterSelection.SetActive(false);
    }

    public void mode1Selection()
    {
        PlayerPrefs.SetString("Mode","Mode1");   // Saving Mode which is Mode1 if clicked on this button, it is later retrieved to activate mode 1 levels.
        p_m1Lvls.SetActive(true);
    }
    
    public void mode2Selection()
    {
        PlayerPrefs.SetString("Mode", "Mode2"); // Saving Mode which is Mode2 if clicked on this button, it is later retrieved to activate mode 2 levels.
        p_m2Lvls.SetActive(true);
    }

    public void m1LevelSelection(int a)
    {
        PlayerPrefs.GetString("Mode");
        PlayerPrefs.SetInt("SelectedLevelM1",a);  //Stored "Mode" playerprefs is retrieved, level index data is saved using playerprefs
        SceneManager.LoadScene("Gameplay"); //A parameter is passed to this function, when level buttons are linked with it, they will require an int index. 
    }
    
    public void m2LevelSelection(int b)
    {
        PlayerPrefs.GetString("Mode");
        PlayerPrefs.SetInt("SelectedLevelM2",b); //Stored "Mode" playerprefs is retrieved, level index data is saved using playerprefs
        SceneManager.LoadScene("Gameplay"); //A parameter is passed to this function, when level buttons are linked with it, they will require an int index. 
    }

    public void characterSelectionBack()
    {
        p_CharacterSelection.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void modeSelectionBack()
    {
        p_modeSelection.SetActive(false);
        p_CharacterSelection.SetActive(true);                    // Activating and deactivating panels based on back button click.
    }                                                             // Activating and deactivating panels based on back button click.

    public void M1levelSelectionBack()
    {
        p_m1Lvls.SetActive(false);
        p_modeSelection.SetActive(true);
    }
    public void M2levelSelectionBack()
    {
        p_m2Lvls.SetActive(false);
        p_modeSelection.SetActive(true);
    }
    
    public void M1pressLimitAssign(int M1pressLimit)
    {
        PlayerPrefs.GetString("Mode");
        PlayerPrefs.SetInt("M1PressLimit",M1pressLimit);
        //A presscount limit for each level is defined for mode 1 using an int parameter. The data is then saved using playerprefs.
        // press limit count is same as defined by the user in the inspector using the parameter/button link.
        //It is retrieved in gameplay manager to implement level/gameplay functionality.
    }

    public void M2pressLimitAssign(int M2pressLimit)
    {
        PlayerPrefs.GetString("Mode");
        PlayerPrefs.SetInt("M2PressLimit",M2pressLimit);
        //A presscount limit for each level is defined for mode 2 using an int parameter. The data is then saved using playerprefs.
        // press limit count is same as defined by the user in the inspector using the parameter/button link.
        //It is retrieved in gameplay manager to implement level/gameplay functionality.
    }
    
    
}
