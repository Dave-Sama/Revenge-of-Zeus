using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator playerAnim;
    bool AKeyPressed;
    float firstKeyTime;
    bool reset;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = gameObject.GetComponent<Animator>();
        AKeyPressed = false;
        firstKeyTime = 0;
        reset = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerAnim.SetFloat("Speed_Float", -1);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            playerAnim.SetFloat("Speed_Float", 1);
        }
        else
        {
            playerAnim.SetFloat("Speed_Float", 0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerAnim.SetBool("Jump_Bool", true);
        }
        else
        {
            playerAnim.SetBool("Jump_Bool", false);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            playerAnim.SetBool("Crouch_Bool", true);
        }
        else
        {
            playerAnim.SetBool("Crouch_Bool", false);
        }

        //if (Input.GetKeyDown(KeyCode.A) && firstButtonPressed)
        //{
        //    if (Time.time - timeOfFirstButton < 0.5f)
        //    {
        //        Debug.Log("DoubleClicked");
        //    }
        //    else
        //    {
        //        Debug.Log("Too late");
        //    }

        //    reset = true;
        //}

        //if (Input.GetKeyDown(KeyCode.A) && !firstButtonPressed)
        //{
        //    firstButtonPressed = true;
        //    timeOfFirstButton = Time.time;
        //}

        //if (reset)
        //{
        //    firstButtonPressed = false;
        //    reset = false;
        //}

        if (Input.GetKeyDown(KeyCode.A)&&AKeyPressed)
        {
            if (Time.time - firstKeyTime < 0.5f)
            {
                playerAnim.SetBool("PunchRight_Bool", true);
            }
            reset = true;   
            
        }
        else
        {
            playerAnim.SetBool("PunchRight_Bool", false);
        }
        if (Input.GetKeyDown(KeyCode.A) && !AKeyPressed)
        {
            AKeyPressed = true;
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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            playerAnim.SetBool("MidKickLeft_Bool", true);
        }
        else
        {
            playerAnim.SetBool("MidKickLeft_Bool", false);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            playerAnim.SetBool("MidKickRight_Bool", true);
        }
        else
        {
            playerAnim.SetBool("MidKickRight_Bool", false);
        }
    }

    IEnumerator SetIsAttackingToFalse()
    {
        yield return new WaitForSeconds(1);
        DataManager.Instance.IsAttacking = false;
    }
}
