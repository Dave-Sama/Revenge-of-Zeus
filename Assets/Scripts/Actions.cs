using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Actions : MonoBehaviour
{
    //public static Actions Instance { get; private set; }
    Animator anim;
    AnimatorStateInfo animatorState;
    AnimatorClipInfo[] animatorClip;
    public bool onTheGround;
    public bool isWalking;
    bool jump;
    bool isCrouching;
    bool instatiated;
    float time;
    float sleep;
    bool isJumping;
    public bool animationFinished { get; private set; }
    AnimationCallback animCallback;
    Rigidbody fighterRB;
    //public bool isAttacking;
    AudioSource attackSound1;
    AudioSource attackSound2;


    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        Debug.Log(anim);
        onTheGround = true;
        isWalking = false;
        jump = false;
        isCrouching = false;
        instatiated = false;
        time = 0;
        sleep = 0;
        animationFinished = true;
        animCallback = gameObject.GetComponent<AnimationCallback>();
        fighterRB = gameObject.GetComponent<Rigidbody>();
        isJumping = false;
        if(SceneManager.GetActiveScene().name != "Training" && gameObject.tag== "Opponent")
        {
            if(GameObject.Find("Attack Sound 1")!=null && GameObject.Find("Attack Sound 2") != null)
            {
                attackSound1 = GameObject.Find("Attack Sound 1").GetComponent<AudioSource>();
                attackSound2 = GameObject.Find("Attack Sound 2").GetComponent<AudioSource>();
            }
        }
        //isAttacking = false;
        //if (Instance == null)
        //{
        //    Instance = this;
        //    anim = gameObject.GetComponent<Animator>();
        //    opponentsSP = 0;
        //    onTheGround = true;
        //    isWalking = false;
        //    jump = false;
        //    isCrouching = false;
        //    instatiated = false;
        //}
        //else
        //{
        //    if (Instance != this)
        //    {
        //        Destroy(gameObject);
        //    }
        //}
    }

    public void IntToAction(int num)
    {
        switch (num)
        {
            case 0: 
                StayIdle();
                if(anim != null && animCallback != null)
                    animCallback.animationEnded = true;
                break;
            case 1:
                StayIdle();
                WalkBackwards();
                break;
            case 2:
                StayIdle();
                isJumping = false;
                WalkForward();
                break;
            case 3:
                StayIdle();
                LeftUpperPunch(); // A
                break;
            case 4:
                StayIdle();
                RightUpperPunch();  // S
                break;
            case 5:
                StayIdle();
                LeftMidPunch(); // Z
                break;
            case 6:
                StayIdle();
                RightMidPunch(); // X
                break;
            case 7:
                StayIdle();
                HighKick(); // D
                break;
            case 8:
                StayIdle();
                MidKick(); // C
                break;
            case 9:
                StayIdle();
                Block();
                //if (anim != null && animCallback != null)
                //    animCallback.animationEnded = true;
                break;   
            case 10:
                CancelBlock();
                //if (anim != null && animCallback != null)
                //    animCallback.animationEnded = true;
                break;
            case 11:
                StayIdle();
                Jump();
                break;
            case 12: // jump forward
                StayIdle();
                isJumping = true;
                WalkForward();
                break;
            case 13:
                StayIdle();
                AirPunch();
                break;
            case 14:
                StayIdle();
                AirKick();
                break;
            case 15:
                StayIdle();
                Crouch();
                break;
            case 16:
                StandUp();
                break;
            case 17:
                LowPunch();
                break;
            case 18:
                LowKick();
                break;
            case 19:
                Uppercut();
                break;
            case 20:
                StayIdle();
                SpecialAttack();
                break;
        }
    }
    public void StayIdle()
    {
        //isWalking = false;
        if(anim != null)
            anim.SetFloat("Speed_Float", 0);
        //isAttacking = false;
    }
    public void WalkBackwards()
    {
        anim.SetFloat("Speed_Float", -1);
        //isAttacking = false;
    }

    public void WalkForward()
    {
        //isAttacking = false;
        //isWalking = true;
        if (onTheGround)
        {
            anim.SetFloat("Speed_Float", 1);
            //transform.Translate(Vector3.forward * Time.deltaTime * 0.5f);  // note to myself: there are 4 fucked up characters that need Vector3.forward*Time.deltaTime*1
            Debug.Log("Walking forward");
        }
        if (isJumping)
        {
            onTheGround = false;
            anim.SetTrigger("Jump_Trig");
        }
        else
        {
            onTheGround = true;
            //anim.SetBool("Jump_Bool", false);
        }
       
    }
    public void Jump()
    {
        if (onTheGround)
        {
            //anim.SetBool("Jump_Bool", false);
            onTheGround = false;
            jump = true;
        }
    }
    //public void JumpForward()
    //{
    //    isJumping = true;
    //    WalkForward();
    //}
    public void AirPunch()
    {
        if (jump)
        {
            if(SceneManager.GetActiveScene().name != "Training" && gameObject.tag == "Opponent")
            {
                DataManager.Instance.IsP2Attacking = true;
                DataManager.Instance.P2AttackName = "Jump punch";
                if(attackSound2!=null)
                    attackSound2.Play();
            }
            anim.SetTrigger("JumpPunch_Trig");
        }
    }
    public void AirKick()
    {
        if (SceneManager.GetActiveScene().name != "Training" && gameObject.tag == "Opponent")
        {
            DataManager.Instance.IsP2Attacking = true;
            DataManager.Instance.P2AttackName = "Jump kick";
            if(attackSound1!=null)
                attackSound1.Play();
        }
        anim.SetTrigger("JumpKick_Trig");
        
    }
    public void Crouch()
    {
        anim.SetBool("Crouch_Bool", true);
        isCrouching = true;
    }
    public void StandUp()
    {
        anim.SetBool("Crouch_Bool", false);
        isCrouching = false;
    }
    public void LowPunch()
    {
        if (isCrouching)
        {
            if (SceneManager.GetActiveScene().name != "Training" && gameObject.tag == "Opponent")
            {
                DataManager.Instance.IsP2Attacking = true;
                DataManager.Instance.P2AttackName = "Low punch";
                if(attackSound2!=null)
                    attackSound2.Play();
            }
            ResetAllTriggers();
            anim.SetTrigger("LowPunch_Trig");
            
        }
    }
    public void LowKick()
    {
        if (isCrouching)
        {
            if (SceneManager.GetActiveScene().name != "Training" && gameObject.tag == "Opponent")
            {
                DataManager.Instance.IsP2Attacking = true;
                DataManager.Instance.P2AttackName = "Low kick";
                if(attackSound1!=null)
                    attackSound1.Play();
            }
            ResetAllTriggers();
            anim.SetTrigger("LowKick_Trig");  
        }
    }
    public void Uppercut()
    {
        if (isCrouching)
        {
            if (SceneManager.GetActiveScene().name != "Training" && gameObject.tag == "Opponent")
            {
                DataManager.Instance.IsP2Attacking = true;
                DataManager.Instance.P2AttackName = "Uppercut";
                if(attackSound1 != null)
                    attackSound1.Play();
            }
            ResetAllTriggers();
            anim.SetTrigger("Uppercut_Trig");
        }
    }
    public void LeftUpperPunch()
    {
        if (SceneManager.GetActiveScene().name != "Training" && gameObject.tag == "Opponent")
        {
            DataManager.Instance.IsP2Attacking = true;
            DataManager.Instance.P2AttackName = "Up punch left";
            if(attackSound2!=null)
                attackSound2.Play();
        }
        anim.SetTrigger("UpPunchLeft_Trig");
    }
    public void RightUpperPunch()
    {
        if (SceneManager.GetActiveScene().name != "Training" && gameObject.tag == "Opponent")
        {
            DataManager.Instance.IsP2Attacking = true;
            DataManager.Instance.P2AttackName = "Up punch right";
            if(attackSound1!=null)
                attackSound1.Play();
        }
        anim.SetTrigger("UpPunchRight_Trig");
    }
    public void LeftMidPunch()
    {
        if (SceneManager.GetActiveScene().name != "Training" && gameObject.tag == "Opponent")
        {
            DataManager.Instance.IsP2Attacking = true;
            DataManager.Instance.P2AttackName = "Mid punch left";
            if(attackSound2!=null)
                attackSound2.Play();
        }
            anim.SetTrigger("MidPunchLeft_Trig");
    }
    public void RightMidPunch()
    {
        if (SceneManager.GetActiveScene().name != "Training" && gameObject.tag == "Opponent")
        {
            DataManager.Instance.IsP2Attacking = true;
            DataManager.Instance.P2AttackName = "Mid punch right";
            if(attackSound1!=null)
                attackSound1.Play();
        }
            anim.SetTrigger("MidPunchRight_Trig");
    }
    public void HighKick()
    {
        if (SceneManager.GetActiveScene().name != "Training" && gameObject.tag == "Opponent")
        {
            DataManager.Instance.IsP2Attacking = true;
            DataManager.Instance.P2AttackName = "High kick";
            if(attackSound1!=null)
                attackSound1.Play();
        }
            anim.SetTrigger("HighKick_Trig");
    }
    public void MidKick()
    {
        if (SceneManager.GetActiveScene().name != "Training" && gameObject.tag == "Opponent")
        {
            DataManager.Instance.IsP2Attacking = true;
            DataManager.Instance.P2AttackName = "Mid kick";
            if(attackSound2!=null)
                attackSound2.Play();
        }
            anim.SetTrigger("MidKick_Trig");
    }
    public void SpecialAttack()
    {
        if (SceneManager.GetActiveScene().name != "Training" && gameObject.tag == "Opponent")
        {
            DataManager.Instance.IsP2Attacking = true;
            DataManager.Instance.P2AttackName = "Special attack";
        }
        anim.SetTrigger("SpecialAttack_Trig");
    }
    public void Block()
    {
        if (SceneManager.GetActiveScene().name != "Training" && gameObject.tag == "Opponent")
        {
            DataManager.Instance.P2Block = true;
        }
        transform.Translate(Vector3.zero);
        anim.SetBool("Block_Bool", true);
    }
    public void CancelBlock()
    {
        if (SceneManager.GetActiveScene().name != "Training" && gameObject.tag == "Opponent")
        {
            DataManager.Instance.P2Block = false;
        }
            anim.SetBool("Block_Bool", false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        onTheGround = true;
        //anim.SetBool("Jump_Bool", false);
    }
    private void FixedUpdate()
    {
        if (jump)
        {
            //anim.SetBool("Jump_Bool", true);
            anim.SetTrigger("Jump_Trig");
            fighterRB.AddForce(Vector3.up * 4.5f, ForceMode.Impulse);
            onTheGround = false;
            jump = false;
        }
    }

    private void ResetAllTriggers()
    {
        foreach (var param in anim.parameters)
        {
            if (param.type == AnimatorControllerParameterType.Trigger)
            {
                anim.ResetTrigger(param.name);
            }
        }
    }

}
