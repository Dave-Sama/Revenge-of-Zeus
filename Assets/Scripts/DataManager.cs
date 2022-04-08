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
    public bool IsAttacking { get; set; } // Wether the player attacks or the opponent attacks
    public bool IsPlayer { get; set; } // Wether the player gets hit or the opponent gets hit to know who lost health
    
    // Keycodes for player 1 control

    public KeyCode upper_left_punch1_Keycode { get; set; }
    public KeyCode upper_right_punch1_Keycode { get; set; }
    public KeyCode upper_kick1_Keycode { get; set; }
    public KeyCode middle_left_punch1_Keycode { get; set; }
    public KeyCode middle_right_punch1_Keycode { get; set; }
    public KeyCode middle_kick1_Keycode { get; set; }
    public KeyCode special_attack1_Keycode { get; set; }
    public KeyCode jump1_Keycode { get; set; }
    public KeyCode bend1_Keycode { get; set; }
    public KeyCode block1_Keycode { get; set; }

    // Keycodes for player 2 control
    public KeyCode upper_left_punch2_Keycode { get; set; }
    public KeyCode upper_right_punch2_Keycode { get; set; }
    public KeyCode upper_kick2_Keycode { get; set; }
    public KeyCode middle_left_punch2_Keycode { get; set; }
    public KeyCode middle_right_punch2_Keycode { get; set; }
    public KeyCode middle_kick2_Keycode { get; set; }
    public KeyCode special_attack2_Keycode { get; set; }
    public KeyCode jump2_Keycode { get; set; }
    public KeyCode bend2_Keycode { get; set; }
    public KeyCode block2_Keycode { get; set; }
    public string AttackName { get; set; } // Which attack is used
    public bool IsPlayerDead { get; set; }
    public bool IsOpponentDead { get; set; }
    public int CurrentRound { get; set; }
    public int playerWonCounter { get; set; } // How many rounds the player won in the current fight
    public int opponentWonCounter { get; set; } // How many rounds the opponent won in the current fight
    public List<string> FreeOpponents{ get; set; } // List of opponents that have not been used yet in the current game
    public int BattleNumber { get; set; } // Which battle number it is out of 10 battles
    public string CurrentOpponent { get; set; }  // The opponent for the current battle

    void Awake()
        /*
         * Awake is like Start but is called even if the sctipt is disabled.
         * Basically I created a singleton that will never be destroyed when loading a new scene.
         * That way I can pass data between different scenes.
         */
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            if (Instance != this)
            {
                Destroy(gameObject);
            }
        }
    }

    void Update()
        /*
         * Update is called once per frame
         */
    {
        
    }
}
