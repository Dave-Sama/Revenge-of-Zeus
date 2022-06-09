using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HitCollider : MonoBehaviour
{
    AudioSource hitSound;
    AudioSource blockSound;
    Slider playersSP;
    Slider opponentsSP;

    // -------For training-------
    //[SerializeField] GAObj gaObj; // for the genetic algorithm
    AI opponentAi; // for the agent
    AI playerAi;
    Actions playerActions;
    Actions opponentActions;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name != "Training")
        {
            if (SceneManager.GetActiveScene().buildIndex != 4) // Scene index 4 = End of Match scene
            {
                hitSound = GameObject.Find("Hit Sound").GetComponent<AudioSource>();
                blockSound = GameObject.Find("Block Sound").GetComponent<AudioSource>();
                playersSP = GameObject.FindGameObjectWithTag("PlayerSP").GetComponent<Slider>();
                opponentsSP = GameObject.FindGameObjectWithTag("OpponentSP").GetComponent<Slider>();
            }
        }
        else
        {
            opponentAi=GameObject.FindGameObjectWithTag("Opponent").GetComponent<AI>();
            playerAi = GameObject.FindGameObjectWithTag("Player").GetComponent<AI>();
            opponentActions=GameObject.FindGameObjectWithTag("Opponent").GetComponent<Actions>();
            playerActions=GameObject.FindGameObjectWithTag("Player").GetComponent<Actions>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        int damage=0;
        
        if(SceneManager.GetActiveScene().name == "Training")
        {
            if (other.CompareTag("Player") && opponentAi.isAttacking)
            {
                opponentAi.SP += 0.5f;
                //opponentActions.isAttacking = false;

                //if (gaObj.PlayersHP > 0)  ---------- this is for the genetic algorithm----------------
                //{
                //    gaObj.PlayersHP -= 1;
                //    gaObj.hitDetected = true;
                //}
                if (!playerAi.isBlocking && playerAi.isCrouching == 0)
                {
                    playerAi.HP--;
                    playerAi.beingHit = true;
                    Animator hitAnim = other.GetComponent<Animator>();
                    switch (opponentAi.actionNum)
                    {
                        case 3:
                            hitAnim.SetTrigger("HighLeftHit_Trig");
                            break;
                        case 4:
                            hitAnim.SetTrigger("HighRightHit_Trig");
                            break;
                        case 5:
                            hitAnim.SetTrigger("MidLeftHit_Trig");
                            break;
                        case 6:
                            hitAnim.SetTrigger("MidRightHit_Trig");
                            break;
                        case 7:
                            hitAnim.SetTrigger("HighLeftHit_Trig");
                            break;
                        case 8:
                            hitAnim.SetTrigger("HighRightHit_Trig");
                            break;
                        default:
                            break;
                    }
                }
                if(!playerAi.isBlocking && playerAi.isCrouching == 1)
                {
                    if(opponentAi.actionNum == 5 || opponentAi.actionNum == 6 || opponentAi.actionNum == 8 || (opponentAi.actionNum >= 17 && opponentAi.actionNum <= 19))
                    {
                        playerAi.HP--;
                        playerAi.beingHit = true;
                        Animator hitAnim = other.GetComponent<Animator>();
                        switch (opponentAi.actionNum){
                            case 5:
                            case 17:
                                hitAnim.SetTrigger("LowLeftHit_Trig");
                                break;
                            case 6:
                            case 18:
                                hitAnim.SetTrigger("LowRightHit_Trig");
                                break;
                            case 8:
                            case 19:
                                hitAnim.SetTrigger("LowPunchHit_Trig");
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            if(other.CompareTag("Opponent") && playerAi.isAttacking)
            {
                //playerActions.isAttacking = false;             
                playerAi.SP += 0.5f;

                if (!opponentAi.isBlocking)
                {
                    opponentAi.HP--;
                    opponentAi.beingHit = true;
                    Animator hitAnim = other.GetComponent<Animator>();
                    switch (playerAi.actionNum)
                    {
                        case 3:
                            hitAnim.SetTrigger("HighLeftHit_Trig");
                            break;
                        case 4:
                            hitAnim.SetTrigger("HighRightHit_Trig");
                            break;
                        case 5:
                            hitAnim.SetTrigger("MidLeftHit_Trig");
                            break;
                        case 6:
                            hitAnim.SetTrigger("MidRightHit_Trig");
                            break;
                        case 7:
                            hitAnim.SetTrigger("HighLeftHit_Trig");
                            break;
                        case 8:
                            hitAnim.SetTrigger("HighRightHit_Trig");
                            break;
                        default:
                            break;
                    }
                }
                if (!opponentAi.isBlocking && opponentAi.isCrouching == 1)
                {
                    if (playerAi.actionNum == 5 || playerAi.actionNum == 6 || playerAi.actionNum == 8 || (playerAi.actionNum >= 17 && playerAi.actionNum <= 19))
                    {
                        opponentAi.HP--;
                        opponentAi.beingHit = true;
                        Animator hitAnim = other.GetComponent<Animator>();
                        switch (playerAi.actionNum)
                        {
                            case 5:
                            case 17:
                                hitAnim.SetTrigger("LowLeftHit_Trig");
                                break;
                            case 6:
                            case 18:
                                hitAnim.SetTrigger("LowRightHit_Trig");
                                break;
                            case 8:
                            case 19:
                                hitAnim.SetTrigger("LowPunchHit_Trig");
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
        else
        {
            if (other.CompareTag("Opponent"))
            {
                if (DataManager.Instance.IsP1Attacking)
                {
                    playersSP.value = playersSP.value + 0.5f;
                    DataManager.Instance.OpponentBeingHit = true;
                }
                if (DataManager.Instance.P1AttackName == "")
                {
                    Debug.Log("is key pressed: " + Input.GetKeyDown(DataManager.Instance.upper_left_punch1_Keycode));
                }
                if ((DataManager.Instance.P1AttackName == "Up punch left" || DataManager.Instance.P1AttackName == "High kick") && DataManager.Instance.IsP1Attacking)
                {
                    Debug.Log("got a hit");
                    if (DataManager.Instance.P2Crouch)
                    {
                        damage = 0;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P1AttackName = "";
                        DataManager.Instance.IsPlayer = false;
                    }
                    else if (DataManager.Instance.P2Block)
                    {
                        damage = 0;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P1AttackName = "";
                        blockSound.Play();
                        DataManager.Instance.IsPlayer = false;
                    }
                    else
                    {
                        damage = 1;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P1AttackName = "";
                        hitSound.Play();
                        Animator hitAnim = other.GetComponent<Animator>();
                        hitAnim.SetTrigger("HighLeftHit_Trig");
                        DataManager.Instance.IsPlayer = false;
                    }

                }
                if (DataManager.Instance.P1AttackName == "Up punch right" && DataManager.Instance.IsP1Attacking)
                {
                    if (DataManager.Instance.P2Crouch)
                    {
                        damage = 0;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P1AttackName = "";
                        DataManager.Instance.IsPlayer = false;
                    }
                    else if (DataManager.Instance.P2Block)
                    {
                        damage = 0;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P1AttackName = "";
                        blockSound.Play();
                        DataManager.Instance.IsPlayer = false;
                    }
                    else
                    {
                        damage = 1;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P1AttackName = "";
                        hitSound.Play();
                        Animator hitAnim = other.GetComponent<Animator>();
                        hitAnim.SetTrigger("HighRightHit_Trig");
                        DataManager.Instance.IsPlayer = false;
                    }

                }
                if (DataManager.Instance.P1AttackName == "Mid kick" && DataManager.Instance.IsP1Attacking)
                {
                    if (DataManager.Instance.P2Block)
                    {
                        damage = 0;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P1AttackName = "";
                        blockSound.Play();
                        DataManager.Instance.IsPlayer = false;
                    }
                    else
                    {
                        damage = 1;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P1AttackName = "";
                        hitSound.Play();
                        Animator hitAnim = other.GetComponent<Animator>();
                        hitAnim.SetTrigger("HighRightHit_Trig");
                        DataManager.Instance.IsPlayer = false;
                    }
                }
                if (DataManager.Instance.P1AttackName == "Mid punch left" && DataManager.Instance.IsP1Attacking)
                {
                    if (DataManager.Instance.P2Block)
                    {
                        damage = 0;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P1AttackName = "";
                        blockSound.Play();
                        DataManager.Instance.IsPlayer = false;
                    }
                    else
                    {
                        damage = 2;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P1AttackName = "";
                        hitSound.Play();
                        Animator hitAnim = other.GetComponent<Animator>();
                        hitAnim.SetTrigger("MidLeftHit_Trig");
                        DataManager.Instance.IsPlayer = false;
                    }
                }
                if (DataManager.Instance.P1AttackName == "Mid punch right" && DataManager.Instance.IsP1Attacking)
                {
                    if (DataManager.Instance.P2Block)
                    {
                        damage = 0;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P1AttackName = "";
                        blockSound.Play();
                        DataManager.Instance.IsPlayer = false;
                    }
                    else
                    {
                        damage = 2;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P1AttackName = "";
                        hitSound.Play();
                        Animator hitAnim = other.GetComponent<Animator>();
                        hitAnim.SetTrigger("MidRightHit_Trig");
                        DataManager.Instance.IsPlayer = false;
                    }
                }
                if (DataManager.Instance.P1AttackName == "Special attack" && DataManager.Instance.IsP1Attacking && playersSP.value == playersSP.maxValue)
                {
                    playersSP.value = 0;
                    if (DataManager.Instance.P2Block)
                    {
                        damage = 0;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P1AttackName = "";
                        blockSound.Play();
                        DataManager.Instance.IsPlayer = false;
                    }
                    else
                    {
                        damage = 5;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P1AttackName = "";
                        hitSound.Play();
                        Animator hitAnim = other.GetComponent<Animator>();
                        hitAnim.SetTrigger("SpecialAttackHit_Trig");
                        DataManager.Instance.IsPlayer = false;
                    }
                }
                if (DataManager.Instance.P1AttackName == "Uppercut" && DataManager.Instance.IsP1Attacking)
                {
                    if (DataManager.Instance.P2Block)
                    {
                        damage = 0;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P1AttackName = "";
                        blockSound.Play();
                        DataManager.Instance.IsPlayer = false;
                    }
                    else
                    {
                        damage = 1;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P1AttackName = "";
                        hitSound.Play();
                        Animator hitAnim = other.GetComponent<Animator>();
                        hitAnim.SetTrigger("UppercutHit_Trig");
                        DataManager.Instance.IsPlayer = false;
                    }

                }
                if (DataManager.Instance.P1AttackName == "Low punch" && DataManager.Instance.IsP1Attacking)
                {
                    if (DataManager.Instance.P2Block)
                    {
                        damage = 0;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P1AttackName = "";
                        blockSound.Play();
                        DataManager.Instance.IsPlayer = false;
                    }
                    else
                    {
                        damage = 1;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P1AttackName = "";
                        hitSound.Play();
                        Animator hitAnim = other.GetComponent<Animator>();
                        hitAnim.SetTrigger("LowPunchHit_Trig");
                        DataManager.Instance.IsPlayer = false;
                    }
                }
                if (DataManager.Instance.P1AttackName == "Low kick" && DataManager.Instance.IsP1Attacking)
                {
                    if (DataManager.Instance.P2Block)
                    {
                        damage = 0;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P1AttackName = "";
                        blockSound.Play();
                        DataManager.Instance.IsPlayer = false;
                    }
                    else
                    {
                        damage = 1;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P1AttackName = "";
                        hitSound.Play();
                        Animator hitAnim = other.GetComponent<Animator>();
                        hitAnim.SetTrigger("LowKickHit_Trig");
                        DataManager.Instance.IsPlayer = false;
                    }
                }

                DataManager.Instance.OpponentsDamage = damage;
            }

            if (other.CompareTag("Player"))
            {
                if (DataManager.Instance.IsP2Attacking)
                {
                    opponentsSP.value = opponentsSP.value + 0.5f;
                    DataManager.Instance.PlayerBeingHit = true;
                }
                if ((DataManager.Instance.P2AttackName == "Up punch left" || DataManager.Instance.P2AttackName == "High kick") && DataManager.Instance.IsP2Attacking)
                {
                    if (DataManager.Instance.P1Crouch)
                    {
                        damage = 0;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P2AttackName = "";
                        DataManager.Instance.IsPlayer = true;
                    }
                    else if (DataManager.Instance.P1Block)
                    {
                        damage = 0;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P2AttackName = "";
                        blockSound.Play();
                        DataManager.Instance.IsPlayer = true;
                    }
                    else
                    {
                        damage = 1;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P2AttackName = "";
                        hitSound.Play();
                        Animator hitAnim = other.GetComponent<Animator>();
                        hitAnim.SetTrigger("HighLeftHit_Trig");
                        DataManager.Instance.IsPlayer = true;
                    }

                }
                if (DataManager.Instance.P2AttackName == "Up punch right" && DataManager.Instance.IsP2Attacking)
                {
                    if (DataManager.Instance.P1Crouch)
                    {
                        damage = 0;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P2AttackName = "";
                        DataManager.Instance.IsPlayer = true;
                    }
                    else if (DataManager.Instance.P1Block)
                    {
                        damage = 0;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P2AttackName = "";
                        blockSound.Play();
                        DataManager.Instance.IsPlayer = true;
                    }
                    else
                    {
                        damage = 1;
                        DataManager.Instance.IsP2Attacking = false;
                        DataManager.Instance.P2AttackName = "";
                        hitSound.Play();
                        Animator hitAnim = other.GetComponent<Animator>();
                        hitAnim.SetTrigger("HighRightHit_Trig");
                        DataManager.Instance.IsPlayer = true;
                    }
                }
                if (DataManager.Instance.P2AttackName == "Mid kick" && DataManager.Instance.IsP2Attacking)
                {
                    if (DataManager.Instance.P1Crouch)
                    {
                        damage = 0;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P2AttackName = "";
                        DataManager.Instance.IsPlayer = true;
                    }
                    else if (DataManager.Instance.P1Block)
                    {
                        damage = 0;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P2AttackName = "";
                        blockSound.Play();
                        DataManager.Instance.IsPlayer = true;
                    }
                    else
                    {
                        damage = 1;
                        DataManager.Instance.IsP2Attacking = false;
                        DataManager.Instance.P2AttackName = "";
                        hitSound.Play();
                        Animator hitAnim = other.GetComponent<Animator>();
                        hitAnim.SetTrigger("HighRightHit_Trig");
                        DataManager.Instance.IsPlayer = true;
                    }
                }
                if (DataManager.Instance.P2AttackName == "Mid punch left" && DataManager.Instance.IsP2Attacking)
                {
                    if (DataManager.Instance.P1Block)
                    {
                        damage = 0;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P2AttackName = "";
                        blockSound.Play();
                        DataManager.Instance.IsPlayer = true;
                    }
                    else
                    {
                        damage = 2;
                        DataManager.Instance.IsP2Attacking = false;
                        DataManager.Instance.P2AttackName = "";
                        hitSound.Play();
                        Animator hitAnim = other.GetComponent<Animator>();
                        hitAnim.SetTrigger("MidLeftHit_Trig");
                        DataManager.Instance.IsPlayer = true;
                    }
                }
                if (DataManager.Instance.P2AttackName == "Mid punch right" && DataManager.Instance.IsP2Attacking)
                {
                    if (DataManager.Instance.P1Block)
                    {
                        damage = 0;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P2AttackName = "";
                        blockSound.Play();
                        DataManager.Instance.IsPlayer = true;
                    }
                    else
                    {
                        damage = 2;
                        DataManager.Instance.IsP2Attacking = false;
                        DataManager.Instance.P2AttackName = "";
                        hitSound.Play();
                        Animator hitAnim = other.GetComponent<Animator>();
                        hitAnim.SetTrigger("MidRightHit_Trig");
                        DataManager.Instance.IsPlayer = true;
                    }
                }
                if (DataManager.Instance.P2AttackName == "Special attack" && DataManager.Instance.IsP2Attacking && opponentsSP.value == opponentsSP.maxValue)
                {
                    opponentsSP.value = 0;
                    if (DataManager.Instance.P1Block)
                    {
                        damage = 0;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P2AttackName = "";
                        blockSound.Play();
                        DataManager.Instance.IsPlayer = true;
                    }
                    else
                    {
                        damage = 5;
                        DataManager.Instance.IsP2Attacking = false;
                        DataManager.Instance.P2AttackName = "";
                        hitSound.Play();
                        Animator hitAnim = other.GetComponent<Animator>();
                        hitAnim.SetTrigger("SpecialAttackHit_Trig");
                        DataManager.Instance.IsPlayer = true;
                    }
                }
                if (DataManager.Instance.P2AttackName == "Uppercut" && DataManager.Instance.IsP2Attacking)
                {
                    if (DataManager.Instance.P1Block)
                    {
                        damage = 0;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P2AttackName = "";
                        blockSound.Play();
                        DataManager.Instance.IsPlayer = true;
                    }
                    else
                    {
                        damage = 1;
                        DataManager.Instance.IsP2Attacking = false;
                        DataManager.Instance.P2AttackName = "";
                        hitSound.Play();
                        Animator hitAnim = other.GetComponent<Animator>();
                        hitAnim.SetTrigger("UppercutHit_Trig");
                        DataManager.Instance.IsPlayer = true;
                    }
                }
                if (DataManager.Instance.P2AttackName == "Low punch" && DataManager.Instance.IsP2Attacking)
                {
                    if (DataManager.Instance.P1Block)
                    {
                        damage = 0;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P2AttackName = "";
                        blockSound.Play();
                        DataManager.Instance.IsPlayer = true;
                    }
                    else
                    {
                        damage = 1;
                        DataManager.Instance.IsP2Attacking = false;
                        DataManager.Instance.P2AttackName = "";
                        hitSound.Play();
                        Animator hitAnim = other.GetComponent<Animator>();
                        hitAnim.SetTrigger("LowPunchHit_Trig");
                        DataManager.Instance.IsPlayer = true;
                    }
                }
                if (DataManager.Instance.P2AttackName == "Low kick" && DataManager.Instance.IsP2Attacking)
                {
                    if (DataManager.Instance.P1Block)
                    {
                        damage = 0;
                        DataManager.Instance.IsP1Attacking = false;
                        DataManager.Instance.P2AttackName = "";
                        blockSound.Play();
                        DataManager.Instance.IsPlayer = true;
                    }
                    else
                    {
                        damage = 1;
                        DataManager.Instance.IsP2Attacking = false;
                        DataManager.Instance.P2AttackName = "";
                        hitSound.Play();
                        Animator hitAnim = other.GetComponent<Animator>();
                        hitAnim.SetTrigger("LowKickHit_Trig");
                        DataManager.Instance.IsPlayer = true;
                    }
                }

                DataManager.Instance.PlayersDamage = damage;
            }
        }
        
    }
}
