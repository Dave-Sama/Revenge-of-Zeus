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
        if (Input.GetKeyDown(KeyCode.A))
        {
            DataManager.Instance.IsAttacking = true;
            DataManager.Instance.AttackName = "Up punch left";
            playerAnim.SetTrigger("UpPunchLeft_Trig");
            attackSound2.Play();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            DataManager.Instance.IsAttacking = true;
            DataManager.Instance.AttackName = "Up punch right";
            playerAnim.SetTrigger("UpPunchRight_Trig");
            attackSound1.Play();
        }
        //---------------------Mid Punch--------------------------
        if (Input.GetKeyDown(KeyCode.Z) && !Input.GetKey(KeyCode.DownArrow))
        {
            DataManager.Instance.IsAttacking = true;
            DataManager.Instance.AttackName = "Mid punch left";
            playerAnim.SetTrigger("MidPunchLeft_Trig");
            attackSound2.Play();
        }
        if (Input.GetKeyDown(KeyCode.X) && !Input.GetKey(KeyCode.DownArrow))
        {
            DataManager.Instance.IsAttacking = true;
            DataManager.Instance.AttackName = "Mid punch right";
            playerAnim.SetTrigger("MidPunchRight_Trig");
            attackSound1.Play();
        }
        //---------------------High Kick--------------------------
        if (Input.GetKeyDown(KeyCode.D))
        {
            DataManager.Instance.IsAttacking = true;
            DataManager.Instance.AttackName = "High kick";
            playerAnim.SetTrigger("HighKick_Trig");
            attackSound1.Play();
        }
        //---------------------Mid Kick--------------------------
        if (Input.GetKeyDown(KeyCode.C) && !Input.GetKey(KeyCode.DownArrow))
        {
            DataManager.Instance.IsAttacking = true;
            DataManager.Instance.AttackName = "Mid kick";
            playerAnim.SetTrigger("MidKick_Trig");
            attackSound2.Play();
        }
        //---------------------Special Attack--------------------------
        if (Input.GetKeyDown(KeyCode.V))
        {
            DataManager.Instance.IsAttacking = true;
            DataManager.Instance.AttackName = "Special attack";
            playerAnim.SetTrigger("SpecialAttack_Trig");
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
