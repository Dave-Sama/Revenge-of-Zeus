using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string GameMod { get; set; }
    public string PlayersCharacter { get; set; }
    public string OpponentsCharacter { get; set; }
    public int Damage { get; set; }
    public bool IsAttacking { get; set; }
    public bool IsPlayer { get; set; } // Wether the player gets hit or the opponent gets hit

    void Awake()
        /*
         * Awake is like Start but is called even if the sctipt is disabled.
         * Basically I created a singleton that will never be destroyed when loading a new scene.
         * That way I can pass data between different scenes.
         */
    {
        if(Instance!=null)
        {
            Destroy(Instance);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
        /*
         * Update is called once per frame
         */
    {
        
    }
}
