using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Barracuda;

public class FightAgent : Agent
{
    AI ai;
    AI rivalAI;
    GameObject rival;
    int doOrCancelBlock;
    AnimationCallback animCallback;
    //public int hittingBetweenBlocks; // reducing the block spamming
    public int distanceCounter; // this counter is for not wasting too much time
    Actions actions;
    Animator anim;
    int crouchAttacks;
    bool canCrouchAttack;
    bool actionNum10;
    [SerializeField] NNModel easy;
    [SerializeField] NNModel medium;
    [SerializeField] NNModel hard;
    //Rigidbody rb;

    public override void Initialize()
    {
        if(SceneManager.GetActiveScene().name != "Training")
        {
            if (DataManager.Instance.AgentName == "Easy")
            {
                SetModel("FightToSurvive", easy);
            }
            if (DataManager.Instance.AgentName == "Medium")
            {
                SetModel("FightToSurvive", medium);
            }
            if (DataManager.Instance.AgentName == "Hard")
            {
                SetModel("FightToSurvive", hard);
            }
        }

        ai = gameObject.GetComponent<AI>();
        anim = gameObject.GetComponent<Animator>();
        animCallback = gameObject.GetComponent<AnimationCallback>();
        if (this.tag == "Player")
        {
            rival = GameObject.FindGameObjectWithTag("Opponent");
        }
        else
        {
            rival = GameObject.FindGameObjectWithTag("Player");
        }
        if (rival != null)
        {
            rivalAI = rival.GetComponent<AI>();
        }
        //hittingBetweenBlocks = 0;
        distanceCounter = 0;
        crouchAttacks = 0;
        canCrouchAttack = false;
        actions = gameObject.GetComponent<Actions>();
        actionNum10 = false;
        //rb = gameObject.GetComponent<Rigidbody>();
    }

    public override void OnEpisodeBegin()
    {
        //float x = Random.Range(-4.35f, 2.41f);
        //if(this.tag=="Player")
        //{
        //    this.transform.position = new Vector3(-2.68f, this.transform.position.y, this.transform.position.z);
        //}
        //else
        //{
        //    transform.position = new Vector3(3.29f, transform.position.y, transform.position.z);
        //}
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        ai.HP = 20;
        if (SceneManager.GetActiveScene().name == "Training")
        {
            rivalAI.HP = 20;
        }
        //ai.SP = 0;
        //rivalAI.SP = 0;
        //hittingBetweenBlocks = 0;
        ai.isBlocking = false;
        if (ai.actionNum == 9 && animCallback.animationEnded) { ai.actionNum = 10; }
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        if (gameObject != null && rival != null)
        {
            sensor.AddObservation(transform.position); //try putting the isAttacking as an observation too
            sensor.AddObservation(rival.transform.position);
            sensor.AddObservation(ai.HP);
            sensor.AddObservation(rivalAI.HP);
            sensor.AddObservation(ai.isAttacking);
            sensor.AddObservation(rivalAI.isAttacking);
            sensor.AddObservation(animCallback.blockCounter);
            sensor.AddObservation(animCallback.crouchCounter);
            sensor.AddObservation(ai.isBlocking);
            sensor.AddObservation(rivalAI.isBlocking);
            sensor.AddObservation(ai.isJumping);
            sensor.AddObservation(actions.onTheGround);
            sensor.AddObservation(ai.isCrouching);
            sensor.AddObservation(rivalAI.isCrouching);
            sensor.AddObservation(rivalAI.actionNum);
            sensor.AddObservation(ai.SP);
            sensor.AddObservation(ai.specialAttack);
            sensor.AddObservation(rivalAI.specialAttack);
            //sensor.AddObservation(hittingBetweenBlocks);
            sensor.AddObservation(ai.permissionToBlock);
            sensor.AddObservation(ai.beingHit);
            sensor.AddObservation(rivalAI.beingHit);
        }
    }

