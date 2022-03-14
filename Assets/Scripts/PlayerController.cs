using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator playerAnim;
    bool AKeyPressed;
    float firstKeyTime;
    bool reset;
    bool rightPunch; // to know wether the right punch animation is activated to not interrupt it

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = gameObject.GetComponent<Animator>();
        AKeyPressed = false;
        firstKeyTime = 0;
        reset = false;
        rightPunch = false;
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
        }
        else
        {
            playerAnim.SetBool("Crouch_Bool", false);
        }

        //---------------------Punch---------------------------
        if (Input.GetKeyDown(KeyCode.A)&&AKeyPressed)
        {
            if (Time.time - firstKeyTime <= 0.3f)
            {
                playerAnim.SetBool("PunchRight_Trig", true);
                rightPunch = false;
            }
            else
            {
                playerAnim.SetBool("PunchLeft_Bool", false);
                rightPunch = false;
            }
            reset = true;   
            
        }
        if (Input.GetKeyDown(KeyCode.A) && !AKeyPressed && !rightPunch)
        {
            AKeyPressed = true;
            rightPunch = true;
            firstKeyTime = Time.time;
            playerAnim.SetBool("PunchLeft_Bool", true);
            DataManager.Instance.IsAttacking = true;
            StartCoroutine(SetIsAttackingToFalse());
        }
        else
        {
            playerAnim.SetBool("PunchLeft_Bool", false);
        }
        if (reset)
        {
            AKeyPressed = false;
            reset = false;
        }
        //---------------------Mid Kick--------------------------
        if (Input.GetKeyDown(KeyCode.Z))
        {
            playerAnim.SetBool("MidKick_Trig", true);
        }
        else
        {
            playerAnim.SetBool("MidKick_Trig", false);
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
