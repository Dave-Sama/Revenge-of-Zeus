using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{

    
    [SerializeField] private GameObject menuButtonSet;
    [SerializeField] private GameObject settingsWindow;
    [SerializeField] private GameObject soundSettingsWindow;
    [SerializeField] private GameObject controlSettingsWindow;


    // Go back to main menu
    public void CloseWindow()
    {
        menuButtonSet.SetActive(true);
        gameObject.SetActive(false);
    }
    // Go to Sound settings
    public void GoToSoundSettings()
    {

        settingsWindow.SetActive(false);
        soundSettingsWindow.SetActive(true);
    }

    public void GoToControlSettings()
    {

        settingsWindow.SetActive(false);
        controlSettingsWindow.SetActive(true);
    }
}
