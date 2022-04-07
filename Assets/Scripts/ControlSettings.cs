using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ControlSettings : MonoBehaviour
{
    // player 1
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
    private string[] controls = { "A", "S", "D", "Z", "X", "C", "V", "1", "2", "3", "I", "O", "P", "J", "K", "L", ";", "0", "-", "=" };

    // player 2
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
        upper_left_punch1_Field.text = controls[0];
        upper_right_punch1_Field.text = controls[1];
        upper_kick1_Field.text = controls[2];
        middle_left_punch1_Field.text = controls[3];
        middle_right_punch1_Field.text = controls[4];
        middle_kick1_Field.text = controls[5];
        special_attack1_Field.text = controls[6];
        jump1_Field.text = controls[7];
        bend1_Field.text = controls[8];
        block1_Field.text = controls[9];


        // init player 2 inputs
        upper_left_punch2_Field.text = controls[10];
        upper_right_punch2_Field.text = controls[11];
        upper_kick2_Field.text = controls[12];
        middle_left_punch2_Field.text = controls[13];
        middle_right_punch2_Field.text = controls[14];
        middle_kick2_Field.text = controls[15];
        special_attack2_Field.text = controls[16];
        jump2_Field.text = controls[17];
        bend2_Field.text = controls[18];
        block2_Field.text = controls[19];
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

    // Get upper case substring
    private string GetUpperSub(string s)
    {
        if (s.Length > 1) return s.Substring(0, 1).ToUpper();
        else return s.ToUpper();
    }

    // Restore all Controllers to default state.
    public void RestoreControllers()
    {
        ReadPlayer1UpperLeftPunchInput(controls[0]);
        ReadPlayer1UpperRightPunchInput(controls[1]);
        ReadPlayer1UpperKickInput(controls[2]);
        ReadPlayer1MiddleLeftPunchInput(controls[3]);
        ReadPlayer1MiddleRightPunchInput(controls[4]);
        ReadPlayer1MiddleKickInput(controls[5]);
        ReadPlayer1SpecialAttackInput(controls[6]);
        ReadPlayer1JumpInput(controls[7]);
        ReadPlayer1BendInput(controls[8]);
        ReadPlayer1BlockInput(controls[9]);

        ReadPlayer2UpperLeftPunchInput(controls[10]);
        ReadPlayer2UpperRightPunchInput(controls[11]);
        ReadPlayer2UpperKickInput(controls[12]);
        ReadPlayer2MiddleLeftPunchInput(controls[13]);
        ReadPlayer2MiddleRightPunchInput(controls[14]);
        ReadPlayer2MiddleKickInput(controls[15]);
        ReadPlayer2SpecialAttackInput(controls[16]);
        ReadPlayer2JumpInput(controls[17]);
        ReadPlayer2BendInput(controls[18]);
        ReadPlayer2BlockInput(controls[19]);
    }


    // --------------------- Player 1 -------------------------// 
    // player 1 Upper Left Punch input
    public void ReadPlayer1UpperLeftPunchInput(string s)
    {
        string upper_left_punch1 = GetUpperSub(s);

        if (-1 != Array.IndexOf(controls, upper_left_punch1) && upper_left_punch1 != controls[0]) upper_left_punch1_Field.text = "..";
        else upper_left_punch1_Field.text = upper_left_punch1;
    }

    // player 1 Upper Right Punch input
    public void ReadPlayer1UpperRightPunchInput(string s)
    {
        string upper_right_punch1 = GetUpperSub(s);
        if (-1 != Array.IndexOf(controls, upper_right_punch1) && upper_right_punch1 != controls[1]) upper_right_punch1_Field.text = "..";
        else upper_right_punch1_Field.text = upper_right_punch1;
    }

    // player 1 Upper Kick input

    public void ReadPlayer1UpperKickInput(string s)
    {
        string upper_kick1 = GetUpperSub(s);
        if (-1 != Array.IndexOf(controls, upper_kick1) && upper_kick1 != controls[2]) upper_kick1_Field.text = "..";
        else upper_kick1_Field.text = upper_kick1;
    }

    // player 1 Middle Left Punch input
    public void ReadPlayer1MiddleLeftPunchInput(string s)
    {
        string middle_left_punch1 = GetUpperSub(s);
        if (-1 != Array.IndexOf(controls, middle_left_punch1) && middle_left_punch1 != controls[3]) middle_left_punch1_Field.text = "..";
        else middle_left_punch1_Field.text = middle_left_punch1;
    }


    // player 1 Middle Right Punch input
    public void ReadPlayer1MiddleRightPunchInput(string s)
    {
        string middle_right_punch1 = GetUpperSub(s);
        if (-1 != Array.IndexOf(controls, middle_right_punch1) && middle_right_punch1 != controls[4]) middle_right_punch1_Field.text = "..";
        else middle_right_punch1_Field.text = middle_right_punch1;
    }

    // player 1 Middle Kick input
    public void ReadPlayer1MiddleKickInput(string s)
    {
        string middle_kick1 = GetUpperSub(s);
        if (-1 != Array.IndexOf(controls, middle_kick1) && middle_kick1 != controls[5]) middle_kick1_Field.text = "..";
        else middle_kick1_Field.text = middle_kick1;
    }

    // player 1 Special Attack input
    public void ReadPlayer1SpecialAttackInput(string s)
    {
        string special_attack1 = GetUpperSub(s);
        if (-1 != Array.IndexOf(controls, special_attack1) && special_attack1 != controls[6]) special_attack1_Field.text = "..";
        else special_attack1_Field.text = special_attack1;
    }

    // player 1 Jump input
    public void ReadPlayer1JumpInput(string s)
    {
        string jump1 = GetUpperSub(s);
        if (-1 != Array.IndexOf(controls, jump1) && jump1 != controls[7]) jump1_Field.text = "..";
        else jump1_Field.text = jump1;
    }

    // player 1 bend input
    public void ReadPlayer1BendInput(string s)
    {
        string bend1 = GetUpperSub(s);
        if (-1 != Array.IndexOf(controls, bend1) && bend1 != controls[8]) bend1_Field.text = "..";
        else bend1_Field.text = bend1;
    }

    // player 1 block input
    public void ReadPlayer1BlockInput(string s)
    {
        string block1 = GetUpperSub(s);
        if (-1 != Array.IndexOf(controls, block1) && block1 != controls[9]) block1_Field.text = "..";
        else block1_Field.text = block1;
    }

    // ---------------------- Player 2 ------------------------  // 

    // player 2 Upper Left Punch input
    public void ReadPlayer2UpperLeftPunchInput(string s)
    {
        string upper_left_punch2 = GetUpperSub(s);
        if (-1 != Array.IndexOf(controls, upper_left_punch2) && upper_left_punch2 != controls[10]) upper_left_punch2_Field.text = "..";
        else upper_left_punch2_Field.text = upper_left_punch2;
    }

    // player 2 Upper Right Punch input
    public void ReadPlayer2UpperRightPunchInput(string s)
    {
        string upper_right_punch2 = GetUpperSub(s);
        if (-1 != Array.IndexOf(controls, upper_right_punch2) && upper_right_punch2 != controls[11]) upper_right_punch2_Field.text = "..";
        else upper_right_punch2_Field.text = upper_right_punch2;
    }

    // player 2 Upper Kick input
    public void ReadPlayer2UpperKickInput(string s)
    {
        string upper_kick2 = GetUpperSub(s);
        if (-1 != Array.IndexOf(controls, upper_kick2) && upper_kick2 != controls[12]) upper_kick2_Field.text = "..";
        else upper_kick2_Field.text = upper_kick2;
    }

    // player 2 Middle Left Punch input
    public void ReadPlayer2MiddleLeftPunchInput(string s)
    {
        string middle_left_punch2 = GetUpperSub(s);
        if (-1 != Array.IndexOf(controls, middle_left_punch2) && middle_left_punch2 != controls[13]) middle_left_punch2_Field.text = "..";
        else middle_left_punch2_Field.text = middle_left_punch2;
    }

    // player 2 Middle Right Punch input
    public void ReadPlayer2MiddleRightPunchInput(string s)
    {
        string middle_right_punch2 = GetUpperSub(s);
        if (-1 != Array.IndexOf(controls, middle_right_punch2) && middle_right_punch2 != controls[14]) middle_right_punch2_Field.text = "..";
        else middle_right_punch2_Field.text = middle_right_punch2;
    }

    // player 2 Middle Kick input
    public void ReadPlayer2MiddleKickInput(string s)
    {
        string middle_kick2 = GetUpperSub(s);
        if (-1 != Array.IndexOf(controls, middle_kick2) && middle_kick2 != controls[15]) middle_kick2_Field.text = "..";
        else middle_kick2_Field.text = middle_kick2;
    }

    // player 2 Special Attack input
    public void ReadPlayer2SpecialAttackInput(string s)
    {
        string special_attack2 = GetUpperSub(s);
        if (-1 != Array.IndexOf(controls, special_attack2) && special_attack2 != controls[16]) special_attack2_Field.text = "..";
        else special_attack2_Field.text = special_attack2;
    }

    // player 2 Jump input
    public void ReadPlayer2JumpInput(string s)
    {
        string jump2 = GetUpperSub(s);
        if (-1 != Array.IndexOf(controls, jump2) && jump2 != controls[17]) jump2_Field.text = "..";
        else jump2_Field.text = jump2;
    }

    // player 2 bend text input
    public void ReadPlayer2BendInput(string s)
    {
        string bend2 = GetUpperSub(s);
        if (-1 != Array.IndexOf(controls, bend2) && bend2 != controls[18]) bend2_Field.text = "..";
        else bend2_Field.text = bend2;
    }

    // player 2 Block input
    public void ReadPlayer2BlockInput(string s)
    {
        string block2 = GetUpperSub(s);
        if (-1 != Array.IndexOf(controls, block2) && block2 != controls[19]) block2_Field.text = "..";
        else block2_Field.text = block2;
    }
}
