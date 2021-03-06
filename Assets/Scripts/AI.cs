using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class AI : MonoBehaviour
{
    public int actionNum;
    public float HP;
    public float SP;
    Actions actions;
    AnimationCallback animCallback;
    public bool isAttacking;
    public bool beingHit;
    public bool isBlocking;
    public int isJumping;
    public int isCrouching;
    public int specialAttack;
    public bool startFight;
    public int lowAttacks;
    public bool permissionToBlock;
    bool crouch;
    Quaternion rotation;
    public TextMeshProUGUI HPText;
    public TextMeshProUGUI SPText;

    // Start is called before the first frame update
    void Start()
    {
        rotation=gameObject.transform.rotation;
        permissionToBlock=true;

        if (SceneManager.GetActiveScene().name == "Training" || gameObject.tag == "Opponent")
        {
            actionNum = 0;
        }
        else
        {
            if (gameObject.tag == "Player")
            {
                actionNum = DataManager.Instance.PlayerActionNum;
            }
        }

        if (SceneManager.GetActiveScene().name == "Training")
        {
            HP = 20;
        }
        else
        {
            if (gameObject.tag == "Player")
            {
                HP = DataManager.Instance.PlayersHP;
            }
            if (gameObject.tag == "Opponent")
            {
                HP = DataManager.Instance.OpponentsHP;
            }
        }
        if(SceneManager.GetActiveScene().name== "Training")
        {
            SP = 0f;
        }
        else
        {
            if (gameObject.tag == "Player")
            {
                SP = DataManager.Instance.PlayersSP;
            }
            if (gameObject.tag == "Opponent")
            {
                SP = DataManager.Instance.OpponentsSP;
            }
        }
        
        actions=gameObject.AddComponent<Actions>();
        if(SceneManager.GetActiveScene().name == "Training" || gameObject.tag == "Opponent")
        {
            isAttacking = false;
        }
        else
        {
            if (gameObject.tag == "Player")
            {
                isAttacking = DataManager.Instance.IsP1Attacking;
            }
        }
        if (SceneManager.GetActiveScene().name == "Training")
        {
            beingHit = false;
        }
        else
        {
            if (gameObject.tag == "Player")
            {
                beingHit = DataManager.Instance.PlayerBeingHit;
            }
            if(gameObject.tag == "Opponent")
            {
                beingHit = DataManager.Instance.OpponentBeingHit;
            }
        }
        if (SceneManager.GetActiveScene().name == "Training" || gameObject.tag == "Opponent")
        {
            isBlocking = false;
        }
        else
        {
            if (gameObject.tag == "Player")
            {
                isBlocking = DataManager.Instance.P1Block;
            }
        }
        isJumping = 0;
        if (SceneManager.GetActiveScene().name == "Training" || gameObject.tag == "Opponent")
        {
            isCrouching = 0;
        }
        else
        {
            isCrouching = DataManager.Instance.IsPlayerCrouching;
        }
            
        crouch = false;
        if (SceneManager.GetActiveScene().name == "Training" || gameObject.tag == "Opponent")
        {
            specialAttack = 0;
        }
        else
        {
            if (gameObject.tag == "Player")
            {
                specialAttack = DataManager.Instance.PlayerSpecialAttack;
            }
        }

        animCallback =gameObject.GetComponent<AnimationCallback>();
        lowAttacks = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Training")
        {
            gameObject.transform.rotation = rotation;
        }
        if(SceneManager.GetActiveScene().name != "Training" && gameObject.tag == "Player")
        {
            HP = DataManager.Instance.PlayersHP;
            SP = DataManager.Instance.PlayersSP;
            isAttacking = DataManager.Instance.IsP1Attacking;
            isBlocking = DataManager.Instance.P1Block;
            isCrouching = DataManager.Instance.IsPlayerCrouching;
            actionNum = DataManager.Instance.PlayerActionNum;
            specialAttack = DataManager.Instance.PlayerSpecialAttack;
            beingHit = DataManager.Instance.PlayerBeingHit;

        }
        if (SceneManager.GetActiveScene().name != "Training" && gameObject.tag == "Opponent")
        {
            HP = DataManager.Instance.OpponentsHP;
            SP = DataManager.Instance.OpponentsSP;
            beingHit = DataManager.Instance.OpponentBeingHit;

        }
        if (SP >= 5)
        {
            SP = 5;
        }
        if (!permissionToBlock)
        {
            StartCoroutine(BlockCooldown());
        }
        if(SceneManager.GetActiveScene().name == "Training" || (SceneManager.GetActiveScene().name != "Training" && gameObject.tag == "Opponent"))
        {
            //if ((actionNum != 2 && actionNum != 12) && isJumping == 1) // jump in place
            //{
            //    actionNum = 11;
            //}
            //if (actionNum == 2 && isJumping == 1) // jump forward
            //{
            //    actionNum = 12;
            //}
            //if (isJumping == 1 && actionNum == 5) // air punch
            //{
            //    actionNum = 13;
            //}
            //if (isJumping == 1 && actionNum == 6) // air kick
            //{
            //    actionNum = 14;
            //}
            //if ((isCrouching == 1 && actionNum == 0) || lowAttacks == 0) // crouch or continue to crouch
            //{
            //    actionNum = 15;
            //}
            //if (lowAttacks == 1) // stand up
            //{
            //    actionNum = 16;
            //    animCallback.crouchCounter = 0;
            //    lowAttacks = -1;
            //}
            //if (lowAttacks == 2) // low punch
            //{
            //    actionNum = 17;
            //}
            //if (lowAttacks == 3) // low kick
            //{
            //    actionNum = 18;
            //}
            //if (lowAttacks == 4) // uppercut
            //{
            //    actionNum = 19;
            //}
            //if (specialAttack == 1)
            //{
            //    actionNum = 20;
            //}
        }



        if (SceneManager.GetActiveScene().name == "Training")
        {
            actions.IntToAction(actionNum);
        }
        else
        {
            if (gameObject.tag == "Opponent")
            {
                actions.IntToAction(actionNum);
            }
        }

        if (SceneManager.GetActiveScene().name == "Training")
        {
            HPText.text = HP.ToString();
            SPText.text = SP.ToString();
        }
    }
    IEnumerator BlockCooldown()
    {
        permissionToBlock = false;
        yield return new WaitForSeconds(10);
        permissionToBlock = true;
    }
}
