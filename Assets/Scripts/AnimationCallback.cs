using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AnimationCallback : MonoBehaviour
{
    public bool animationEnded = true; // true = permission to go to the next animation
    public int blockCounter;
    public int crouchCounter;
    public bool blockMode;
    public bool crouchMode;
    [SerializeField] private int idleCounter = 0;

    private void Awake()
    {
        animationEnded = true;
        idleCounter = 0;
        blockCounter = 0;
        crouchCounter = 0;
        blockMode = false;
        crouchMode = false;
    }

    //void animBeganCallback()
    //{
    //    animationEnded = false;
    //    idleCounter = 0;
    //    //Debug.Log("Animation began");
    //}
    void AnimBeginCallback()
    {
        animationEnded = false;
    }
    void animEndCallback()
    {
        animationEnded=true;
        idleCounter = 0;
        if (SceneManager.GetActiveScene().name != "Training")
        {
            if (gameObject.tag == "Player")
            {
                DataManager.Instance.IsP1Attacking = false;
                DataManager.Instance.P1AttackName = "";
            }
            if (gameObject.tag == "Opponent")
            {
                DataManager.Instance.IsP2Attacking = false;
                DataManager.Instance.P2AttackName = "";
            }
        }
        //Debug.Log("Animation ended");
    }
    void IncreaseIdleCounter()
    {
        animationEnded = true;
        idleCounter++;
    }
    void IncreaseBlockCounter()
    {
        animationEnded = true;
        blockCounter++;
    }
    void StartBlocking()
    {
        blockMode = true;
    }
    void EndBlocking()
    {
        animationEnded = true;
        blockMode = false;
    }
    void IncreaseCrouchCounter()
    {
        animationEnded = true;
        crouchCounter++;
    }
    void StartCrouching()
    {
        crouchMode = true;
    }
    void EndCrouching()
    {
        animationEnded = true;
        crouchMode = false;
    }
    public int getIdleCounter()
    {
        return idleCounter;
    }
    public void setIdleCounter(int counter)
    { 
        idleCounter = counter;
    }
}
