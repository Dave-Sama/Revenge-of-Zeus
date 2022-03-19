using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllSettings : MonoBehaviour
{
    // player 1
    private string punch1 = "Q";
    private string kick1 = "W";
    private string jump1 = "E";
    private string bend1 = "R";
    public InputField punch1InputField;
    public InputField kick1InputField;
    public InputField jump1InputField;
    public InputField bend1InputField;

    // player 2
    private string punch2 = "O";
    private string kick2 = "P";
    private string jump2 = "{";
    private string bend2 = "}";
    public InputField punch2InputField;
    public InputField kick2InputField;
    public InputField jump2InputField;
    public InputField bend2InputField;

    // game objects

    [SerializeField] private GameObject mainSettings;
    [SerializeField] private GameObject controlSettings;
    [SerializeField] private GameObject soundSettingsWindow;
    [SerializeField] private GameObject videoSettingsWindow;

    // Start is called before the first frame update
    void Start()
    {
        //Changes the character limit in the main input field.
        punch1InputField.characterLimit = 1;
        kick1InputField.characterLimit = 1;
        jump1InputField.characterLimit = 1;
        bend1InputField.characterLimit = 1;
        punch2InputField.characterLimit = 1;
        kick2InputField.characterLimit = 1;
        jump2InputField.characterLimit = 1;
        bend2InputField.characterLimit = 1;

        // init player 1 inputs
        punch1InputField.text = "Q";
        kick1InputField.text = "W";
        jump1InputField.text = "E";
        bend1InputField.text = "R";

        // init player 2 inputs
        punch2InputField.text = "O";
        kick2InputField.text = "P";
        jump2InputField.text = "{";
        bend2InputField.text = "}";
    }

    // Go back to main menu
    public void CloseWindow()
    {
        mainSettings.SetActive(true);
        controlSettings.SetActive(false);
    }

    // Go to Sound settings
    public void GoToSoundSettings()
    {

        controlSettings.SetActive(false);
        soundSettingsWindow.SetActive(true);
    }


    // Go to Video settings
    public void GoToVideoSettings()
    {

        controlSettings.SetActive(false);
        videoSettingsWindow.SetActive(true);
    }

    // Restore all Controllers to default state.
    public void RestoreControllers()
    {
        ReadPlayer1PunchInput("Q");
        ReadPlayer1KickInput("W");
        ReadPlayer1JumpInput("E");
        ReadPlayer1BendInput("R");
        ReadPlayer2PunchInput("O");
        ReadPlayer2KickInput("P");
        ReadPlayer2JumpInput("{");
        ReadPlayer2BendInput("}");
    }

    // player 1 punch text input
    public void ReadPlayer1PunchInput(string s)
    {
        if (s.Length > 1)
        {
            punch1 = s.Substring(0, 1).ToUpper();
        }
        else
        {
            punch1 = s.ToUpper();

        }
        if (punch1 == punch2 || punch1 == kick1 || punch1 == jump1 || punch1 == bend2 || punch1 == kick2 || punch1 == jump2 || punch1 == bend2 )
        {
            punch1InputField.text = "..";
        }
        else
        {
            punch1InputField.text = punch1;
        }

    }

    // player 1 kick text input
    public void ReadPlayer1KickInput(string s)
    {
        if (s.Length > 1)
        {
            kick1 = s.Substring(0, 1).ToUpper();
        }
        else
        {
            kick1 = s.ToUpper();
        }
        if (kick1 == kick2 || kick1 == punch1 || kick1 == jump1 || kick1 == bend1 || kick1 == punch2 || kick1 == jump2 || kick1 == bend2)
        {
            kick1InputField.text = "..";
        }
        else
        {
            kick1InputField.text = kick1;
        }
    }

    // player 1 jump text input

    public void ReadPlayer1JumpInput(string s)
    {
        if (s.Length > 1)
        {
            jump1 = s.Substring(0, 1).ToUpper();
        }
        else
        {
            jump1 = s.ToUpper();
        }
        if (jump1 == jump2 || jump1 == punch1 || jump1 == kick1 || jump1 == bend1 || jump1 == punch2 || jump1 == kick2 || jump1 == bend2)
        {
            jump1InputField.text = "..";
        }
        else
        {
            jump1InputField.text = jump1;
        }
    }

    // player 1 bend text input
    public void ReadPlayer1BendInput(string s)
    {
        if (s.Length > 1)
        {
            bend1 = s.Substring(0, 1).ToUpper();
        }
        else
        {
            bend1 = s.ToUpper();

        }
        if(bend1 == bend2 || bend1 == punch1 || bend1 == kick1 || bend1 == jump1 || bend1 == punch2 || bend1 == kick2 || bend1 == jump2)
        {
            bend1InputField.text = "..";

        }
        else
        {
            bend1InputField.text = bend1;
        }
    }


    // player 2 punch text input
    public void ReadPlayer2PunchInput(string s)
    {
        if (s.Length > 1)
        {
            punch2 = s.Substring(0, 1).ToUpper();
        }
        else
        {
            punch2 = s.ToUpper();
        }
        if (punch2 == punch1 || punch2 == bend2 || punch2 == kick2 || punch2 == jump2 || punch2 == kick1|| punch2 == jump1 || punch2 == bend1)
        {
            punch2InputField.text = "..";
        }
        else
        {
            punch2InputField.text = punch2;
        }
    }

    // player 2 kick text input
    public void ReadPlayer2KickInput(string s)
    {
        if (s.Length > 1)
        {
            kick2 = s.Substring(0, 1).ToUpper();
        }
        else
        {
            kick2 = s.ToUpper();
        }
        if(kick2 == kick1 || kick2 == bend2 || kick2 == punch2 || kick2 == jump2 || kick2 == punch1 || kick2 == jump1 || kick2 == bend1)
        {
            kick2InputField.text = "..";
        }
        else
        {
            kick2InputField.text = kick2;
        }
    }

    // player 2 jump text input
    public void ReadPlayer2JumpInput(string s)
    {
        if (s.Length > 1)
        {
            jump2 = s.Substring(0, 1).ToUpper();
        }
        else
        {
            jump2 = s.ToUpper();
        }
        if(jump2 == jump1 || jump2 == bend2 || jump2 == punch2 || jump2 == kick2 || jump2 == punch1 || jump2 == kick1 || jump2 == bend1)
        {
            jump2InputField.text = "..";
        }
        else
        {
            jump2InputField.text = jump2;
        }
    }

    // player 2 bend text input
    public void ReadPlayer2BendInput(string s)
    {
        if (s.Length > 1)
        {
            bend2 = s.Substring(0, 1).ToUpper();
        }
        else
        {
            bend2 = s.ToUpper();
        }
        if (bend2 == bend1 || bend2 == jump2|| bend2 == punch2 || bend2 == kick2 || bend2 == punch1 || bend2 == kick1 || bend2 == jump1)
        {
            bend2InputField.text = "..";
        }
        else
        {
            bend2InputField.text = bend2;
        }
    }
}
