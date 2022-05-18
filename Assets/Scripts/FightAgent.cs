using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using UnityEngine.UI;

public class FightAgent : Agent
{
    AI ai;
    GameObject player;

    public override void Initialize()
    {
        ai=gameObject.GetComponent<AI>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void OnEpisodeBegin()
    {
        float x = Random.Range(-4.35f, 2.41f);
        player.transform.position = new Vector3(x, player.transform.position.y, player.transform.position.z);
        transform.position=new Vector3(3.29f, transform.position.y, transform.position.z);
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(player.transform.position);
        sensor.AddObservation(transform.position);
    }

    // take that action vector and convert each action to "fighting action"
    public override void OnActionReceived(float[] vectorAction)
    {
        ai.actionNum=Mathf.RoundToInt(vectorAction[0]);
    }

    public override void Heuristic(float[] actionsOut)
    {
      
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AddReward(20);
        }
        if (collision.gameObject.tag == "Wall")
        {
            AddReward(-20);
        }
    }
}
