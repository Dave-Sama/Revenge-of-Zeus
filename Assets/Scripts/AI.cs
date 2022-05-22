using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public int actionNum;
    public int HP;
    Actions actions;
    public bool isAttacking;
    public bool beingHit;
    public bool isBlocking;

    // Start is called before the first frame update
    void Start()
    {
        actionNum = 0;
        HP = 10;
        actions=gameObject.AddComponent<Actions>();
        isAttacking = false;
        beingHit = false;
        isBlocking = false;
    }

    // Update is called once per frame
    void Update()
    {   
        actions.IntToAction(actionNum);
    }
}
