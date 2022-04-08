using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //---------------------Walk Backwards---------------------------
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerAnim.SetFloat("Speed_Float", -1);
        }
        //---------------------Walk Forward---------------------------
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            playerAnim.SetFloat("Speed_Float", 1);
        }
        else
        {
            playerAnim.SetFloat("Speed_Float", 0);
        }
        //---------------------Jump---------------------------
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerAnim.SetBool("Jump_Bool", true);
        }
        else
        {
            playerAnim.SetBool("Jump_Bool", false);
        }
        //---------------------Crouch---------------------------
        if (Input.GetKey(KeyCode.DownArrow))
        {
            playerAnim.SetBool("Crouch_Bool", true);
            if(Input.GetKeyDown(KeyCode.Z)) // Low punch
            {
                DataManager.Instance.IsAttacking = true;
                DataManager.Instance.AttackName = "Low punch";
                playerAnim.SetTrigger("LowPunch_Trig");
            }
            if (Input.GetKeyDown(KeyCode.X)) // Low kick
            {
                DataManager.Instance.IsAttacking = true;
                DataManager.Instance.AttackName = "Low kick";
                playerAnim.SetTrigger("LowKick_Trig");
            }
            if (Input.GetKeyDown(KeyCode.C)) // Uppercut
            {
                DataManager.Instance.IsAttacking = true;
                DataManager.Instance.AttackName = "Uppercut";
                playerAnim.SetTrigger("Uppercut_Trig");
            }
        }
        else
        {
            playerAnim.SetBool("Crouch_Bool", false);
        }

        //---------------------Upper Punch---------------------------
        if (Input.GetKeyDown(DataManager.Instance.upper_left_punch1_Keycode))
        {
            DataManager.Instance.IsAttacking = true;
            DataManager.Instance.AttackName = "Up punch left";
            playerAnim.SetTrigger("UpPunchLeft_Trig");
        }
        if (Input.GetKeyDown(DataManager.Instance.upper_right_punch1_Keycode))
        {
            DataManager.Instance.IsAttacking = true;
            DataManager.Instance.AttackName = "Up punch right";
            playerAnim.SetTrigger("UpPunchRight_Trig");
        }
        //---------------------Mid Punch--------------------------
        if (Input.GetKeyDown(DataManager.Instance.middle_left_punch1_Keycode) && !Input.GetKey(KeyCode.DownArrow))
        {
            DataManager.Instance.IsAttacking = true;
            DataManager.Instance.AttackName = "Mid punch left";
            playerAnim.SetTrigger("MidPunchLeft_Trig");
        }
        if (Input.GetKeyDown(DataManager.Instance.middle_right_punch1_Keycode) && !Input.GetKey(KeyCode.DownArrow))
        {
            DataManager.Instance.IsAttacking = true;
            DataManager.Instance.AttackName = "Mid punch right";
            playerAnim.SetTrigger("MidPunchRight_Trig");
        }
        //---------------------High Kick--------------------------
        if (Input.GetKeyDown(DataManager.Instance.upper_kick1_Keycode))
        {
            DataManager.Instance.IsAttacking = true;
            DataManager.Instance.AttackName = "High kick";
            playerAnim.SetTrigger("HighKick_Trig");
        }
        //---------------------Mid Kick--------------------------
        if (Input.GetKeyDown(DataManager.Instance.middle_kick1_Keycode) && !Input.GetKey(KeyCode.DownArrow))
        {
            DataManager.Instance.IsAttacking = true;
            DataManager.Instance.AttackName = "Mid kick";
            playerAnim.SetTrigger("MidKick_Trig");
        }
        //---------------------Special Attack--------------------------
        if (Input.GetKeyDown(DataManager.Instance.special_attack1_Keycode))
        {
            DataManager.Instance.IsAttacking = true;
            DataManager.Instance.AttackName = "Special attack";
            playerAnim.SetTrigger("SpecialAttack_Trig");
        }
        //---------------------Block--------------------------
        if (Input.GetKey(DataManager.Instance.block1_Keycode))
        {
            playerAnim.SetBool("Block_Bool", true);
        }
        else
        {
            playerAnim.SetBool("Block_Bool", false);
        }
        if (DataManager.Instance.IsAttacking)
        {
            StartCoroutine(ResetAttack());
        }

    }

    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(3);
        DataManager.Instance.IsAttacking = false;
        DataManager.Instance.AttackName = "";
    }
}
