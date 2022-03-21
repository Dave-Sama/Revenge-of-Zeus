using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCollider : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        int damage=0;
        if((DataManager.Instance.AttackName== "Up punch left" || DataManager.Instance.AttackName == "High kick") && other.CompareTag("Opponent")&&DataManager.Instance.IsAttacking)
        {
            damage = 1;
            DataManager.Instance.IsAttacking = false;
            DataManager.Instance.AttackName = "";
            Animator hitAnim = other.GetComponent<Animator>();
            hitAnim.SetTrigger("HighLeftHit_Trig");
            DataManager.Instance.IsPlayer = false;
        }
        if ((DataManager.Instance.AttackName == "Up punch right" || DataManager.Instance.AttackName == "Mid kick") && other.CompareTag("Opponent") && DataManager.Instance.IsAttacking)
        {
            damage = 1;
            DataManager.Instance.IsAttacking = false;
            DataManager.Instance.AttackName = "";
            Animator hitAnim = other.GetComponent<Animator>();
            hitAnim.SetTrigger("HighRightHit_Trig");
            DataManager.Instance.IsPlayer = false;
        }
        if (DataManager.Instance.AttackName== "Mid punch left" && other.CompareTag("Opponent") && DataManager.Instance.IsAttacking)
        {
            damage = 2;
            DataManager.Instance.IsAttacking = false;
            DataManager.Instance.AttackName = "";
            Animator hitAnim = other.GetComponent<Animator>();
            hitAnim.SetTrigger("MidLeftHit_Trig");
            DataManager.Instance.IsPlayer = false;
        }
        if (DataManager.Instance.AttackName=="Mid punch right" && other.CompareTag("Opponent") && DataManager.Instance.IsAttacking)
        {
            damage = 2;
            DataManager.Instance.IsAttacking = false;
            DataManager.Instance.AttackName = "";
            Animator hitAnim = other.GetComponent<Animator>();
            hitAnim.SetTrigger("MidRightHit_Trig");
            DataManager.Instance.IsPlayer = false;
        }
        if (DataManager.Instance.AttackName == "Special attack" && other.CompareTag("Opponent") && DataManager.Instance.IsAttacking)
        {
            damage = 5;
            DataManager.Instance.IsAttacking = false;
            DataManager.Instance.AttackName = "";
            Animator hitAnim = other.GetComponent<Animator>();
            hitAnim.SetTrigger("SpecialAttackHit_Trig");
            DataManager.Instance.IsPlayer = false;
        }
        if (DataManager.Instance.AttackName == "Uppercut" && other.CompareTag("Opponent") && DataManager.Instance.IsAttacking)
        {
            damage = 1;
            DataManager.Instance.IsAttacking = false;
            DataManager.Instance.AttackName = "";
            Animator hitAnim = other.GetComponent<Animator>();
            hitAnim.SetTrigger("UppercutHit_Trig");
            DataManager.Instance.IsPlayer = false;
        }
        if (DataManager.Instance.AttackName == "Low punch" && other.CompareTag("Opponent") && DataManager.Instance.IsAttacking)
        {
            damage = 1;
            DataManager.Instance.IsAttacking = false;
            DataManager.Instance.AttackName = "";
            Animator hitAnim = other.GetComponent<Animator>();
            hitAnim.SetTrigger("LowPunchHit_Trig");
            DataManager.Instance.IsPlayer = false;
        }
        if (DataManager.Instance.AttackName == "Low kick" && other.CompareTag("Opponent") && DataManager.Instance.IsAttacking)
        {
            damage = 1;
            DataManager.Instance.IsAttacking = false;
            DataManager.Instance.AttackName = "";
            Animator hitAnim = other.GetComponent<Animator>();
            hitAnim.SetTrigger("LowKickHit_Trig");
            DataManager.Instance.IsPlayer = false;
        }
        DataManager.Instance.Damage = damage;
    }
}
