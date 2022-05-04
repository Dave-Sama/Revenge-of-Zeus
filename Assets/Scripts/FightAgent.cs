using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine.UI;

public class FightAgent : Agent
{
    Transform playerTransform;
    Animator agentAnim;
    private int animationState;
    private Slider playersHealthBar;
    private Slider opponentsHealthBar;
    private GameObject rightWall;
    private float time;


    public override void Initialize()
    {
        GameObject playerClone = GameObject.Find(DataManager.Instance.PlayersCharacter + "(Clone)");
        playerTransform = playerClone.transform;
        Debug.Log("playersTransform: " + playerTransform);
        agentAnim = gameObject.GetComponent<Animator>();
        playersHealthBar=GameObject.FindGameObjectWithTag("PlayerHP").GetComponent<Slider>();
        opponentsHealthBar=GameObject.FindGameObjectWithTag("OpponentHP").GetComponent<Slider>();
        rightWall = GameObject.Find("Right Wall");
        animationState = 0;
        time = 0;
    }

    public override void OnEpisodeBegin()
    {
        base.OnEpisodeBegin();
        transform.position = new Vector3(2.75f, 0, 0);
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(playerTransform.position.x); // 1 observation
        sensor.AddObservation(transform.position.x); // 1 observation
        sensor.AddObservation(playersHealthBar.value); // 1 observation
        sensor.AddObservation(opponentsHealthBar.value); // 1 observation
        sensor.AddObservation(DataManager.Instance.IsPlayerCrouching); // 1 observation
        sensor.AddObservation(rightWall.transform.position.x); // 1 observation
        sensor.AddObservation(DataManager.Instance.IsP1Attacking); // 1 observation
        for(int i = 0; i < sensor.GetObservationShape().Length; i++)
        {
            Debug.Log("shape "+i+": "+sensor.GetObservationShape()[i]);
        }

    }

    // take that action vector and convert each action to "fighting action"
    public override void OnActionReceived(float[] vectorAction)
    {
        float distance=Mathf.Abs(vectorAction[0]-vectorAction[1]);
        float playersHP=vectorAction[2];
        float agentsHP=vectorAction[3];
        float isPlayerCrouching=vectorAction[4];
        float rightWallLocation=vectorAction[5];
        float playerAttacking=vectorAction[6];
        float regularHit;
        float jump;
        float crouch;

        //Debug.Log("playerAttacking: " + playerAttacking);

        Debug.Log("distance: "+distance);

        if (!DataManager.Instance.IsP1Attacking && distance <= 0.5f && playersHP > 0f)
        {
            animationState = 0;
            regularHit = Random.Range(0f, 5f);
            switch (regularHit)
            {
                case 0f: animationState = 2;
                    break;
                case 1f: animationState = 3;
                    break;
                case 2f:
                    animationState = 4;
                    break;
                case 3f:
                    animationState=5;
                    break;
                case 4f:
                    animationState = 6;
                    break;
                case 5f:
                    animationState = 7;
                    break;
            }
        }
        if (!DataManager.Instance.IsP1Attacking && time==0)
            animationState = 1;
        else
        {
            animationState = -1;
            if (distance < 1f)
            {
                time += Time.fixedDeltaTime;
                if(time>=20f)
                {
                    AddReward(-1f);
                    time = 0f;
                    EndEpisode();
                }
               
            }
                
        }
        jump = 0f;
        crouch = 0f;
        if (jump == 1)
        {
            agentAnim.SetBool("Jump_Bool", true);
        }
        else
        {
            agentAnim.SetBool("Jump_Bool", false);
        }
        if(crouch == 1)
        {
            agentAnim.SetBool("Crouch_Bool", true);
        }
        else
        {
            agentAnim.SetBool("Crouch_Bool", false);
        }
        //transform.Translate(Vector3.forward * Time.deltaTime * 0.5f);
        //if (Mathf.Abs(transform.position.x - playerTransform.position.x) == 0.5f)
        //{
        //    agentAnim.SetFloat("Speed_Float", 0);
        //}
    }

    public override void Heuristic(float[] actionsOut)
    {
        if(Input.GetKey(KeyCode.Keypad4)) actionsOut[0]=1;
        else if(Input.GetKey(KeyCode.Keypad6)) actionsOut[0]=-1;
        else actionsOut[0]=0;
        if (Input.GetKey(KeyCode.Insert))
        {
            actionsOut[1] = 1;
            Debug.Log("punch");
        }
        else actionsOut[1] = 0;
        if(Input.GetKey(KeyCode.Keypad8)) actionsOut[2] = 1;
        else actionsOut[2] = 0;
        if (Input.GetKey(KeyCode.Keypad2)) actionsOut[3] = 1;
        else actionsOut[3] = 0;
    }

    private void LateUpdate()
    {
        Debug.Log("animationState: "+animationState);
        switch (animationState)
        {
            case -1: agentAnim.SetFloat("Speed_Float", -1);
                break;
            
            case 1: agentAnim.SetFloat("Speed_Float", 1);
                break;
            case 2: agentAnim.SetTrigger("UpPunchLeft_Trig");
                break;
            case 3: agentAnim.SetTrigger("UpPunchRight_Trig");
                break;
            case 4: agentAnim.SetTrigger("MidPunchLeft_Trig");
                break;
            case 5: agentAnim.SetTrigger("MidPunchRight_Trig");
                break;
            case 6: agentAnim.SetTrigger("HighKick_Trig");
                break;
            case 7: agentAnim.SetTrigger("MidKick_Trig");
                break;
            default:
                agentAnim.SetFloat("Speed_Float", 0);
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (other.tag == "Player")
        //{
        //    DataManager.Instance.IsP2Attacking = true;
        //    DataManager.Instance.P2AttackName = "Up punch left";
        //    agentAnim.SetTrigger("UpPunchLeft_Trig");

        //    if (playersHealthBar.value==0)
        //    {
        //        SetReward(1);
        //        EndEpisode();
        //    } 
        //}
        //if (other.tag == "Wall")
        //{
        //    SetReward(-1);
        //    EndEpisode();
        //}
    }
}
