using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GAObj : MonoBehaviour
{
    GeneticAlgorithm ga;
    List<int[]> testedDNA;
    List<int> fitnessForDNA;
    int dnaIndexStart;
    int[] currentGenesForActions;
    int geneIndex;
    int target;
    public int PlayersHP;
    public int OpponentsHP;
    Actions actions;
    bool permissionToChangeCurrentGenes;
    public int actionCounter;
    AnimationCallback animCallback;
    string str = "";
    int score;
    public bool hitDetected;
    int genCount;
    GameObject player;

    public TextMeshProUGUI genNumText;
    public TextMeshProUGUI genesArrayNumText;
    public TextMeshProUGUI opponentHPText;
    public TextMeshProUGUI playerHPText;
    // Start is called before the first frame update
    void Start()
    {
        ga = new GeneticAlgorithm();
        testedDNA = new List<int[]>();
        fitnessForDNA=new List<int>();
        dnaIndexStart = 0;
        currentGenesForActions = new int[100];
        geneIndex = 0;
        PlayersHP = 10;
        OpponentsHP = 10;
        target = OpponentsHP - PlayersHP;
        permissionToChangeCurrentGenes = true;
        actions=gameObject.GetComponent<Actions>();
        actionCounter = 0;
        animCallback = gameObject.GetComponent<AnimationCallback>();
        score = 0;
        hitDetected = false;
        genCount = 1;
        player = GameObject.FindGameObjectWithTag("Player");
        genNumText.text = "Generation " + genCount;
    }

    // Update is called once per frame
    void Update()
    {
        genesArrayNumText.text = "Genes No." + dnaIndexStart;
        opponentHPText.text = "Opponent HP: "+OpponentsHP;
        playerHPText.text = "Player HP: "+PlayersHP;
        if(permissionToChangeCurrentGenes)
        {
            ExtractGenesForAction();
        }

        StartFighting();

        if (testedDNA.Count == ga.population.Length) // -- do something with that shit
        {
            Debug.Log("Did it!");
            EndAGeneration();
        }
    }

    /// <summary>
    /// Takes everytime the genes sequence from a DNA and copies it to currenGenesForActions array
    /// </summary>
    void ExtractGenesForAction()
    {
        permissionToChangeCurrentGenes=false;
        while (dnaIndexStart < ga.population.Length) // looping through dna array
        {
            for (int j = 0; j < ga.population[dnaIndexStart].genes.Length; j++) // for each dna, looping through its genes array (order of the actionn set)
            {
                currentGenesForActions[j]=ga.population[dnaIndexStart].genes[j];
            }
            dnaIndexStart++;
            break;
        }
        for(int j = 0; j < currentGenesForActions.Length; j++)
        {
            str = str + currentGenesForActions[j] + ", ";
        }
        //Debug.Log(str);
    }

    /// <summary>
    /// Going through the current genes array (with the help of the update methode) and converting each gene (int) into an action (animation)
    /// </summary>
    void StartFighting()
    {
        while (geneIndex < currentGenesForActions.Length)
        {
            if (animCallback.animationEnded)
            {
                //Debug.Log(currentGenesForActions[geneIndex]);
                //Debug.Log(animCallback.animationEnded);
                ConvertGeneToAction(currentGenesForActions[geneIndex]);
                actionCounter++;
                geneIndex++;
                animCallback.animationEnded = false;
            }
            //else
            //{
            //    Debug.Log(currentGenesForActions[geneIndex]);
            //    Debug.Log(animCallback.animationEnded);
            //}
            break;
        }

        // when all the current actions are done or the fighter is stuck on idle, add the current actions and their score to lists and reset the whole thing for the next actions array
        if (geneIndex == currentGenesForActions.Length || animCallback.getIdleCounter()==3) 
        {
            Debug.Log("current genes for action: "+currentGenesForActions.Length);
            Debug.Log("gene index: " + geneIndex);
            testedDNA.Add(currentGenesForActions);
            fitnessForDNA.Add(score*(OpponentsHP-PlayersHP));
            permissionToChangeCurrentGenes = true;
            actionCounter = 0;
            score = 0;
            PlayersHP = 10;
            OpponentsHP = 10;
            str = "";
            float x = Random.Range(-4.35f, 2.41f);
            player.transform.position = new Vector3(x, player.transform.position.y, player.transform.position.z);
            //if (gameObject.tag == "Player") { gameObject.transform.position=new Vector3(-2.68f,gameObject.transform.position.y,gameObject.transform.position.z); }
            if (gameObject.tag == "Opponent") { gameObject.transform.position = new Vector3(3.290061f, gameObject.transform.position.y, gameObject.transform.position.z); }
        }
        if(animCallback.getIdleCounter() == 5)
        {
            animCallback.setIdleCounter(0);
            geneIndex = 0;
            score -= 20; // punish the fighter if he's stuck on idle too much time
        }
        if (hitDetected)
        {
            score += 10;
            hitDetected = false;
        }
    }

    /// <summary>
    /// Calculates the fitness for every single DNA in the population of the current gen, creates a mating pool and
    /// then creates the new gen based on the fitnesses of the old gen
    /// </summary>
    void EndAGeneration()
    {
        for(int i = 0; i < fitnessForDNA.Count; i++)
        {
            ga.CreateFitness(fitnessForDNA[i]);
        }
        ga.InitMatingPool();
        ga.Reproduction();
        dnaIndexStart = 0;
        geneIndex = 0;
        genCount++;
        testedDNA.Clear();
        genNumText.text = "Generation " + genCount;
    }

    /// <summary>
    /// Takes a gene at a specific index and converts it to an action at that index 
    /// </summary>
    /// <param name="index">Index of the gene in the genes array</param>
    public void ConvertGeneToAction(int index)
    {
        //Actions.Instance.IntToAction(currentGenesForActions[index]);
        actions.IntToAction(currentGenesForActions[index]);
    }

}
