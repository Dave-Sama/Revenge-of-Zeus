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
        if((gameObject.CompareTag("Left arm")||gameObject.CompareTag("Right arm"))&&other.CompareTag("Opponent")&&DataManager.Instance.IsAttacking)
        {
            damage = 1;
            DataManager.Instance.IsAttacking = false;
            Animator hitAnim = other.GetComponent<Animator>();
            hitAnim.SetTrigger("LeftPunchHit_Trigger");
        }
        DataManager.Instance.Damage = damage;
    }
}