    // take that action vector and convert each action to "fighting action"
    public override void OnActionReceived(float[] vectorAction)
    {
        if (!ai.startFight)
        {
            return;
        }

        float distance = Vector3.Distance(transform.position, rival.transform.position);

        if (SceneManager.GetActiveScene().name != "Training" && rivalAI.HP == 0)
        {
            ai.startFight = false;
            ai.actionNum = 0;
            anim.SetTrigger("Win_Trig");
            return;
        }
        if (SceneManager.GetActiveScene().name != "Training" && ai.isAttacking && ai.HP == 0)
        {
            ai.startFight = false;
            ai.actionNum = 0;
            anim.SetTrigger("Dead_Trig");
            return;
        }

        if (animCallback.blockMode) // when blocking animation begins, the agent is locked on blockmode. when the animation ends, blockmode is off
        {
            ai.isAttacking = false;
            animCallback.crouchMode = false;
            //if(hittingBetweenBlocks < 150)
            //{
            //    ai.isAttacking = false;
            //    ai.isBlocking = false;
            //    hittingBetweenBlocks = 0;
            //    animCallback.blockCounter = 0;
            //    animCallback.blockMode = false;
            //    ai.actionNum = 0;
            //    anim.Rebind();
            //    anim.Update(0f);
            //    return;
            //}
            if (animCallback.animationEnded)
            {
                doOrCancelBlock = Mathf.RoundToInt(vectorAction[2]); // continue blocking or cancel the block
                if (doOrCancelBlock == 0) { ai.actionNum = 9; }
                if (doOrCancelBlock == 1)
                {
                    if (!actionNum10)
                    {
                        ai.actionNum = 10;
                        actionNum10 = true;
                    }

                }
                animCallback.animationEnded = false;
            }
            if (ai.actionNum == 9)
            {
                ai.isAttacking = false;
                ai.isBlocking = true;
                ai.isJumping = 0;
                ai.isCrouching = 0;
                actionNum10 = false;
            }
            if (ai.actionNum == 10)
            {
                ai.permissionToBlock = false;
                ai.isAttacking = false;
                ai.isBlocking = false;
                //hittingBetweenBlocks = 0;
                animCallback.blockCounter = 0;
                animCallback.blockMode = false;
                ai.actionNum = 0;
                anim.Rebind();
                anim.Update(0f);
            }
            //if (rivalAI.isAttacking && ai.isBlocking)
            //{
            //    AddReward(0.1f);
            //}
            //if (animCallback.blockCounter >= 5)
            //{
            //    AddReward(-0.4f);
            //    animCallback.blockCounter = 0;
            //    ai.actionNum = 10;
            //    EndEpisode();
            //}
            //if (ai.actionNum != 9 && animCallback.blockCounter >= 3 && animCallback.blockCounter < 5)
            //{
            //    AddReward(0.1f);
            //}
            //if (ai.isBlocking && hittingBetweenBlocks < 5)
            //{
            //    AddReward(-0.5f);
            //    EndEpisode();
            //}
            //if (rivalAI.isBlocking && ai.isBlocking)
            //{
            //    AddReward(-0.3f);
            //}
            //return;
        }
        else if (animCallback.crouchMode)
        {
            ai.isAttacking = false;
            animCallback.blockMode = false;
            if (animCallback.animationEnded)
            {
                ai.lowAttacks = Mathf.RoundToInt(vectorAction[6]); // continue to crouch, stand up, low punch, low kick, uppercut
                if (ai.lowAttacks == 0) { ai.actionNum = 15; }
                if (ai.lowAttacks == 1)
                {
                    ai.actionNum = 16;
                    if (animCallback.crouchCounter >= 7 && animCallback.crouchCounter <= 10) // reward for standing up in the right timing
                    {
                        AddReward(0.2f);
                    }
                    animCallback.crouchCounter = 0;
                    ai.lowAttacks = -1;
                    //return;
                }
                if (ai.lowAttacks == 2) { ai.actionNum = 17; }
                if (ai.lowAttacks == 3) { ai.actionNum = 18; }
                if (ai.lowAttacks == 4) { ai.actionNum = 19; }
                animCallback.animationEnded = false;
            }
            //if (distance > 1.7f && ai.isCrouching == 1) // punishment for crouching while in a long distance cause it's useless
            //{
            //    AddReward(-0.3f);
            //}
            //if (distance <= 1.7f && ai.isCrouching == 1 && (rivalAI.actionNum == 3 || rivalAI.actionNum == 4 || rivalAI.actionNum == 7)) // Reward for avoiding high attacks
            //{
            //    AddReward(0.1f);
            //}
            //if (ai.isCrouching == 1 && (ai.actionNum == 1 || ai.actionNum == 2 || ai.actionNum == 11 || ai.actionNum == 12)) // punishment for trying to walk or jump while crouching
            //{
            //    AddReward(-0.5f);
            //}
            //if (ai.isCrouching == 1 && (ai.actionNum == 3 || ai.actionNum == 4 || ai.actionNum == 7)) // punishment for trying to use the wrong attacks while crouching
            //{
            //    AddReward(-0.1f);
            //}
            //if (ai.isCrouching == 1 && rivalAI.isCrouching == 1) // idle crouching while the enemy is also idle crouching
            //{
            //    AddReward(-0.5f);
            //}
            //if (animCallback.crouchCounter > 10) // punishment for long crouching
            //{
            //    AddReward(-0.5f);
            //}
            //if (animCallback.crouchCounter > 10 && ai.actionNum == 15) // punishment for long crouching
            //{
            //    AddReward(-0.5f);
            //    ai.actionNum = 16;
            //    animCallback.crouchCounter = 0;
            //    ai.lowAttacks = -1;
            //    return;
            //}
            //return;
        }
        else
        {
            animCallback.crouchMode = false;
            animCallback.blockMode = false;
            if (animCallback.animationEnded)
            {
                if (distance <= 1.7f)
                {
                    if (!ai.isBlocking)
                    {
                        ai.actionNum = Mathf.RoundToInt(vectorAction[0]); // punches, kicks and all those stuff and the decision to block
                        ai.isJumping = Mathf.RoundToInt(vectorAction[3]); // jump or not
                        ai.isCrouching = Mathf.RoundToInt(vectorAction[4]); // crouch
                        ai.specialAttack = Mathf.RoundToInt(vectorAction[5]);
                        if (ai.isCrouching == 1 && ai.actionNum == 0)
                        {
                            ai.isJumping = 0;
                            ai.specialAttack = 0;
                            ai.actionNum = 15;
                        }
                        if (ai.isCrouching == 1 && ai.actionNum != 0)
                        {
                            ai.isCrouching = 0;
                            animCallback.crouchMode = false;
                        }
                        if ((ai.actionNum == 0) && ai.isJumping == 1) // jump in place
                        {
                            ai.actionNum = 11;
                        }
                        if (ai.actionNum == 2 && ai.isJumping == 1) // jump forward
                        {
                            ai.actionNum = 12;
                        }
                        if (ai.isJumping == 1 && ai.actionNum == 5) // air punch
                        {
                            ai.actionNum = 13;
                        }
                        if (ai.isJumping == 1 && ai.actionNum == 6) // air kick
                        {
                            ai.actionNum = 14;
                        }
                        if (ai.specialAttack == 1 && ai.actionNum == 0 && ai.isCrouching == 0 && ai.SP == 5)
                        {
                            ai.actionNum = 20;
                        }
                        if (ai.actionNum == 9)
                        {
                            if (ai.permissionToBlock && ai.isCrouching == 0)
                            {
                                ai.isBlocking = true;
                            }
                            else
                            {
                                ai.actionNum = Mathf.RoundToInt(vectorAction[7]); // like vectorAction[0] but without blocking
                            }
                        }
                        //if (ai.permissionToBlock && ai.actionNum == 9 && ai.isCrouching == 0)
                        //{
                        //    ai.isBlocking = true;
                        //}
                        //else
                        //{
                        //    return;
                        //}
                        //    if (hittingBetweenBlocks == 150 && ai.actionNum == 9 && ai.isCrouching == 0)
                        //    {
                        //        ai.isBlocking = true;
                        //    }

                    }
                    else
                    {
                        if (ai.permissionToBlock)
                            animCallback.blockMode = true;
                        else
                        {
                            ai.actionNum = Mathf.RoundToInt(vectorAction[7]); // like vectorAction[0] but without blocking
                        }
                    }
                    //else if (hittingBetweenBlocks == 5)
                    //{
                    //    doOrCancelBlock = Mathf.RoundToInt(vectorAction[2]); // continue blocking or cancel the block
                    //    if (doOrCancelBlock == 0) { ai.actionNum = 9; }
                    //    if (doOrCancelBlock == 1) { ai.actionNum = 10; }
                    //    ai.isJumping = 0;
                    //    ai.isCrouching = 0;
                    //}
                    //else
                    //{
                    //    ai.isBlocking = false;
                    //}
                }
                else
                {
                    if (!ai.isBlocking)
                    {
                        ai.actionNum = Mathf.RoundToInt(vectorAction[1]); // idle, walking forwards/backwards
                        ai.isJumping = Mathf.RoundToInt(vectorAction[3]); // jump or not
                        ai.isCrouching = 0;
                        //ai.isCrouching = Mathf.RoundToInt(vectorAction[4]); // crouch or not
                        ai.specialAttack = Mathf.RoundToInt(vectorAction[5]);
                        //if (ai.isCrouching == 1 && ai.actionNum == 0)
                        //{
                        //    ai.isJumping = 0;
                        //    ai.specialAttack = 0;
                        //    ai.actionNum = 15;
                        //}
                        //if (ai.isCrouching == 1 && ai.actionNum != 0)
                        //{
                        //    ai.isCrouching = 0;
                        //    animCallback.crouchMode = false;
                        //}
                        if ((ai.actionNum == 0) && ai.isJumping == 1 && ai.isCrouching == 0) // jump in place
                        {
                            ai.actionNum = 11;
                        }
                        if (ai.actionNum == 2 && ai.isJumping == 1 && ai.isCrouching == 0) // jump forward
                        {
                            ai.actionNum = 12;
                        }
                        if (ai.specialAttack == 1 && ai.actionNum == 0 && ai.isCrouching == 0 && ai.SP == 5)
                        {
                            ai.actionNum = 20;
                        }

                    }
                    else
                    {
                        if (ai.permissionToBlock)
                            animCallback.blockMode = true;
                        else
                        {
                            ai.actionNum = Mathf.RoundToInt(vectorAction[1]); // like vectorAction[0] but without blocking
                        }
                    }
                    //else
                    //{
                    //    doOrCancelBlock = Mathf.RoundToInt(vectorAction[2]); // blocking
                    //    if (doOrCancelBlock == 0) { ai.actionNum = 9; }
                    //    if (doOrCancelBlock == 1) { ai.actionNum = 10; }
                    //    ai.isJumping = 0;
                    //    ai.isCrouching = 0;
                    //}
                }

                animCallback.animationEnded = false;
            }
        }



        // I put those if sections in here and not in the AI script just to syncronize the time betwwen the action num and is attacking
        if (ai.actionNum >= 0 && ai.actionNum <= 2) ai.isAttacking = false;
        //if (!animCallback.blockMode && (ai.actionNum >= 3 && ai.actionNum <= 8) || (ai.actionNum >= 13 && ai.actionNum <= 14) || (ai.actionNum >= 17 && ai.actionNum <= 19) || ai.actionNum == 20)
        //{
        //    //ai.isAttacking = true;
        //    hittingBetweenBlocks++;
        //    if (hittingBetweenBlocks > 150) { hittingBetweenBlocks = 150; } // if the agent will try to attack before blocking at the beginning of the battle
        //}
        if (ai.actionNum == 9)
        {
            //rb.constraints = RigidbodyConstraints.FreezePositionX;
            ai.isAttacking = false;
            ai.isBlocking = true;
            actionNum10 = false;
        }
        if (ai.actionNum == 10)
        {
            //rb.constraints = RigidbodyConstraints.None;
            //rb.constraints = RigidbodyConstraints.FreezePositionZ;
            //rb.constraints = RigidbodyConstraints.FreezeRotation;
            ai.isAttacking = false;
            ai.isBlocking = false;
            //hittingBetweenBlocks = 0;
            animCallback.blockCounter = 0;
            actionNum10 = true;
            ai.actionNum = 0;
            anim.Rebind();
            anim.Update(0f);
        }


        if (rivalAI.HP == 0) // winning the battle
        {
            AddReward(0.3f);
            if (SceneManager.GetActiveScene().name == "Training")
            {
                if (gameObject.tag == "Opponent")
                {
                    transform.position = new Vector3(3.29f, transform.position.y, transform.position.z);
                    rival.transform.position = new Vector3(-2.68f, this.transform.position.y, this.transform.position.z);
                }
                if (gameObject.tag == "Player")
                {
                    rival.transform.position = new Vector3(3.29f, transform.position.y, transform.position.z);
                    transform.position = new Vector3(-2.68f, this.transform.position.y, this.transform.position.z);
                }
            }
            EndEpisode();
        }
        if (ai.HP == 0) // losing the battle
        {
            AddReward(-0.3f);
            if (SceneManager.GetActiveScene().name == "Training")
            {
                if (gameObject.tag == "Opponent")
                {
                    transform.position = new Vector3(3.29f, transform.position.y, transform.position.z);
                    rival.transform.position = new Vector3(-2.68f, this.transform.position.y, this.transform.position.z);
                }
                if (gameObject.tag == "Player")
                {
                    rival.transform.position = new Vector3(3.29f, transform.position.y, transform.position.z);
                    transform.position = new Vector3(-2.68f, this.transform.position.y, this.transform.position.z);
                }
            }
            EndEpisode();
        }
        if (rivalAI.beingHit) // hit the rival
        {
            AddReward(0.2f);
            //rivalAI.beingHit = false;
        }
        if (ai.beingHit) // being hit yourself
        {
            AddReward(-0.2f);
            ai.beingHit = false;
        }
        if (ai.actionNum == 9 && animCallback.crouchCounter > 0) // fucking bug
        {
            AddReward(-0.7f);
            anim.Rebind();
            anim.Update(0f);
            EndEpisode();

        }
        if (rivalAI.isAttacking && ai.isBlocking)
        {
            AddReward(0.1f);
        }
        if (animCallback.blockCounter >= 5)
        {
            AddReward(-0.4f);
            animCallback.blockCounter = 0;
            ai.actionNum = 10;
            EndEpisode();
        }
        if (ai.actionNum != 9 && animCallback.blockCounter >= 3 && animCallback.blockCounter < 5)
        {
            AddReward(0.1f);
        }
        //if (ai.isBlocking && hittingBetweenBlocks < 150)
        //{
        //    AddReward(-0.5f);
        //    EndEpisode();
        //}
        if (rivalAI.isBlocking && ai.isBlocking)
        {
            AddReward(-0.3f);
        }
        if (ai.isBlocking && !ai.permissionToBlock)
        {
            AddReward(-0.5f);
        }
        if (animCallback.getIdleCounter() > 10) // punishment for wasting too much time
        {
            AddReward(-0.1f);
        }
        if (distance > 1.7f)
        {
            distanceCounter++;
        }
        else
        {
            distanceCounter = 0;
        }
        if (distanceCounter >= 20) // to make them go at each other faster
        {
            AddReward(-0.2f);
        }
        if (distance > 1.7f && ai.isAttacking) // punishment for attacking in a long distance
        {
            AddReward(-0.3f);
        }
        if (distance > 1.7f && ai.isJumping == 1 && (ai.actionNum == 2 || ai.actionNum == 12))
        {
            AddReward(0.2f);
        }
        if (distance > 1.7f && ai.isJumping == 1 && (ai.actionNum != 2 || ai.actionNum != 12)) // punishment jumping in place if too far
        {
            AddReward(-0.4f);
        }
        if (distance <= 1.7f && ai.isJumping == 1 && ai.actionNum == 2) // punishment for jumping forward when close to the enemy
        {
            AddReward(-0.3f);
        }
        if (ai.isJumping == 1 && ai.actionNum == 1) // punishment for jumping backwards
        {
            AddReward(-0.5f);
        }
        if (distance <= 1.7f && ai.isJumping == 1 && (ai.actionNum != 0 || ai.actionNum != 5 || ai.actionNum != 6 || ai.actionNum != 13 || ai.actionNum != 14)) // punishment for interrupting attacks with jumping except air attacks
        {
            AddReward(-0.5f);
        }
        if (!actions.onTheGround && ai.isJumping == 1) // punishment for trying to jump while in the air
        {
            AddReward(-0.5f);
        }
        if (gameObject.tag == "Opponent")
        {
            if (rival.transform.position.x > transform.position.x)
            {
                AddReward(-0.1f);
                transform.position = new Vector3(3.29f, transform.position.y, transform.position.z);
                rival.transform.position = new Vector3(-2.68f, this.transform.position.y, this.transform.position.z);
                EndEpisode();
            }
        }
        if (gameObject.tag == "Player")
        {
            if (rival.transform.position.x < transform.position.x)
            {
                AddReward(-0.1f);
                rival.transform.position = new Vector3(3.29f, transform.position.y, transform.position.z);
                transform.position = new Vector3(-2.68f, this.transform.position.y, this.transform.position.z);
                EndEpisode();
            }
        }
        if (distance > 1.7f && ai.isCrouching == 1) // punishment for crouching while in a long distance cause it's useless
        {
            AddReward(-0.3f);
        }
        if (distance <= 1.7f && ai.isCrouching == 1 && (rivalAI.actionNum == 3 || rivalAI.actionNum == 4 || rivalAI.actionNum == 7)) // Reward for avoiding high attacks
        {
            AddReward(0.1f);
        }
        if (ai.isCrouching == 1 && (ai.actionNum == 1 || ai.actionNum == 2 || ai.actionNum == 11 || ai.actionNum == 12)) // punishment for trying to walk or jump while crouching
        {
            AddReward(-0.5f);
        }
        if (ai.isCrouching == 1 && (ai.actionNum == 3 || ai.actionNum == 4 || ai.actionNum == 7)) // punishment for trying to use the wrong attacks while crouching
        {
            AddReward(-0.1f);
        }
        if (ai.actionNum == 15 && rivalAI.actionNum == 15) // idle crouching while the enemy is also idle crouching
        {
            AddReward(-0.5f);
        }
        if (animCallback.crouchCounter >= 10) // punishment for long crouching
        {
            AddReward(-0.5f);
        }
        if (animCallback.crouchCounter >= 7 && animCallback.crouchCounter <= 10) // reward for standing up in the right timing
        {
            AddReward(0.2f);
        }
        if (ai.specialAttack == 1 && ai.SP < 5) // punishment for using special attack while sp is not max
        {
            AddReward(-0.5f);
        }
        if (ai.specialAttack == 1 && ai.SP == 5) // reward for using right the special attack
        {
            AddReward(0.1f);
        }
        if (ai.specialAttack == 1 && ai.SP == 5 && rivalAI.beingHit) // reward for not missing with the special attack
        {
            AddReward(0.3f);
        }
        if (ai.specialAttack == 1)
        {
            ai.SP = 0;
        }
        if (!animCallback.crouchMode && ai.actionNum >= 17 && ai.actionNum <= 19)
        {
            AddReward(-0.3f);
        }
    }

    public override void Heuristic(float[] actionsOut)
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                actionsOut[0] = 2f;
                actionsOut[1] = 2f;
                actionsOut[3] = 1f;
            }
            else
            {
                actionsOut[0] = 2f;
                actionsOut[1] = 2f;
            }
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
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            actionsOut[3] = 1f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            actionsOut[4] = 1f;
            if (Input.GetKey(KeyCode.X))
            {
                actionsOut[6] = 3f;
            }
            else
            {
                actionsOut[6] = 0f;
            }
        }
        else
        {
            actionsOut[0] = 0f;
            actionsOut[1] = 0f;
            actionsOut[3] = 0f;
            actionsOut[4] = 0f;
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
