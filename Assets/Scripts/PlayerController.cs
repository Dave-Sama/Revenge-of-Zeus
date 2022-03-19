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
                playerAnim.SetTrigger("LowPunch_Trig");
            }
            if (Input.GetKeyDown(KeyCode.X)) // Low kick
            {
                playerAnim.SetTrigger("LowKick_Trig");
            }
            if (Input.GetKeyDown(KeyCode.C)) // Uppercut
            {
                playerAnim.SetTrigger("Uppercut_Trig");
            }
        }
        else
        {
            playerAnim.SetBool("Crouch_Bool", false);
        }

        //---------------------Upper Punch---------------------------
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerAnim.SetTrigger("UpPunchLeft_Trig");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnim.SetTrigger("UpPunchRight_Trig");
        }
        //---------------------Mid Punch--------------------------
        if (Input.GetKeyDown(KeyCode.Z) && !Input.GetKey(KeyCode.DownArrow))
        {
            playerAnim.SetTrigger("MidPunchLeft_Trig");
        }
        if (Input.GetKeyDown(KeyCode.X) && !Input.GetKey(KeyCode.DownArrow))
        {
            playerAnim.SetTrigger("MidPunchRight_Trig");
        }
        //---------------------High Kick--------------------------
        if (Input.GetKeyDown(KeyCode.D))
        {
            playerAnim.SetTrigger("HighKick_Trig");
            DataManager.Instance.IsAttacking = true;
        }
        //---------------------Mid Kick--------------------------
        if (Input.GetKeyDown(KeyCode.C) && !Input.GetKey(KeyCode.DownArrow))
        {
            playerAnim.SetTrigger("MidKick_Trig");
            DataManager.Instance.IsAttacking = true;
        }
        //---------------------Special Attack--------------------------
        if (Input.GetKeyDown(KeyCode.V))
        {
            playerAnim.SetTrigger("SpecialAttack_Trig");
            DataManager.Instance.IsAttacking = true;
        }
        //---------------------Block--------------------------
        if (Input.GetKey(KeyCode.LeftControl))
        {
            playerAnim.SetBool("Block_Bool", true);
        }
        else
        {
            playerAnim.SetBool("Block_Bool", false);
        }

    }

    IEnumerator SetIsAttackingToFalse()
    {
        yield return new WaitForSeconds(1);
        DataManager.Instance.IsAttacking = false;
    }
}
