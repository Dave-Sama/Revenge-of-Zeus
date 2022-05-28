using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCallback : MonoBehaviour
{
    public bool animationEnded = true; // true = permission to go to the next animation
    public int blockCounter;
    public int crouchCounter;
    [SerializeField] private int idleCounter = 0;

    private void Awake()
    {
        animationEnded = true;
        idleCounter = 0;
        blockCounter = 0;
        crouchCounter = 0;
    }

    //void animBeganCallback()
    //{
    //    animationEnded = false;
    //    idleCounter = 0;
    //    //Debug.Log("Animation began");
    //}
    void animEndCallback()
    {
        animationEnded=true;
        idleCounter = 0;
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
    void IncreaseCrouchCounter()
    {
        animationEnded = true;
        crouchCounter++;
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
