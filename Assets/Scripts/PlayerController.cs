using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator playerAnim;
    [SerializeField] AudioSource attackSound1;
    [SerializeField] AudioSource attackSound2;

    // Start is called before the first frame update
    void Start()
    {
        playerAnim = gameObject.GetComponent<Animator>();
        attackSound1 = GameObject.Find("Attack Sound 1").GetComponent<AudioSource>();
        attackSound2 = GameObject.Find("Attack Sound 2").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //---------------------Walk Backwards---------------------------
        if ((gameObject.tag=="Player" && Input.GetKey(KeyCode.LeftArrow)) || (gameObject.tag=="Opponent" && Input.GetKey(KeyCode.Keypad6)))
        {
            playerAnim.SetFloat("Speed_Float", -1);
        }
        //---------------------Walk Forward---------------------------
        else if ((gameObject.tag == "Player" && Input.GetKey(KeyCode.RightArrow)) || (gameObject.tag == "Opponent" && Input.GetKey(KeyCode.Keypad4)))
        {
            playerAnim.SetFloat("Speed_Float", 1);
        }
        else
        {
            playerAnim.SetFloat("Speed_Float", 0);
        }
        //---------------------Jump---------------------------
        if ((gameObject.tag == "Player" && Input.GetKey(KeyCode.UpArrow)) || (gameObject.tag == "Opponent" && Input.GetKey(KeyCode.Keypad8)))
        {
            playerAnim.SetBool("Jump_Bool", true);
        }
        else
        {
            playerAnim.SetBool("Jump_Bool", false);
        }
        //---------------------Crouch---------------------------
        if ((gameObject.tag == "Player" && Input.GetKey(KeyCode.DownArrow)) || (gameObject.tag == "Opponent" && Input.GetKey(KeyCode.Keypad2)))
        {
            playerAnim.SetBool("Crouch_Bool", true);
            if(Input.GetKeyDown(KeyCode.Z)) // Low punch
            {
                DataManager.Instance.IsAttacking = true;
                DataManager.Instance.AttackName = "Low punch";
                playerAnim.SetTrigger("LowPunch_Trig");
                attackSound2.Play();
            }
            if (Input.GetKeyDown(KeyCode.X)) // Low kick
            {
                DataManager.Instance.IsAttacking = true;
                DataManager.Instance.AttackName = "Low kick";
                playerAnim.SetTrigger("LowKick_Trig");
                attackSound1.Play();
            }
            if (Input.GetKeyDown(KeyCode.C)) // Uppercut
            {
                DataManager.Instance.IsAttacking = true;
                DataManager.Instance.AttackName = "Uppercut";
                playerAnim.SetTrigger("Uppercut_Trig");
                attackSound1.Play();
            }
        }
        else
        {
            playerAnim.SetBool("Crouch_Bool", false);
        }

        //---------------------Upper Punch---------------------------
        if ((gameObject.tag=="Player" && Input.GetKeyDown(DataManager.Instance.upper_left_punch1_Keycode)) || (gameObject.tag == "Opponent" && Input.GetKeyDown(DataManager.Instance.upper_left_punch2_Keycode)))
        {
            DataManager.Instance.IsAttacking = true;
            DataManager.Instance.AttackName = "Up punch left";
            playerAnim.SetTrigger("UpPunchLeft_Trig");
            attackSound2.Play();
        }
        if ((gameObject.tag == "Player" && Input.GetKeyDown(DataManager.Instance.upper_right_punch1_Keycode)) || (gameObject.tag == "Opponent" && Input.GetKeyDown(DataManager.Instance.upper_right_punch2_Keycode)))
        {
            DataManager.Instance.IsAttacking = true;
            DataManager.Instance.AttackName = "Up punch right";
            playerAnim.SetTrigger("UpPunchRight_Trig");
            attackSound1.Play();
        }
        //---------------------Mid Punch--------------------------
        if ((gameObject.tag == "Player" && Input.GetKeyDown(DataManager.Instance.middle_left_punch1_Keycode) && !Input.GetKey(KeyCode.DownArrow)) || (gameObject.tag == "Opponent" && Input.GetKeyDown(DataManager.Instance.middle_left_punch2_Keycode) && !Input.GetKey(KeyCode.Keypad2)))
        {
            DataManager.Instance.IsAttacking = true;
            DataManager.Instance.AttackName = "Mid punch left";
            playerAnim.SetTrigger("MidPunchLeft_Trig");
            attackSound2.Play();
        }
        if ((gameObject.tag == "Player" && Input.GetKeyDown(DataManager.Instance.middle_right_punch1_Keycode) && !Input.GetKey(KeyCode.DownArrow)) || (gameObject.tag == "Opponent" && Input.GetKeyDown(DataManager.Instance.middle_right_punch2_Keycode) && !Input.GetKey(KeyCode.Keypad2)))
        {
            DataManager.Instance.IsAttacking = true;
            DataManager.Instance.AttackName = "Mid punch right";
            playerAnim.SetTrigger("MidPunchRight_Trig");
            attackSound1.Play();
        }
        //---------------------High Kick--------------------------
        if ((gameObject.tag == "Player" && Input.GetKeyDown(DataManager.Instance.upper_kick1_Keycode)) || (gameObject.tag == "Opponent" && Input.GetKeyDown(DataManager.Instance.upper_kick2_Keycode)))
        {
            DataManager.Instance.IsAttacking = true;
            DataManager.Instance.AttackName = "High kick";
            playerAnim.SetTrigger("HighKick_Trig");
            attackSound1.Play();
        }
        //---------------------Mid Kick--------------------------
        if ((gameObject.tag == "Player" && Input.GetKeyDown(DataManager.Instance.middle_kick1_Keycode) && !Input.GetKey(KeyCode.DownArrow)) || (gameObject.tag == "Opponent" && Input.GetKeyDown(DataManager.Instance.middle_kick2_Keycode) && !Input.GetKey(KeyCode.Keypad2)))
        {
            DataManager.Instance.IsAttacking = true;
            DataManager.Instance.AttackName = "Mid kick";
            playerAnim.SetTrigger("MidKick_Trig");
            attackSound2.Play();
        }
        //---------------------Special Attack--------------------------
        if ((gameObject.tag == "Player" && Input.GetKeyDown(DataManager.Instance.special_attack1_Keycode)) || (gameObject.tag == "Opponent" && Input.GetKeyDown(DataManager.Instance.special_attack2_Keycode)))
        {
            DataManager.Instance.IsAttacking = true;
            DataManager.Instance.AttackName = "Special attack";
            playerAnim.SetTrigger("SpecialAttack_Trig");
        }
        //---------------------Block--------------------------
        if ((gameObject.tag == "Player" && Input.GetKey(DataManager.Instance.block1_Keycode)) || (gameObject.tag == "Opponent" && Input.GetKey(DataManager.Instance.block2_Keycode)))
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
        yield return new WaitForSeconds(2);
        DataManager.Instance.IsAttacking = false;
        DataManager.Instance.AttackName = "";
    }
}
