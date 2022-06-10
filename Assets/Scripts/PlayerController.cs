using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Animator playerAnim;
    Rigidbody fighterRB;
    bool jump;
    bool onTheGround;
    bool isPressed;
    [SerializeField] AudioSource attackSound1;
    [SerializeField] AudioSource attackSound2;
    Slider playersSP;
    Slider opponentsSP;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = gameObject.GetComponent<Animator>();
        fighterRB = gameObject.GetComponent<Rigidbody>();
        jump = false;
        onTheGround = true;
        isPressed = false;
        attackSound1 = GameObject.Find("Attack Sound 1").GetComponent<AudioSource>();
        attackSound2 = GameObject.Find("Attack Sound 2").GetComponent<AudioSource>();
        playersSP = GameObject.FindGameObjectWithTag("PlayerSP").GetComponent<Slider>();
        opponentsSP = GameObject.FindGameObjectWithTag("OpponentSP").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        // ----------------------------To not allow the inputs to be added to the input buffer-------------------------------------------------
        if (playerAnim.GetCurrentAnimatorStateInfo(0).IsName("KB_Idle_1")
            || playerAnim.GetCurrentAnimatorStateInfo(0).IsName("KB_Idle_2")
            || playerAnim.GetCurrentAnimatorStateInfo(0).IsName("KB_Idle_3")
            || playerAnim.GetCurrentAnimatorStateInfo(0).IsName("KB_Idle_4")
            || playerAnim.GetCurrentAnimatorStateInfo(0).IsName("KB_Idle_5")
            || playerAnim.GetCurrentAnimatorStateInfo(0).IsName("KB_Idle_6"))
        {
            isPressed = false;
            DataManager.Instance.PlayerActionNum = 0;
        }
        //---------------------Walk Backwards---------------------------
        if ((gameObject.tag == "Player" && Input.GetKey(KeyCode.LeftArrow)) || (gameObject.tag == "Opponent" && Input.GetKey(KeyCode.Keypad6)))
        {
            playerAnim.SetFloat("Speed_Float", -1);
            DataManager.Instance.PlayerActionNum = 1;
            if ((gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.UpArrow)) || (gameObject.tag == "Opponent" && Input.GetKeyDown(KeyCode.Keypad8)))
            {
                onTheGround = false;
                playerAnim.SetBool("Jump_Bool", true);
                //DataManager.Instance.PlayerActionNum = 12;
            }
            else
            {
                onTheGround = true;
                playerAnim.SetBool("Jump_Bool", false);
                //DataManager.Instance.PlayerActionNum = 2;
            }
        }
        //---------------------Walk Forward---------------------------
        else if ((gameObject.tag == "Player" && Input.GetKey(KeyCode.RightArrow)) || (gameObject.tag == "Opponent" && Input.GetKey(KeyCode.Keypad4)))
        {
            playerAnim.SetFloat("Speed_Float", 1);
            //transform.Translate(Vector3.forward * Time.deltaTime*0.5f);  // note to myself: there are 4 fucked up characters that need Vector3.forward*Time.deltaTime*1
            DataManager.Instance.PlayerActionNum = 2;
            if ((gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.UpArrow)) || (gameObject.tag == "Opponent" && Input.GetKeyDown(KeyCode.Keypad8)))
            {
                onTheGround = false;
                playerAnim.SetBool("Jump_Bool", true);
                DataManager.Instance.PlayerActionNum = 12;
            }
            else
            {
                onTheGround = true;
                playerAnim.SetBool("Jump_Bool", false);
                DataManager.Instance.PlayerActionNum = 2;
            }
        }
        else
        {
            playerAnim.SetFloat("Speed_Float", 0);
            DataManager.Instance.PlayerActionNum = 0;
        }
        //---------------------Jump---------------------------
        if (onTheGround)
        {
            playerAnim.SetBool("Jump_Bool", false);
            if ((gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)) || 
                (gameObject.tag == "Opponent" && Input.GetKeyDown(KeyCode.Keypad8) && !Input.GetKey(KeyCode.Keypad4) && !Input.GetKey(KeyCode.Keypad6)))
            {
                onTheGround = false;
                jump = true;
            }
        }
        else
        {
            if (gameObject.tag == "Player")
            {
                // ---------------------P1 Jump Punch---------------------------

                if (Input.GetKeyDown(DataManager.Instance.middle_left_punch1_Keycode) && !isPressed)
                {
                    isPressed = true;
                    DataManager.Instance.IsP1Attacking = true;
                    DataManager.Instance.P1AttackName = "Jump punch";
                    DataManager.Instance.PlayerActionNum = 13;
                    playerAnim.SetTrigger("JumpPunch_Trig");
                    attackSound2.Play();
                }

                // ---------------------P1 Jump Kick---------------------------

                if (Input.GetKeyDown(DataManager.Instance.middle_right_punch1_Keycode) && !isPressed)
                {
                    isPressed = true;
                    DataManager.Instance.IsP1Attacking = true;
                    DataManager.Instance.P1AttackName = "Jump kick";
                    DataManager.Instance.PlayerActionNum = 14;
                    playerAnim.SetTrigger("JumpKick_Trig");
                    attackSound1.Play();
                }
            }

            if (gameObject.tag == "Opponent")
            {
                // ---------------------P2 Jump Punch---------------------------

                if (Input.GetKeyDown(DataManager.Instance.middle_left_punch2_Keycode) && !isPressed)
                {
                    isPressed = true;
                    DataManager.Instance.IsP2Attacking = true;
                    DataManager.Instance.P2AttackName = "Jump punch";
                    playerAnim.SetTrigger("JumpPunch_Trig");
                    attackSound2.Play();
                }

                // ---------------------P2 Jump Kick---------------------------

                if (Input.GetKeyDown(DataManager.Instance.middle_right_punch2_Keycode) && !isPressed)
                {
                    isPressed = true;
                    DataManager.Instance.IsP2Attacking = true;
                    DataManager.Instance.P2AttackName = "Jump kick";
                    playerAnim.SetTrigger("JumpKick_Trig");
                    attackSound1.Play();
                }
            }
        }
        //---------------------Crouch---------------------------
        if ((gameObject.tag == "Player" && Input.GetKey(KeyCode.DownArrow)) || (gameObject.tag == "Opponent" && Input.GetKey(KeyCode.Keypad2)))
        {
            playerAnim.SetBool("Crouch_Bool", true);
            DataManager.Instance.IsPlayerCrouching = 1;
            DataManager.Instance.PlayerActionNum = 15;

            if (playerAnim.GetCurrentAnimatorStateInfo(0).IsName("KB_crouch_Idle")) // To not allow the inputs to be added to the input buffer
            {
                isPressed = false;
            }

            // ---------------------Low Punch---------------------------

            if (gameObject.tag == "Player")
            {
                DataManager.Instance.P1Crouch = true;

                if (Input.GetKeyDown(DataManager.Instance.middle_left_punch1_Keycode) && !isPressed)
                {
                    isPressed = true;
                    DataManager.Instance.IsP1Attacking = true;
                    DataManager.Instance.P1AttackName = "Low punch";
                    DataManager.Instance.PlayerActionNum = 17;
                    playerAnim.SetTrigger("LowPunch_Trig");
                    attackSound2.Play();
                }
            }
            if (gameObject.tag == "Opponent")
            {
                DataManager.Instance.P2Crouch = true;

                if (Input.GetKeyDown(DataManager.Instance.middle_left_punch2_Keycode) && !isPressed)
                {
                    isPressed = true;
                    DataManager.Instance.IsP2Attacking = true;
                    DataManager.Instance.P2AttackName = "Low punch";
                    playerAnim.SetTrigger("LowPunch_Trig");
                    attackSound2.Play();
                }
            }

            // ---------------------Low Kick---------------------------

            if (gameObject.tag == "Player")
            {
                if (Input.GetKeyDown(DataManager.Instance.middle_right_punch1_Keycode) && !isPressed)
                {
                    isPressed = true;
                    DataManager.Instance.IsP1Attacking = true;
                    DataManager.Instance.P1AttackName = "Low kick";
                    DataManager.Instance.PlayerActionNum = 18;
                    playerAnim.SetTrigger("LowKick_Trig");
                    attackSound1.Play();
                }
            }
            if (gameObject.tag == "Opponent")
            {
                if (Input.GetKeyDown(DataManager.Instance.middle_right_punch2_Keycode) && !isPressed)
                {
                    isPressed = true;
                    DataManager.Instance.IsP2Attacking = true;
                    DataManager.Instance.P2AttackName = "Low kick";
                    playerAnim.SetTrigger("LowKick_Trig");
                    attackSound1.Play();
                }
            }

            // ---------------------Uppercut---------------------------

            if (gameObject.tag == "Player")
            {
                if (Input.GetKeyDown(DataManager.Instance.middle_kick1_Keycode) && !isPressed)
                {
                    isPressed = true;
                    DataManager.Instance.IsP1Attacking = true;
                    DataManager.Instance.P1AttackName = "Uppercut";
                    DataManager.Instance.PlayerActionNum = 19;
                    playerAnim.SetTrigger("Uppercut_Trig");
                    attackSound1.Play();
                }
            }
            if (gameObject.tag == "Opponent")
            {
                if (Input.GetKeyDown(DataManager.Instance.middle_kick2_Keycode) && !isPressed)
                {
                    isPressed = true;
                    DataManager.Instance.IsP2Attacking = true;
                    DataManager.Instance.P2AttackName = "Uppercut";
                    playerAnim.SetTrigger("Uppercut_Trig");
                    attackSound1.Play();
                }
            }
        }
        else
        {
            DataManager.Instance.IsPlayerCrouching = 0; // for the ML agent
            DataManager.Instance.PlayerActionNum = 16;

            // for the PvP
            if (gameObject.tag == "Player")
            {
                DataManager.Instance.P1Crouch = false;
            }
            if(gameObject.tag == "Opponent")
            {
                DataManager.Instance.P2Crouch = false;
            }
            playerAnim.SetBool("Crouch_Bool", false);
        }

        //---------------------Upper Punch---------------------------

        if (gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(DataManager.Instance.upper_left_punch1_Keycode) && !isPressed)
            {
                isPressed = true;
                DataManager.Instance.IsP1Attacking = true;
                DataManager.Instance.P1AttackName = "Up punch left";
                DataManager.Instance.PlayerActionNum = 3;
                playerAnim.SetTrigger("UpPunchLeft_Trig");
                attackSound2.Play();
            }
        }

        if (gameObject.tag == "Opponent")
        {
            if (Input.GetKeyDown(DataManager.Instance.upper_left_punch2_Keycode) && !isPressed)
            {
                isPressed = true;
                DataManager.Instance.IsP2Attacking = true;
                DataManager.Instance.P2AttackName = "Up punch left";
                playerAnim.SetTrigger("UpPunchLeft_Trig");
                attackSound2.Play();
            }
        }

        if (gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(DataManager.Instance.upper_right_punch1_Keycode) && !isPressed)
            {
                isPressed = true;
                DataManager.Instance.IsP1Attacking = true;
                DataManager.Instance.P1AttackName = "Up punch right";
                DataManager.Instance.PlayerActionNum = 4;
                playerAnim.SetTrigger("UpPunchRight_Trig");
                attackSound1.Play();
            }
        }
        if (gameObject.tag == "Opponent")
        {
            if (Input.GetKeyDown(DataManager.Instance.upper_right_punch2_Keycode) && !isPressed)
            {
                isPressed = true;
                DataManager.Instance.IsP2Attacking = true;
                DataManager.Instance.P2AttackName = "Up punch right";
                playerAnim.SetTrigger("UpPunchRight_Trig");
                attackSound1.Play();
            }
        }

        //---------------------Mid Punch--------------------------

        if (gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(DataManager.Instance.middle_left_punch1_Keycode) && !Input.GetKey(KeyCode.DownArrow) && onTheGround && !isPressed)
            {
                isPressed = true;
                DataManager.Instance.IsP1Attacking = true;
                DataManager.Instance.P1AttackName = "Mid punch left";
                DataManager.Instance.PlayerActionNum = 5;
                playerAnim.SetTrigger("MidPunchLeft_Trig");
                attackSound2.Play();
            }
        }
        if (gameObject.tag == "Opponent")
        {
            if (Input.GetKeyDown(DataManager.Instance.middle_left_punch2_Keycode) && !Input.GetKey(KeyCode.Keypad2) && onTheGround && !isPressed)
            {
                isPressed = true;
                DataManager.Instance.IsP2Attacking = true;
                DataManager.Instance.P2AttackName = "Mid punch left";
                playerAnim.SetTrigger("MidPunchLeft_Trig");
                attackSound2.Play();
            }
        }


        if (gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(DataManager.Instance.middle_right_punch1_Keycode) && !Input.GetKey(KeyCode.DownArrow) && onTheGround && !isPressed)
            {
                isPressed = true;
                DataManager.Instance.IsP1Attacking = true;
                DataManager.Instance.P1AttackName = "Mid punch right";
                DataManager.Instance.PlayerActionNum = 6;
                playerAnim.SetTrigger("MidPunchRight_Trig");
                attackSound1.Play();
            }
        }
        if (gameObject.tag == "Opponent")
        {
            if (Input.GetKeyDown(DataManager.Instance.middle_right_punch2_Keycode) && !Input.GetKey(KeyCode.Keypad2) && onTheGround && !isPressed)
            {
                isPressed = true;
                DataManager.Instance.IsP2Attacking = true;
                DataManager.Instance.P2AttackName = "Mid punch right";
                playerAnim.SetTrigger("MidPunchRight_Trig");
                attackSound1.Play();
            }
        }

        //---------------------High Kick--------------------------

        if (gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(DataManager.Instance.upper_kick1_Keycode) && !isPressed)
            {
                isPressed = true;
                DataManager.Instance.IsP1Attacking = true;
                DataManager.Instance.P1AttackName = "High kick";
                DataManager.Instance.PlayerActionNum = 7;
                playerAnim.SetTrigger("HighKick_Trig");
                attackSound1.Play();
            }
        }
        if (gameObject.tag == "Opponent")
        {
            if (Input.GetKeyDown(DataManager.Instance.upper_kick2_Keycode) && !isPressed)
            {
                isPressed = true;
                DataManager.Instance.IsP2Attacking = true;
                DataManager.Instance.P2AttackName = "High kick";
                playerAnim.SetTrigger("HighKick_Trig");
                attackSound1.Play();
            }
        }

        //---------------------Mid Kick--------------------------

        if (gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(DataManager.Instance.middle_kick1_Keycode) && !Input.GetKey(KeyCode.DownArrow) && !isPressed)
            {
                isPressed = true;
                DataManager.Instance.IsP1Attacking = true;
                DataManager.Instance.P1AttackName = "Mid kick";
                DataManager.Instance.PlayerActionNum = 8;
                playerAnim.SetTrigger("MidKick_Trig");
                attackSound2.Play();
            }
        }
        if (gameObject.tag == "Opponent")
        {
            if (Input.GetKeyDown(DataManager.Instance.middle_kick2_Keycode) && !Input.GetKey(KeyCode.Keypad2) && !isPressed)
            {
                isPressed = true;
                DataManager.Instance.IsP2Attacking = true;
                DataManager.Instance.P2AttackName = "Mid kick";
                playerAnim.SetTrigger("MidKick_Trig");
                attackSound2.Play();
            }
        }

        //---------------------Special Attack--------------------------

        if (gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(DataManager.Instance.special_attack1_Keycode) && !isPressed && playersSP.value==playersSP.maxValue)
            {
                isPressed = true;
                DataManager.Instance.IsP1Attacking = true;
                DataManager.Instance.P1AttackName = "Special attack";
                DataManager.Instance.PlayerActionNum = 20;
                DataManager.Instance.PlayerSpecialAttack = 1;
                playerAnim.SetTrigger("SpecialAttack_Trig");
            }
            else
            {
                DataManager.Instance.PlayerSpecialAttack = 0;
            }
        }
        if (gameObject.tag == "Opponent")
        {
            if (Input.GetKeyDown(DataManager.Instance.special_attack2_Keycode) && !isPressed && opponentsSP.value==opponentsSP.maxValue)
            {
                isPressed = true;
                DataManager.Instance.IsP2Attacking = true;
                DataManager.Instance.P2AttackName = "Special attack";
                playerAnim.SetTrigger("SpecialAttack_Trig");
            }
        }

        //---------------------Block--------------------------

        if (gameObject.tag == "Player")
        {
            if (Input.GetKey(DataManager.Instance.block1_Keycode))
            {
                DataManager.Instance.P1Block = true;
                DataManager.Instance.PlayerActionNum = 9;
                playerAnim.SetBool("Block_Bool", true);
            }
            else
            {
                DataManager.Instance.P1Block = false;
                DataManager.Instance.PlayerActionNum = 10;
                playerAnim.SetBool("Block_Bool", false);
            }
        }
        if (gameObject.tag == "Opponent")
        {
            if (Input.GetKey(DataManager.Instance.block2_Keycode))
            {
                DataManager.Instance.P2Block = true;
                playerAnim.SetBool("Block_Bool", true);
            }
            else
            {
                DataManager.Instance.P2Block = false;
                playerAnim.SetBool("Block_Bool", false);
            }
        }

        //if (DataManager.Instance.IsP1Attacking)
        //{
        //    StartCoroutine(ResetAttack());
        //}

    }

    private void FixedUpdate()
    {
        if (jump)
        {
            Jump();
            jump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        onTheGround = true;
        if (SceneManager.GetActiveScene().name != "Training")
        {
            DataManager.Instance.PlayerActionNum = 0;
        }
    }

    private void Jump()
    {
        playerAnim.SetBool("Jump_Bool", true);
        fighterRB.AddForce(Vector3.up * 4.5f, ForceMode.Impulse);
        DataManager.Instance.PlayerActionNum = 11;
    }

    //IEnumerator ResetAttack()
    //{
    //    yield return new WaitForSeconds(1);
    //    if (gameObject.tag == "Player")
    //    {
    //        DataManager.Instance.IsP1Attacking = false;
    //        DataManager.Instance.P1AttackName = "";
    //    }
    //    if (gameObject.tag == "Opponent")
    //    {
    //        DataManager.Instance.IsP2Attacking = false;
    //        DataManager.Instance.P2AttackName = "";
    //    }

    //}
}