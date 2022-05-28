using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AI : MonoBehaviour
{
    public int actionNum;
    public int HP;
    public float SP;
    Actions actions;
    AnimationCallback animCallback;
    public bool isAttacking;
    public bool beingHit;
    public bool isBlocking;
    public int isJumping;
    public int isCrouching;
    public int specialAttack;
    bool crouch;
    public TextMeshProUGUI HPText;
    public TextMeshProUGUI SPText;

    // Start is called before the first frame update
    void Start()
    {
        actionNum = 0;
        HP = 10;
        SP = 0f;
        actions=gameObject.AddComponent<Actions>();
        isAttacking = false;
        beingHit = false;
        isBlocking = false;
        isJumping = 0;
        isCrouching = 0;
        crouch = false;
        specialAttack = 0;
        animCallback=gameObject.GetComponent<AnimationCallback>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((actionNum != 2 && actionNum!=12) && isJumping == 1) // jump in place
        {
            actionNum = 11;
        }
        if (actionNum == 2 && isJumping == 1) // jump forward
        {
            actionNum = 12;
        }
        if(isJumping == 1 && actionNum == 5) // air punch
        {
            actionNum=13;
        }
        if(isJumping ==1 && actionNum == 6) // air kick
        {
            actionNum = 14;
        }
        if (isCrouching == 1 && actionNum == 0)
        {
            actionNum = 15;
            crouch = true;
        }
        if ((isCrouching == 0 && crouch))
        {
            actionNum = 16;
            crouch = false;
            animCallback.crouchCounter = 0;
        }
        if (crouch && actionNum == 5) // low punch
        {
            actionNum = 17;
        }
        if (crouch && actionNum == 6) // low kick
        {
            actionNum = 18;
        }
        if (crouch && actionNum == 8) // uppercut
        {
            actionNum = 19;
        }
        if (specialAttack == 1)
        {
            actionNum = 20;
        }
        actions.IntToAction(actionNum);

        HPText.text = HP.ToString();
        SPText.text = SP.ToString();
    }
}
