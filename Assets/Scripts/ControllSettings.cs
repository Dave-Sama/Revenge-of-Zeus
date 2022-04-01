using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllSettings : MonoBehaviour
{
    // player 1
    private string upper_left_punch1 = "A";
    private string upper_right_punch1 = "S";
    private string upper_kick1 = "D";
    private string middle_left_punch1 = "Z";
    private string middle_right_punch1 = "X";
    private string middle_kick1 = "C";
    private string special_attack1 = "V";
    private string jump1 = "1";
    private string bend1 = "2";
    private string block1 = "3";
    public InputField upper_left_punch1_Field;
    public InputField upper_right_punch1_Field;
    public InputField upper_kick1_Field;
    public InputField middle_left_punch1_Field;
    public InputField middle_right_punch1_Field;
    public InputField middle_kick1_Field;
    public InputField special_attack1_Field;
    public InputField jump1_Field;
    public InputField bend1_Field;
    public InputField block1_Field;

    // player 2
    private string upper_left_punch2 = "I";
    private string upper_right_punch2 = "O";
    private string upper_kick2 = "P";
    private string middle_left_punch2 = "J";
    private string middle_right_punch2 = "K";
    private string middle_kick2 = "L";
    private string special_attack2 = ";";
    private string jump2 = "0";
    private string bend2 = "-";
    private string block2 = "=";
    public InputField upper_left_punch2_Field;
    public InputField upper_right_punch2_Field;
    public InputField upper_kick2_Field;
    public InputField middle_left_punch2_Field;
    public InputField middle_right_punch2_Field;
    public InputField middle_kick2_Field;
    public InputField special_attack2_Field;
    public InputField jump2_Field;
    public InputField bend2_Field;
    public InputField block2_Field;

    // game objects

    [SerializeField] private GameObject mainSettings;
    [SerializeField] private GameObject controlSettings;
    [SerializeField] private GameObject soundSettingsWindow;
    [SerializeField] private GameObject videoSettingsWindow;

    // Start is called before the first frame update
    void Start()
    {
        //Changes the character limit in the main input field.
        upper_left_punch2_Field.characterLimit = 1; 
        upper_right_punch2_Field.characterLimit = 1; 
        upper_kick2_Field.characterLimit = 1; 
        middle_left_punch2_Field.characterLimit = 1; 
        middle_right_punch2_Field.characterLimit = 1; 
        middle_kick2_Field.characterLimit = 1; 
        special_attack2_Field.characterLimit = 1; 
        jump2_Field.characterLimit = 1; 
        bend2_Field.characterLimit = 1; 
        block2_Field.characterLimit = 1; 

        upper_left_punch2_Field.characterLimit = 1;
        upper_right_punch2_Field.characterLimit = 1;
        upper_kick2_Field.characterLimit = 1;
        middle_left_punch2_Field.characterLimit = 1;
        middle_right_punch2_Field.characterLimit = 1;
        middle_kick2_Field.characterLimit = 1;
        special_attack2_Field.characterLimit = 1;
        jump2_Field.characterLimit = 1;
        bend2_Field.characterLimit = 1;
        block2_Field.characterLimit = 1;


        // init player 1 inputs
        upper_left_punch1_Field.text = "A";
        upper_right_punch1_Field.text = "S";
        upper_kick1_Field.text = "D";
        middle_left_punch1_Field.text = "Z";
        middle_right_punch1_Field.text = "X";
        middle_kick1_Field.text = "C";
        special_attack1_Field.text = "V";
        jump1_Field.text = "1";
        bend1_Field.text = "2";
        block1_Field.text = "3";


        // init player 2 inputs
        upper_left_punch2_Field.text = "I";
        upper_right_punch2_Field.text = "O";
        upper_kick2_Field.text = "P";
        middle_left_punch2_Field.text = "J";
        middle_right_punch2_Field.text = "K";
        middle_kick2_Field.text = "L";
        special_attack2_Field.text = ";";
        jump2_Field.text = "0";
        bend2_Field.text = "-";
        block2_Field.text = "=";
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
        ReadPlayer1UpperLeftPunchInput("A");
        ReadPlayer1UpperRightPunchInput("S");
        ReadPlayer1UpperKickInput("D");
        ReadPlayer1MiddleLeftPunchInput("Z");
        ReadPlayer1MiddleRightPunchInput("X");
        ReadPlayer1MiddleKickInput("C");
        ReadPlayer1SpecialAttackInput("V");
        ReadPlayer1JumpInput("1");
        ReadPlayer1BendInput("2");
        ReadPlayer1BlockInput("3");

        ReadPlayer2UpperLeftPunchInput("I");
        ReadPlayer2UpperRightPunchInput("O");
        ReadPlayer2UpperKickInput("P");
        ReadPlayer2MiddleLeftPunchInput("J");
        ReadPlayer2MiddleRightPunchInput("K");
        ReadPlayer2MiddleKickInput("L");
        ReadPlayer2SpecialAttackInput(";");
        ReadPlayer2JumpInput("0");
        ReadPlayer2BendInput("-");
        ReadPlayer2BlockInput("=");
    }


    // --------------------- Player 1 -------------------------// 
    // player 1 Upper Left Punch input
    public void ReadPlayer1UpperLeftPunchInput(string s)
    {
        if (s.Length > 1)
        {
            upper_left_punch1 = s.Substring(0, 1).ToUpper();
        }
        else
        {
            upper_left_punch1 = s.ToUpper();

        }

        if (upper_left_punch1 == upper_left_punch2 || 
            upper_left_punch1 == upper_right_punch1 ||
            upper_left_punch1 == upper_kick1 ||
            upper_left_punch1 == middle_left_punch1 ||
            upper_left_punch1 == middle_right_punch1 ||
            upper_left_punch1 == middle_kick1 || 
            upper_left_punch1 == special_attack1 || 
            upper_left_punch1 == jump1 ||
            upper_left_punch1 == bend1 || 
            upper_left_punch1 == block1 ||
            upper_left_punch1 == upper_right_punch2 ||
            upper_left_punch1 == upper_kick2 || 
            upper_left_punch1 == middle_left_punch2 ||
            upper_left_punch1 == middle_right_punch2 ||
            upper_left_punch1 == middle_kick2 ||
            upper_left_punch1 == special_attack2 ||
            upper_left_punch1 == jump2 ||
            upper_left_punch1 == bend2 ||
            upper_left_punch1 == block2 )
        {
            upper_left_punch1_Field.text = "..";
        }
        else
        {
            upper_left_punch1_Field.text = upper_left_punch1;
        }

    }

    // player 1 Upper Right Punch input
    public void ReadPlayer1UpperRightPunchInput(string s)
    {
        if (s.Length > 1)
        {
            upper_right_punch1 = s.Substring(0, 1).ToUpper();
        }
        else
        {
            upper_right_punch1 = s.ToUpper();
        }
        if (upper_right_punch1 == upper_right_punch2 ||
            upper_right_punch1 == upper_left_punch1 ||
            upper_right_punch1 == upper_kick1 ||
            upper_right_punch1 == middle_left_punch1 ||
            upper_right_punch1 == middle_right_punch1 ||
            upper_right_punch1 == middle_kick1 ||
            upper_right_punch1 == special_attack1 ||
            upper_right_punch1 == jump1 ||
            upper_right_punch1 == bend1 ||
            upper_right_punch1 == block1 ||
            upper_right_punch1 == upper_left_punch2 ||
            upper_right_punch1 == upper_kick2 ||
            upper_right_punch1 == middle_left_punch2 ||
            upper_right_punch1 == middle_right_punch2 ||
            upper_right_punch1 == middle_kick2 ||
            upper_right_punch1 == special_attack2 ||
            upper_right_punch1 == jump2 ||
            upper_right_punch1 == bend2 ||
            upper_right_punch1 == block2)
        {
            upper_right_punch1_Field.text = "..";
        }
        else
        {
            upper_right_punch1_Field.text = upper_right_punch1;
        }
    }

    // player 1 Upper Kick input

    public void ReadPlayer1UpperKickInput(string s)
    {
        if (s.Length > 1)
        {
            upper_kick1 = s.Substring(0, 1).ToUpper();
        }
        else
        {
            upper_kick1 = s.ToUpper();
        }
        if (upper_kick1 == upper_kick2 ||
            upper_kick1 == upper_left_punch1 ||
            upper_kick1 == upper_right_punch1 ||
            upper_kick1 == middle_left_punch1 ||
            upper_kick1 == middle_right_punch1 ||
            upper_kick1 == middle_kick1 ||
            upper_kick1 == special_attack1 ||
            upper_kick1 == jump1 ||
            upper_kick1 == bend1 ||
            upper_kick1 == block1 ||
            upper_kick1 == upper_left_punch2 ||
            upper_kick1 == upper_right_punch2 ||
            upper_kick1 == middle_left_punch2 ||
            upper_kick1 == middle_right_punch2 ||
            upper_kick1 == middle_kick2 ||
            upper_kick1 == special_attack2 ||
            upper_kick1 == jump2 ||
            upper_kick1 == bend2 ||
            upper_kick1 == block2)
        {
            upper_kick1_Field.text = "..";
        }
        else
        {
            upper_kick1_Field.text = upper_kick1;
        }
    }

    // player 1 Middle Left Punch input
    public void ReadPlayer1MiddleLeftPunchInput(string s)
    {
        if (s.Length > 1)
        {
            middle_left_punch1 = s.Substring(0, 1).ToUpper();
        }
        else
        {
            middle_left_punch1 = s.ToUpper();

        }
        if (middle_left_punch1 == middle_left_punch2 ||
            middle_left_punch1 == upper_left_punch1 ||
            middle_left_punch1 == upper_right_punch1 ||
            middle_left_punch1 == upper_kick1 ||
            middle_left_punch1 == middle_right_punch1 ||
            middle_left_punch1 == middle_kick1 ||
            middle_left_punch1 == special_attack1 ||
            middle_left_punch1 == jump1 ||
            middle_left_punch1 == bend1 ||
            middle_left_punch1 == block1 ||
            middle_left_punch1 == upper_left_punch2 ||
            middle_left_punch1 == upper_right_punch2 ||
            middle_left_punch1 == upper_kick2 ||
            middle_left_punch1 == middle_right_punch2 ||
            middle_left_punch1 == middle_kick2 ||
            middle_left_punch1 == special_attack2 ||
            middle_left_punch1 == jump2 ||
            middle_left_punch1 == bend2 ||
            middle_left_punch1 == block2)
        {
            middle_left_punch1_Field.text = "..";

        }
        else
        {
            middle_left_punch1_Field.text = middle_left_punch1;
        }
    }


    // player 1 Middle Right Punch input
    public void ReadPlayer1MiddleRightPunchInput(string s)
    {
        if (s.Length > 1)
        {
            middle_right_punch1 = s.Substring(0, 1).ToUpper();
        }
        else
        {
            middle_right_punch1 = s.ToUpper();
        }
        if (middle_right_punch1 == middle_right_punch2 ||
            middle_right_punch1 == upper_left_punch1 ||
            middle_right_punch1 == upper_right_punch1 ||
            middle_right_punch1 == upper_kick1 ||
            middle_right_punch1 == middle_left_punch1 ||
            middle_right_punch1 == middle_kick1 ||
            middle_right_punch1 == special_attack1 ||
            middle_right_punch1 == jump1 ||
            middle_right_punch1 == bend1 ||
            middle_right_punch1 == block1 ||
            middle_right_punch1 == upper_left_punch2 ||
            middle_right_punch1 == upper_right_punch2 ||
            middle_right_punch1 == upper_kick2 ||
            middle_right_punch1 == middle_left_punch2 ||
            middle_right_punch1 == middle_kick2 ||
            middle_right_punch1 == special_attack2 ||
            middle_right_punch1 == jump2 ||
            middle_right_punch1 == bend2 ||
            middle_right_punch1 == block2)
        {
            middle_right_punch1_Field.text = "..";
        }
        else
        {
            middle_right_punch1_Field.text = middle_right_punch1;
        }
    }
    
    // player 1 Middle Kick input
    public void ReadPlayer1MiddleKickInput(string s)
    {
        if (s.Length > 1)
        {
            middle_kick1 = s.Substring(0, 1).ToUpper();
        }
        else
        {
            middle_kick1 = s.ToUpper();
        }
        if (middle_kick1 == middle_kick2 ||
            middle_kick1 == upper_left_punch1 ||
            middle_kick1 == upper_right_punch1 ||
            middle_kick1 == upper_kick1 ||
            middle_kick1 == middle_left_punch1 ||
            middle_kick1 == middle_right_punch1 ||
            middle_kick1 == special_attack1 ||
            middle_kick1 == jump1 ||
            middle_kick1 == bend1 ||
            middle_kick1 == block1 ||
            middle_kick1 == upper_left_punch2 ||
            middle_kick1 == upper_right_punch2 ||
            middle_kick1 == upper_kick2 ||
            middle_kick1 == middle_left_punch2 ||
            middle_kick1 == middle_right_punch2 ||
            middle_kick1 == special_attack2 ||
            middle_kick1 == jump2 ||
            middle_kick1 == bend2 ||
            middle_kick1 == block2)
        {
            middle_kick1_Field.text = "..";
        }
        else
        {
            middle_kick1_Field.text = middle_kick1;
        }
    }

    // player 1 Special Attack input
    public void ReadPlayer1SpecialAttackInput(string s)
    {
        if (s.Length > 1)
        {
            special_attack1 = s.Substring(0, 1).ToUpper();
        }
        else
        {
            special_attack1 = s.ToUpper();
        }
        if (special_attack1 == special_attack2 ||
            special_attack1 == upper_left_punch1 ||
            special_attack1 == upper_right_punch1 ||
            special_attack1 == upper_kick1 ||
            special_attack1 == middle_left_punch1 ||
            special_attack1 == middle_right_punch1 ||
            special_attack1 == middle_kick1 ||
            special_attack1 == jump1 ||
            special_attack1 == bend1 ||
            special_attack1 == block1 ||
            special_attack1 == upper_left_punch2 ||
            special_attack1 == upper_right_punch2 ||
            special_attack1 == upper_kick2 ||
            special_attack1 == middle_left_punch2 ||
            special_attack1 == middle_right_punch2 ||
            special_attack1 == middle_kick2 ||
            special_attack1 == jump2 ||
            special_attack1 == bend2 ||
            special_attack1 == block2)
        {
            special_attack1_Field.text = "..";
        }
        else
        {
            special_attack1_Field.text = special_attack1;
        }
    }

    // player 1 Jump input
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
        if (jump1 == jump2 ||
            jump1 == upper_left_punch1 ||
            jump1 == upper_right_punch1 ||
            jump1 == upper_kick1 ||
            jump1 == middle_left_punch1 ||
            jump1 == middle_right_punch1 ||
            jump1 == middle_kick1 ||
            jump1 == special_attack1 ||
            jump1 == bend1 ||
            jump1 == block1 ||
            jump1 == upper_left_punch2 ||
            jump1 == upper_right_punch2 ||
            jump1 == upper_kick2 ||
            jump1 == middle_left_punch2 ||
            jump1 == middle_right_punch2 ||
            jump1 == middle_kick2 ||
            jump1 == special_attack2 ||
            jump1 == bend2 ||
            jump1 == block2)
        {
            jump1_Field.text = "..";
        }
        else
        {
            jump1_Field.text = jump1;
        }
    }
    
    // player 1 bend input
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
        if (bend1 == bend2 ||
            bend1 == upper_left_punch1 ||
            bend1 == upper_right_punch1 ||
            bend1 == upper_kick1 ||
            bend1 == middle_left_punch1 ||
            bend1 == middle_right_punch1 ||
            bend1 == middle_kick1 ||
            bend1 == special_attack1 ||
            bend1 == jump1 ||
            bend1 == block1 ||
            bend1 == upper_left_punch2 ||
            bend1 == upper_right_punch2 ||
            bend1 == upper_kick2 ||
            bend1 == middle_left_punch2 ||
            bend1 == middle_right_punch2 ||
            bend1 == middle_kick2 ||
            bend1 == special_attack2 ||
            bend1 == jump2 ||
            bend1 == block2)
        {
            bend1_Field.text = "..";
        }
        else
        {
            bend1_Field.text = bend1;
        }
    }

    // player 1 block input
    public void ReadPlayer1BlockInput(string s)
    {
        if (s.Length > 1)
        {
            block1 = s.Substring(0, 1).ToUpper();
        }
        else
        {
            block1 = s.ToUpper();
        }
        if (block1 == block2 ||
            block1 == upper_left_punch1 ||
            block1 == upper_right_punch1 ||
            block1 == upper_kick1 ||
            block1 == middle_left_punch1 ||
            block1 == middle_right_punch1 ||
            block1 == middle_kick1 ||
            block1 == special_attack1 ||
            block1 == jump1 ||
            block1 == bend1 ||
            block1 == upper_left_punch2 ||
            block1 == upper_right_punch2 ||
            block1 == upper_kick2 ||
            block1 == middle_left_punch2 ||
            block1 == middle_right_punch2 ||
            block1 == middle_kick2 ||
            block1 == special_attack2 ||
            block1 == jump2 ||
            block1 == bend2)
        {
            block1_Field.text = "..";
        }
        else
        {
            block1_Field.text = block1;
        }
    }

    // ---------------------- Player 2 ------------------------  // 

    // player 2 Upper Left Punch input
    public void ReadPlayer2UpperLeftPunchInput(string s)
    {
        if (s.Length > 1)
        {
            upper_left_punch2 = s.Substring(0, 1).ToUpper();
        }
        else
        {
            upper_left_punch2 = s.ToUpper();

        }

        if (upper_left_punch2 == upper_left_punch1 ||
            upper_left_punch2 == upper_right_punch2 ||
            upper_left_punch2 == upper_kick2 ||
            upper_left_punch2 == middle_left_punch2 ||
            upper_left_punch2 == middle_right_punch2 ||
            upper_left_punch2 == middle_kick2 ||
            upper_left_punch2 == special_attack2 ||
            upper_left_punch2 == jump2 ||
            upper_left_punch2 == bend2 ||
            upper_left_punch2 == block2 ||
            upper_left_punch2 == upper_right_punch1 ||
            upper_left_punch2 == upper_kick1 ||
            upper_left_punch2 == middle_left_punch1 ||
            upper_left_punch2 == middle_right_punch1 ||
            upper_left_punch2 == middle_kick1 ||
            upper_left_punch2 == special_attack1 ||
            upper_left_punch2 == jump1 ||
            upper_left_punch2 == bend1 ||
            upper_left_punch2 == block1)
        {
            upper_left_punch2_Field.text = "..";
        }
        else
        {
            upper_left_punch2_Field.text = upper_left_punch2;
        }

    }

    // player 2 Upper Right Punch input
    public void ReadPlayer2UpperRightPunchInput(string s)
    {
        if (s.Length > 1)
        {
            upper_right_punch2 = s.Substring(0, 1).ToUpper();
        }
        else
        {
            upper_right_punch2 = s.ToUpper();
        }
        if (upper_right_punch2 == upper_right_punch1 ||
            upper_right_punch2 == upper_left_punch2 ||
            upper_right_punch2 == upper_kick2 ||
            upper_right_punch2 == middle_left_punch2 ||
            upper_right_punch2 == middle_right_punch2 ||
            upper_right_punch2 == middle_kick2 ||
            upper_right_punch2 == special_attack2 ||
            upper_right_punch2 == jump2 ||
            upper_right_punch2 == bend2 ||
            upper_right_punch2 == block2 ||
            upper_right_punch2 == upper_left_punch1 ||
            upper_right_punch2 == upper_kick1 ||
            upper_right_punch2 == middle_left_punch1 ||
            upper_right_punch2 == middle_right_punch1 ||
            upper_right_punch2 == middle_kick1 ||
            upper_right_punch2 == special_attack1 ||
            upper_right_punch2 == jump1 ||
            upper_right_punch2 == bend1 ||
            upper_right_punch2 == block1)
        {
            upper_right_punch2_Field.text = "..";
        }
        else
        {
            upper_right_punch2_Field.text = upper_right_punch2;
        }
    }

    // player 2 Upper Kick input
    public void ReadPlayer2UpperKickInput(string s)
    {
        if (s.Length > 1)
        {
            upper_kick2 = s.Substring(0, 1).ToUpper();
        }
        else
        {
            upper_kick2 = s.ToUpper();
        }
        if (upper_kick2 == upper_kick1 ||
            upper_kick2 == upper_left_punch2 ||
            upper_kick2 == upper_right_punch2 ||
            upper_kick2 == middle_left_punch2 ||
            upper_kick2 == middle_right_punch2 ||
            upper_kick2 == middle_kick2 ||
            upper_kick2 == special_attack2 ||
            upper_kick2 == jump2 ||
            upper_kick2 == bend2 ||
            upper_kick2 == block2 ||
            upper_kick2 == upper_left_punch1 ||
            upper_kick2 == upper_right_punch1 ||
            upper_kick2 == middle_left_punch1 ||
            upper_kick2 == middle_right_punch1 ||
            upper_kick2 == middle_kick1 ||
            upper_kick2 == special_attack1 ||
            upper_kick2 == jump1 ||
            upper_kick2 == bend1 ||
            upper_kick2 == block1)
        {
            upper_kick2_Field.text = "..";
        }
        else
        {
            upper_kick2_Field.text = upper_kick2;
        }
    }

    // player 2 Middle Left Punch input
    public void ReadPlayer2MiddleLeftPunchInput(string s)
    {
        if (s.Length > 1)
        {
            middle_left_punch2 = s.Substring(0, 1).ToUpper();
        }
        else
        {
            middle_left_punch2 = s.ToUpper();

        }
        if (middle_left_punch2 == middle_left_punch1 ||
            middle_left_punch2 == upper_left_punch2 ||
            middle_left_punch2 == upper_right_punch2 ||
            middle_left_punch2 == upper_kick2 ||
            middle_left_punch2 == middle_right_punch2 ||
            middle_left_punch2 == middle_kick2 ||
            middle_left_punch2 == special_attack2 ||
            middle_left_punch2 == jump2 ||
            middle_left_punch2 == bend2 ||
            middle_left_punch2 == block2 ||
            middle_left_punch2 == upper_left_punch1 ||
            middle_left_punch2 == upper_right_punch1 ||
            middle_left_punch2 == upper_kick1 ||
            middle_left_punch2 == middle_right_punch1 ||
            middle_left_punch2 == middle_kick1 ||
            middle_left_punch2 == special_attack1 ||
            middle_left_punch2 == jump1 ||
            middle_left_punch2 == bend1 ||
            middle_left_punch2 == block1)
        {
            middle_left_punch2_Field.text = "..";

        }
        else
        {
            middle_left_punch2_Field.text = middle_left_punch2;
        }
    }


    // player 2 Middle Right Punch input
    public void ReadPlayer2MiddleRightPunchInput(string s)
    {
        if (s.Length > 1)
        {
            middle_right_punch2 = s.Substring(0, 1).ToUpper();
        }
        else
        {
            middle_right_punch2 = s.ToUpper();
        }
        if (middle_right_punch2 == middle_right_punch1 ||
            middle_right_punch2 == upper_left_punch2 ||
            middle_right_punch2 == upper_right_punch2||
            middle_right_punch2 == upper_kick2 ||
            middle_right_punch2 == middle_left_punch2 ||
            middle_right_punch2 == middle_kick2 ||
            middle_right_punch2 == special_attack2 ||
            middle_right_punch2 == jump2 ||
            middle_right_punch2 == bend2 ||
            middle_right_punch2 == block2 ||
            middle_right_punch2 == upper_left_punch1 ||
            middle_right_punch2 == upper_right_punch1 ||
            middle_right_punch2 == upper_kick1 ||
            middle_right_punch2 == middle_left_punch1 ||
            middle_right_punch2 == middle_kick1 ||
            middle_right_punch2 == special_attack1 ||
            middle_right_punch2 == jump1 ||
            middle_right_punch2 == bend1 ||
            middle_right_punch2 == block1)
        {
            middle_right_punch2_Field.text = "..";
        }
        else
        {
            middle_right_punch2_Field.text = middle_right_punch2;
        }
    }

    // player 2 Middle Kick input
    public void ReadPlayer2MiddleKickInput(string s)
    {
        if (s.Length > 1)
        {
            middle_kick2 = s.Substring(0, 1).ToUpper();
        }
        else
        {
            middle_kick2 = s.ToUpper();
        }
        if (middle_kick2 == middle_kick1 ||
            middle_kick2 == upper_left_punch2 ||
            middle_kick2 == upper_right_punch2 ||
            middle_kick2 == upper_kick2 ||
            middle_kick2 == middle_left_punch2 ||
            middle_kick2 == middle_right_punch2 ||
            middle_kick2 == special_attack2 ||
            middle_kick2 == jump2 ||
            middle_kick2 == bend2 ||
            middle_kick2 == block2 ||
            middle_kick2 == upper_left_punch1 ||
            middle_kick2 == upper_right_punch1 ||
            middle_kick2 == upper_kick1 ||
            middle_kick2 == middle_left_punch1 ||
            middle_kick2 == middle_right_punch1 ||
            middle_kick2 == special_attack1 ||
            middle_kick2 == jump1 ||
            middle_kick2 == bend1 ||
            middle_kick2 == block1)
        {
            middle_kick2_Field.text = "..";
        }
        else
        {
            middle_kick2_Field.text = middle_kick2;
        }
    }

    // player 2 Special Attack input
    public void ReadPlayer2SpecialAttackInput(string s)
    {
        if (s.Length > 1)
        {
            special_attack2 = s.Substring(0, 1).ToUpper();
        }
        else
        {
            special_attack2 = s.ToUpper();
        }
        if (special_attack2 == special_attack1 ||
            special_attack2 == upper_left_punch2 ||
            special_attack2 == upper_right_punch2 ||
            special_attack2 == upper_kick2 ||
            special_attack2 == middle_left_punch2 ||
            special_attack2 == middle_right_punch2 ||
            special_attack2 == middle_kick2 ||
            special_attack2 == jump2 ||
            special_attack2 == bend2 ||
            special_attack2 == block2 ||
            special_attack2 == upper_left_punch1 ||
            special_attack2 == upper_right_punch1 ||
            special_attack2 == upper_kick1 ||
            special_attack2 == middle_left_punch1 ||
            special_attack2 == middle_right_punch1 ||
            special_attack2 == middle_kick1 ||
            special_attack2 == jump1||
            special_attack2 == bend1 ||
            special_attack2 == block1)
        {
            special_attack2_Field.text = "..";
        }
        else
        {
            special_attack2_Field.text = special_attack2;
        }
    }

    // player 2 Jump input
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
        if (jump2 == jump1 ||
            jump2 == upper_left_punch2 ||
            jump2 == upper_right_punch2 ||
            jump2 == upper_kick2 ||
            jump2 == middle_left_punch2 ||
            jump2 == middle_right_punch2 ||
            jump2 == middle_kick2 ||
            jump2 == special_attack2 ||
            jump2 == bend2 ||
            jump2 == block2 ||
            jump2 == upper_left_punch1 ||
            jump2 == upper_right_punch1 ||
            jump2 == upper_kick1 ||
            jump2 == middle_left_punch1 ||
            jump2 == middle_right_punch1 ||
            jump2 == middle_kick1 ||
            jump2 == special_attack1 ||
            jump2 == bend1 ||
            jump2 == block1)
        {
            jump2_Field.text = "..";
        }
        else
        {
            jump2_Field.text = jump2;
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
        if (bend2 == bend1 ||
            bend2 == upper_left_punch2 ||
            bend2 == upper_right_punch2 ||
            bend2 == upper_kick2 ||
            bend2 == middle_left_punch2 ||
            bend2 == middle_right_punch2 ||
            bend2 == middle_kick2 ||
            bend2 == special_attack2 ||
            bend2 == jump2 ||
            bend2 == block2 ||
            bend2 == upper_left_punch1 ||
            bend2 == upper_right_punch1 ||
            bend2 == upper_kick1 ||
            bend2 == middle_left_punch1 ||
            bend2 == middle_right_punch1 ||
            bend2 == middle_kick1 ||
            bend2 == special_attack1 ||
            bend2 == jump1 ||
            bend2 == block1)
        {
            bend2_Field.text = "..";
        }
        else
        {
            bend2_Field.text = bend2;
        }
    }

    // player 2 Block input
    public void ReadPlayer2BlockInput(string s)
    {
        if (s.Length > 1)
        {
            block2 = s.Substring(0, 1).ToUpper();
        }
        else
        {
            block2 = s.ToUpper();
        }
        if (block2 == block1 ||
            block2 == upper_left_punch2 ||
            block2 == upper_right_punch2 ||
            block2 == upper_kick2 ||
            block2 == middle_left_punch2 ||
            block2 == middle_right_punch2 ||
            block2 == middle_kick2 ||
            block2 == special_attack2 ||
            block2 == jump2 ||
            block2 == bend2 ||
            block2 == upper_left_punch1 ||
            block2 == upper_right_punch1 ||
            block2 == upper_kick1 ||
            block2 == middle_left_punch1 ||
            block2 == middle_right_punch1 ||
            block2 == middle_kick1 ||
            block2 == special_attack1 ||
            block2 == jump1 ||
            block2 == bend1)
        {
            block2_Field.text = "..";
        }
        else
        {
            block2_Field.text = block2;
        }
    }
}
