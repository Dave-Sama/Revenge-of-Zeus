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

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().buildIndex != 4) // Scene index 4 = End of Match scene
        {
            hitSound = GameObject.Find("Hit Sound").GetComponent<AudioSource>();
            blockSound = GameObject.Find("Block Sound").GetComponent<AudioSource>();
        }
        playersSP = GameObject.FindGameObjectWithTag("PlayerSP").GetComponent<Slider>();
        opponentsSP = GameObject.FindGameObjectWithTag("OpponentSP").GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        int damage=0;
        
        if(other.CompareTag("Opponent"))
        {
<<<<<<< HEAD
            if(DataManager.Instance.IsP1Attacking)
            {
                playersSP.value = playersSP.value + 0.5f;
            }
=======
>>>>>>> 6f0d715b3beae5c77c750d1a065298741b0816d1
            if (DataManager.Instance.P1AttackName == "")
            {
                Debug.Log("is key pressed: " + Input.GetKeyDown(DataManager.Instance.upper_left_punch1_Keycode));
            }
            if ((DataManager.Instance.P1AttackName == "Up punch left" || DataManager.Instance.P1AttackName == "High kick") && DataManager.Instance.IsP1Attacking)
            {
                Debug.Log("got a hit");
                if(DataManager.Instance.P2Crouch)
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
                if(DataManager.Instance.P2Crouch)
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
            if (DataManager.Instance.P1AttackName == "Special attack" && DataManager.Instance.IsP1Attacking && playersSP.value==playersSP.maxValue)
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
            if(DataManager.Instance.IsP2Attacking)
            {
                opponentsSP.value = opponentsSP.value + 0.5f;
            }
            if ((DataManager.Instance.P2AttackName == "Up punch left" || DataManager.Instance.P2AttackName == "High kick") && DataManager.Instance.IsP2Attacking)
            {
                if(DataManager.Instance.P1Crouch)
                {
                    damage = 0;
                    DataManager.Instance.IsP1Attacking = false;
                    DataManager.Instance.P2AttackName = "";
                    DataManager.Instance.IsPlayer = true;
                }
                else if(DataManager.Instance.P1Block)
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
            if(DataManager.Instance.P2AttackName == "Mid kick" && DataManager.Instance.IsP2Attacking)
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
            if (DataManager.Instance.P2AttackName == "Special attack" && DataManager.Instance.IsP2Attacking && opponentsSP.value==opponentsSP.maxValue)
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
