using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllSettings : MonoBehaviour
{
    // player 1
    private string punch1;
    private string kick1;
    private string jump1;
    private string bend1;
    public InputField punch1InputField;
    public InputField kick1InputField;
    public InputField jump1InputField;
    public InputField bend1InputField;

    // player 2
    private string punch2;
    private string kick2;
    private string jump2;
    private string bend2;
    public InputField punch2InputField;
    public InputField kick2InputField;
    public InputField jump2InputField;
    public InputField bend2InputField;

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
