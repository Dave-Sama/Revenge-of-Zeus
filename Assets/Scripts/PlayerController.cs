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
        if (Input.GetKeyDown(KeyCode.A))
        {
            playerAnim.SetBool("PunchLeft_Bool", true);
        }
        else
        {
            playerAnim.SetBool("PunchLeft_Bool", false);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            playerAnim.SetBool("PunchRight_Bool", true);
        }
        else
        {
            playerAnim.SetBool("PunchRight_Bool", false);
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
}
