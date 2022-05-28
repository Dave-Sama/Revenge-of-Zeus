using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    int opponentsSP;
    float time;
    float sleep;
    bool isJumping;
    public bool animationFinished { get; private set; }
    AnimationCallback animCallback;
    Rigidbody fighterRB;
    //public bool isAttacking;
    //[SerializeField] AudioSource attackSound1;
    //[SerializeField] AudioSource attackSound2;


    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        opponentsSP = 0;
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
                break;   
            case 10:
                CancelBlock();
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
            transform.Translate(Vector3.forward * Time.deltaTime * 0.5f);  // note to myself: there are 4 fucked up characters that need Vector3.forward*Time.deltaTime*1
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
            //DataManager.Instance.IsP2Attacking = true;
            //DataManager.Instance.P2AttackName = "Jump punch";
            anim.SetTrigger("JumpPunch_Trig");
            //attackSound2.Play();
        }
    }
    public void AirKick()
    {
        //DataManager.Instance.IsP2Attacking = true;
        //DataManager.Instance.P2AttackName = "Jump kick";
        anim.SetTrigger("JumpKick_Trig");
        //attackSound1.Play();
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
            //DataManager.Instance.IsP2Attacking = true;
            //DataManager.Instance.P2AttackName = "Low punch";
            ResetAllTriggers();
            anim.SetTrigger("LowPunch_Trig");
            //attackSound2.Play();
        }
    }
    public void LowKick()
    {
        if (isCrouching)
        {
            //DataManager.Instance.IsP2Attacking = true;
            //DataManager.Instance.P2AttackName = "Low kick";
            ResetAllTriggers();
            anim.SetTrigger("LowKick_Trig");
            //attackSound1.Play();
        }
    }
    public void Uppercut()
    {
        if (isCrouching)
        {
            //DataManager.Instance.IsP2Attacking = true;
            //DataManager.Instance.P2AttackName = "Uppercut";
            ResetAllTriggers();
            anim.SetTrigger("Uppercut_Trig");
            //attackSound1.Play();
        }
    }
    public void LeftUpperPunch()
    {
        //isAttacking = true;
        //DataManager.Instance.IsP2Attacking = true;
        //DataManager.Instance.P2AttackName = "Up punch left";
        anim.SetTrigger("UpPunchLeft_Trig");
        //attackSound2.Play();
    }
    public void RightUpperPunch()
    {
        //isAttacking = true;
        //DataManager.Instance.IsP2Attacking = true;
        //DataManager.Instance.P2AttackName = "Up punch right";
        anim.SetTrigger("UpPunchRight_Trig");
        //attackSound1.Play();
    }
    public void LeftMidPunch()
    {
        //isAttacking = true;
        //DataManager.Instance.IsP2Attacking = true;
        //DataManager.Instance.P2AttackName = "Mid punch left";
        anim.SetTrigger("MidPunchLeft_Trig");
        //attackSound2.Play();
    }
    public void RightMidPunch()
    {
        //isAttacking = true;
        //DataManager.Instance.IsP2Attacking = true;
        //DataManager.Instance.P2AttackName = "Mid punch right";
        anim.SetTrigger("MidPunchRight_Trig");
        //attackSound1.Play();
    }
    public void HighKick()
    {
        //isAttacking = true;
        //DataManager.Instance.IsP2Attacking = true;
        //DataManager.Instance.P2AttackName = "High kick";
        anim.SetTrigger("HighKick_Trig");
        //attackSound1.Play();
    }
    public void MidKick()
    {
        //isAttacking = true;
        //DataManager.Instance.IsP2Attacking = true;
        //DataManager.Instance.P2AttackName = "Mid kick";
        anim.SetTrigger("MidKick_Trig");
        //attackSound2.Play();
    }
    public void SpecialAttack()
    {
        if(opponentsSP == 10)
        {
            //DataManager.Instance.IsP2Attacking = true;
            //DataManager.Instance.P2AttackName = "Special attack";
            anim.SetTrigger("SpecialAttack_Trig");
        }
    }
    public void Block()
    {
        //DataManager.Instance.P2Block = true;
        transform.Translate(Vector3.zero);
        anim.SetBool("Block_Bool", true);
    }
    public void CancelBlock()
    {
        //DataManager.Instance.P2Block = false;
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

    //IEnumerator Delay()
    //{
    //    animatorState = anim.GetCurrentAnimatorStateInfo(0);
    //    animatorClip=anim.GetCurrentAnimatorClipInfo(0);
    //    float time = animatorClip[0].clip.length * animatorState.normalizedTime;
    //    animationFinished = false;
    //    yield return new WaitForSeconds(time);
    //    animationFinished = true;
    //}

}
