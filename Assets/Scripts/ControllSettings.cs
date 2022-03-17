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
            punch1InputField.text = punch1;

        }
        else
        {
            punch1 = s.ToUpper();
            punch1InputField.text = punch1;

        }

    }

    // player 1 kick text input
    public void ReadPlayer1KickInput(string s)
    {
        if (s.Length > 1)
        {
            kick1 = s.Substring(0, 1).ToUpper();
            kick1InputField.text = kick1;

        }
        else
        {
            kick1 = s.ToUpper();
            kick1InputField.text = kick1;

        }
    }

    // player 1 jump text input

    public void ReadPlayer1JumpInput(string s)
    {
        if (s.Length > 1)
        {
            jump1 = s.Substring(0, 1).ToUpper();
            jump1InputField.text = jump1;

        }
        else
        {
            jump1 = s.ToUpper();
            jump1InputField.text = jump1;

        }
    }

    // player 1 bend text input
    public void ReadPlayer1BendInput(string s)
    {
        if (s.Length > 1)
        {
            bend1 = s.Substring(0, 1).ToUpper();
            bend1InputField.text = bend1;

        }
        else
        {
            bend1 = s.ToUpper();
            bend1InputField.text = bend1;

        }
    }


    // player 2 punch text input
    public void ReadPlayer2PunchInput(string s)
    {
        if (s.Length > 1)
        {
            punch2 = s.Substring(0, 1).ToUpper();
            punch2InputField.text = punch2;

        }
        else
        {
            punch2 = s.ToUpper();
            punch2InputField.text = punch2;

        }

    }

    // player 2 kick text input
    public void ReadPlayer2KickInput(string s)
    {
        if (s.Length > 1)
        {
            kick2 = s.Substring(0, 1).ToUpper();
            kick2InputField.text = kick2;

        }
        else
        {
            kick2 = s.ToUpper();
            kick2InputField.text = kick2;

        }
    }

    // player 2 jump text input
    public void ReadPlayer2JumpInput(string s)
    {
        if (s.Length > 1)
        {
            jump2 = s.Substring(0, 1).ToUpper();
            jump2InputField.text = jump2;

        }
        else
        {
            jump2 = s.ToUpper();
            jump2InputField.text = jump2;

        }
    }

    // player 2 bend text input
    public void ReadPlayer2BendInput(string s)
    {
        if (s.Length > 1)
        {
            bend2 = s.Substring(0, 1).ToUpper();
            bend2InputField.text = bend2;

        }
        else
        {
            bend2 = s.ToUpper();
            bend2InputField.text = bend2;

        }
    }
}
