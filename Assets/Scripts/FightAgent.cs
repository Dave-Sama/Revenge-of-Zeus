using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine.UI;

public class FightAgent : Agent
{
    AI ai;
    AI rivalAI;
    GameObject rival;
    int doOrCancelBlock;
    AnimationCallback animCallback;
    public int hittingBetweenBlocks; // reducing the block spamming
    //Rigidbody rb;

    public override void Initialize()
    {
        ai=gameObject.GetComponent<AI>();
        animCallback=gameObject.GetComponent<AnimationCallback>();
        if (this.tag == "Player")
        {
            rival = GameObject.FindGameObjectWithTag("Opponent");
        }
        else
        {
            rival = GameObject.FindGameObjectWithTag("Player");
        }
        rivalAI=rival.GetComponent<AI>();
        hittingBetweenBlocks = 0;
        //rb=gameObject.GetComponent<Rigidbody>();
    }

    public override void OnEpisodeBegin()
    {
        //float x = Random.Range(-4.35f, 2.41f);
        if(this.tag=="Player")
        {
            this.transform.position = new Vector3(-2.68f, this.transform.position.y, this.transform.position.z);
        }
        else
        {
            transform.position = new Vector3(3.29f, transform.position.y, transform.position.z);
        }
        ai.HP = 10;
        rivalAI.HP = 10;
        hittingBetweenBlocks = 0;
        ai.isBlocking = false;
        if (ai.actionNum == 9 && animCallback.animationEnded) { ai.actionNum = 10; }
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.position); //try putting the isAttacking as an observation too
        sensor.AddObservation(rival.transform.position);
        sensor.AddObservation(ai.HP);
        sensor.AddObservation(rivalAI.HP);
        sensor.AddObservation(ai.isAttacking);
        sensor.AddObservation(rivalAI.isAttacking);
        sensor.AddObservation(animCallback.blockCounter);
        sensor.AddObservation(ai.isBlocking);
        sensor.AddObservation(rivalAI.isBlocking);
    }

    // take that action vector and convert each action to "fighting action"
    public override void OnActionReceived(float[] vectorAction)
    {
        float distance = Vector3.Distance(transform.position, rival.transform.position);
        Debug.Log(animCallback.animationEnded);
        if (animCallback.animationEnded)
        {
            if (distance <= 1.7f)
            {
                if (!ai.isBlocking)
                {
                    ai.actionNum = Mathf.RoundToInt(vectorAction[0]); // punches, kicks and all those stuff
                }
                else if (hittingBetweenBlocks == 5)
                {
                    doOrCancelBlock = Mathf.RoundToInt(vectorAction[2]); // blocking
                    if (doOrCancelBlock == 0) { ai.actionNum = 9; }
                    if (doOrCancelBlock == 1) { ai.actionNum = 10; }
                }
                else
                {
                    ai.isBlocking = false;
                }
            }
            else
            {
                if (!ai.isBlocking)
                {
                    ai.actionNum = Mathf.RoundToInt(vectorAction[1]); // idle, walking forwards/backwards
                }
                else
                {
                    doOrCancelBlock = Mathf.RoundToInt(vectorAction[2]); // blocking
                    if (doOrCancelBlock == 0) { ai.actionNum = 9; }
                    if (doOrCancelBlock == 1) { ai.actionNum = 10; }
                }
            }

            animCallback.animationEnded = false;
        }



        // I put those if sections in here and not in the AI script just to syncronize the time betwwen the action num and is attacking
        if (ai.actionNum >= 0 && ai.actionNum <= 2) ai.isAttacking = false;
        if (ai.actionNum >= 3 && ai.actionNum <= 8)
        {
            ai.isAttacking = true;
            hittingBetweenBlocks++;
            if (hittingBetweenBlocks > 5) { hittingBetweenBlocks = 5; } // if the agent will try to attack before blocking at the beginning of the battle
        }
        if (ai.actionNum == 9)
        {
            //rb.constraints = RigidbodyConstraints.FreezePositionX;
            ai.isAttacking = false;
            ai.isBlocking = true;
        }
        if (ai.actionNum == 10)
        {
            //rb.constraints = RigidbodyConstraints.None;
            //rb.constraints = RigidbodyConstraints.FreezePositionZ;
            //rb.constraints = RigidbodyConstraints.FreezeRotation;
            ai.isAttacking = false;
            ai.isBlocking = false;
            hittingBetweenBlocks = 0;
            animCallback.blockCounter = 0;
        }


        if (rivalAI.HP == 0) // winning the battle
        {
            AddReward(0.3f);
            EndEpisode();
        }
        if (ai.HP == 0) // losing the battle
        {
            AddReward(-0.3f);
            EndEpisode();
        }
        if (rivalAI.beingHit) // hit the rival
        {
            AddReward(0.2f);
            rivalAI.beingHit=false;
        }
        if (ai.beingHit) // being hit yourself
        {
            AddReward(-0.2f);
            ai.beingHit = false;
        }
        if(rivalAI.isAttacking && ai.isBlocking)
        {
            AddReward(0.2f);
        }
        if (animCallback.blockCounter >= 10)
        {
            AddReward(-0.2f);
            animCallback.blockCounter=0;
            ai.actionNum = 10;
            EndEpisode();
        }
        if (ai.actionNum!=9 && animCallback.blockCounter>=5 && animCallback.blockCounter < 10)
        {
            AddReward(0.1f);
        }
        if (ai.isBlocking && hittingBetweenBlocks < 5)
        {
            AddReward(-0.3f);
            EndEpisode();
        }
        if(rivalAI.isBlocking && ai.isBlocking)
        {
            AddReward(-0.1f);
        }

    }

    public override void Heuristic(float[] actionsOut)
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            actionsOut[0] = 2f;
            actionsOut[1] = 2f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            actionsOut[0] = 1f;
            actionsOut[1] = 1f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            actionsOut[0] = 3f;
            actionsOut[1] = 3f;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log(Vector3.Distance(transform.position, rival.transform.position));
        }
        else
        {
            actionsOut[0] = 0f;
            actionsOut[1] = 0f;
        }

        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            AddReward(-0.1f);
        }
    }
}
