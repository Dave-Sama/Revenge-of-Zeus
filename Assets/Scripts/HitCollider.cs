using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollider : MonoBehaviour
{
    AudioSource hitSound;

    // Start is called before the first frame update
    void Start()
    {
        hitSound = GameObject.Find("Hit Sound").GetComponent<AudioSource>();
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
            if ((DataManager.Instance.P1AttackName == "Up punch left" || DataManager.Instance.P1AttackName == "High kick") && other.CompareTag("Opponent") && DataManager.Instance.IsP1Attacking)
            {
                damage = 1;
                DataManager.Instance.IsP1Attacking = false;
                DataManager.Instance.P1AttackName = "";
                hitSound.Play();
                Animator hitAnim = other.GetComponent<Animator>();
                hitAnim.SetTrigger("HighLeftHit_Trig");
                DataManager.Instance.IsPlayer = false;
            }
            if ((DataManager.Instance.P1AttackName == "Up punch right" || DataManager.Instance.P1AttackName == "Mid kick") && other.CompareTag("Opponent") && DataManager.Instance.IsP1Attacking)
            {
                damage = 1;
                DataManager.Instance.IsP1Attacking = false;
                DataManager.Instance.P1AttackName = "";
                hitSound.Play();
                Animator hitAnim = other.GetComponent<Animator>();
                hitAnim.SetTrigger("HighRightHit_Trig");
                DataManager.Instance.IsPlayer = false;
            }
            if (DataManager.Instance.P1AttackName == "Mid punch left" && other.CompareTag("Opponent") && DataManager.Instance.IsP1Attacking)
            {
                damage = 2;
                DataManager.Instance.IsP1Attacking = false;
                DataManager.Instance.P1AttackName = "";
                hitSound.Play();
                Animator hitAnim = other.GetComponent<Animator>();
                hitAnim.SetTrigger("MidLeftHit_Trig");
                DataManager.Instance.IsPlayer = false;
            }
            if (DataManager.Instance.P1AttackName == "Mid punch right" && other.CompareTag("Opponent") && DataManager.Instance.IsP1Attacking)
            {
                damage = 2;
                DataManager.Instance.IsP1Attacking = false;
                DataManager.Instance.P1AttackName = "";
                hitSound.Play();
                Animator hitAnim = other.GetComponent<Animator>();
                hitAnim.SetTrigger("MidRightHit_Trig");
                DataManager.Instance.IsPlayer = false;
            }
            if (DataManager.Instance.P1AttackName == "Special attack" && other.CompareTag("Opponent") && DataManager.Instance.IsP1Attacking)
            {
                damage = 5;
                DataManager.Instance.IsP1Attacking = false;
                DataManager.Instance.P1AttackName = "";
                hitSound.Play();
                Animator hitAnim = other.GetComponent<Animator>();
                hitAnim.SetTrigger("SpecialAttackHit_Trig");
                DataManager.Instance.IsPlayer = false;
            }
            if (DataManager.Instance.P1AttackName == "Uppercut" && other.CompareTag("Opponent") && DataManager.Instance.IsP1Attacking)
            {
                damage = 1;
                DataManager.Instance.IsP1Attacking = false;
                DataManager.Instance.P1AttackName = "";
                hitSound.Play();
                Animator hitAnim = other.GetComponent<Animator>();
                hitAnim.SetTrigger("UppercutHit_Trig");
                DataManager.Instance.IsPlayer = false;
            }
            if (DataManager.Instance.P1AttackName == "Low punch" && other.CompareTag("Opponent") && DataManager.Instance.IsP1Attacking)
            {
                damage = 1;
                DataManager.Instance.IsP1Attacking = false;
                DataManager.Instance.P1AttackName = "";
                hitSound.Play();
                Animator hitAnim = other.GetComponent<Animator>();
                hitAnim.SetTrigger("LowPunchHit_Trig");
                DataManager.Instance.IsPlayer = false;
            }
            if (DataManager.Instance.P1AttackName == "Low kick" && other.CompareTag("Opponent") && DataManager.Instance.IsP1Attacking)
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
        
        DataManager.Instance.Damage = damage;
    }
}
