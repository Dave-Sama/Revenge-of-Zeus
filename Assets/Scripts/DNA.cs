using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA : MonoBehaviour
{
    public int[] genes { get; private set; }
    float fitness;

    public DNA()
    {
        genes = new int[100]; // the array size is the number of actions that is required for the agent to win the match, 500 is just a guess
        for (int i = 0; i < genes.Length; i++)
        {
            genes[i] = Random.Range(0, 9); // cause there are 19 actions (temporarily reduced it to 3 actions)
        }
    }

   
    public void CalculateFitness(int target)
    {
        // changed my my after I wrote this, if it's unnecessary, delete it

        //int score = 0;
        //if (DataManager.Instance.PlayerBeingHit)
        //{
        //    score++;
        //}
        //if (DataManager.Instance.OpponentBeingHit)
        //{
        //    score--;
        //}

        fitness = Mathf.Round(1f / target);
    }
    public float GetFitness() { return fitness; }

    public DNA Crossover(DNA partner)
    {
        DNA child = new DNA();
        int midPoint=Random.Range(0, genes.Length);
        for(int i = 0; i < genes.Length; i++)
        {
            if (i > midPoint)
            {
                child.genes[i] = genes[i];
            }
            else
            {
                child.genes[i] = partner.genes[i];
            }
        }
        return child;
    }

    public void Mutate(float mutationRate)
    {
        float random = Random.Range(0f, 1f);
        for(int i = 0; i < genes.Length; i++)
        {
            if (random < mutationRate)
            {
                genes[i]=Random.Range(0, 20);
            }
        }
    }
}
