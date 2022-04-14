using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{

    [SerializeField] private GameObject menuButtonSet;
    [SerializeField] private GameObject settingsWindow;
    [SerializeField] private GameObject soundSettingsWindow;
    [SerializeField] private GameObject controlSettingsWindow;
    [SerializeField] private GameObject videoSettingsWindow;


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

    // Go to Control settings
    public void GoToControlSettings()
    {

        settingsWindow.SetActive(false);
        controlSettingsWindow.SetActive(true);
    }

    public void toControlFromSound()
    {
        soundSettingsWindow.SetActive(false);
        controlSettingsWindow.SetActive(true);
    }


    // Go to Video settings
    public void GoToVideoSettings()
    {

        settingsWindow.SetActive(false);
        videoSettingsWindow.SetActive(true);
    }

    public void CloseSoundWindow()
    {
        soundSettingsWindow.SetActive(false);
        settingsWindow.SetActive(true);
    }




}


