using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{

    
    [SerializeField] private GameObject menuButtonSet;
    [SerializeField] private GameObject settingsWindow;
    [SerializeField] private GameObject soundSettingsWindow;
    [SerializeField] private GameObject controlSettingsWindow;

    // player 1
    string punch1;
    string kick1;
    string jump1;
    string bend1;
    
    // player 2
    string punch2;
    string kick2;
    string jump2;
    string bend2;

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

    // limit player 1 punch text input
    public void OnPlayer1PunchInputChange()
    {
        if (punch1.Length > 1)
        {
            punch1 = punch1.Substring(0,1);
        }
    }

    // limit player 1 kick text input
    public void OnPlayer1KickInputChange()
    {
        if (kick1.Length > 1)
        {
            kick1 = kick1.Substring(0, 1);
        }
    }

    // limit player 1 jump text input
    public void OnPlayer1JumpInputChange()
    {
        if (jump1.Length > 1)
        {
            jump1 = jump1.Substring(0, 1);
        }
    }

    // limit player 1 bend text input
    public void OnPlayer1BendInputChange()
    {
        if (bend1.Length > 1)
        {
            bend1 = bend1.Substring(0, 1);
        }
    }

    // player 1 punch text input
    public void ReadPlayer1PunchInput(string s)
    {
        punch1 = s.ToUpper();
    }

    // player 1 kick text input
    public void ReadPlayer1KickInput(string s)
    {
        kick1 = s.ToUpper();
    }

    // player 1 jump text input
    public void ReadPlayer1JumpInput(string s)
    {
        jump1 = s.ToUpper();
    }

    // player 1 bend text input
    public void ReadPlayer1BendInput(string s)
    {
        bend1 = s.ToUpper();
    }

    // limit player 2 punch text input
    public void OnPlayer2PunchInputChange()
    {
        if (punch2.Length > 1)
        {
            punch2 = punch2.Substring(0, 1);
        }
    }

    // limit player 2 kick text input
    public void OnPlayer2KickInputChange()
    {
        if (kick2.Length > 1)
        {
            kick2 = kick2.Substring(0, 1);
        }
    }

    // limit player 2 jump text input
    public void OnPlayer2JumpInputChange()
    {
        if (jump2.Length > 1)
        {
            jump2 = jump2.Substring(0, 1);
        }
    }

    // limit player 2 bend text input
    public void OnPlayer2BendInputChange()
    {
        if (bend2.Length > 1)
        {
            bend2 = bend2.Substring(0, 1);
        }
    }

    // player 2 punch text input
    public void ReadPlayer2PunchInput(string s)
    {
        punch2 = s.ToUpper();
    }

    // player 2 kick text input
    public void ReadPlayer2KickInput(string s)
    {
        kick2 = s.ToUpper();
    }

    // player 2 jump text input
    public void ReadPlayer2JumpInput(string s)
    {
        jump2 = s.ToUpper();
    }

    // player 2 bend text input
    public void ReadPlayer2BendInput(string s)
    {
        bend2 = s.ToUpper();
    }
}


