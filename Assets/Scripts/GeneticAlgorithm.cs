using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneticAlgorithm : MonoBehaviour
{
    float mutationRate;
    int totalPopulation = 100; // 100 is just a guess
    public DNA[] population { get; private set; }
    List<DNA> matingPool;
    //int target;

    public GeneticAlgorithm()
    {
        //target = DataManager.Instance.OpponentsHP - DataManager.Instance.PlayersHP;
        mutationRate = 0.05f;
        population = new DNA[totalPopulation];
        for (int i = 0; i < population.Length; i++)
        {
            population[i] = new DNA();
        }
    }

    public void CreateFitness(int target)
    {
        for (int i = 0; i < population.Length; i++)
        {
            if (target <= 0)
                population[i].CalculateFitness(1);
            else
                population[i].CalculateFitness(target);
        }
    }
    public void InitMatingPool()
    {
        matingPool = new List<DNA>();

        for (int i = 0; i < population.Length; i++)
        {
            int n = (int)population[i].GetFitness() * 100;
            Debug.Log(n);
            for (int j = 0; j < n; j++)
            {
                matingPool.Add(population[i]);
            }
        }
    }
    public void Reproduction()
    {
        for (int i = 0; i < population.Length; i++)
        {
            int a = Random.Range(0,matingPool.Count);
            int b = Random.Range(0,matingPool.Count);
            DNA partnerA = matingPool[a];
            DNA partnerB = matingPool[b];
            DNA child = partnerA.Crossover(partnerB);
            child.Mutate(mutationRate);
            population[i] = child;
        }
    }
}
