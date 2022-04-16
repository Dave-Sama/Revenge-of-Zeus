using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string GameMode { get; set; }
    public string PlayersCharacter { get; set; }
    public string OpponentsCharacter { get; set; }
    public int Damage { get; set; }
    public bool IsP1Attacking { get; set; } // Is player 1 attacking or not
    public bool IsP2Attacking { get; set; } // Is player 2 attacking or not
    public bool IsPlayer { get; set; } // Wether the player gets hit or the opponent gets hit to know who lost health, also, helps to diffrentiate between players in PvP
    public string P1AttackName { get; set; } // Which attack player 1 uses
    public string P2AttackName { get; set; } // Which attack player uses
    public bool IsPlayerDead { get; set; }
    public bool IsOpponentDead { get; set; }
    public int CurrentRound { get; set; }
    public int playerWonCounter { get; set; } // How many rounds the player won in the current fight
    public int opponentWonCounter { get; set; } // How many rounds the opponent won in the current fight
    public List<string> FreeOpponents{ get; set; } // List of opponents that have not been used yet in the current game
    public int BattleNumber { get; set; } // Which battle number it is out of 10 battles
    public string CurrentOpponent { get; set; }  // The opponent for the current battle
    public bool downArrowPressed { get; set; } // For the highlighting of the buttons using the arrow in the menu
    public bool BlockTrigger { get; set; } // Used to turn on/off event triggers in the character selection screen
    public GameObject CPUClone { get; set; } // The clone of the character after chosen in modes ML1 and ML2
    public GameObject P1Clone { get; set; } // The clone of the player 1 character after chosen in PvP mode
    public GameObject P2Clone { get; set; } // The clone of the player 2 character after chosen in PvP mode
    public string PvPWinner { get; set; } // Who won the PvP match
    public string PvPLoser { get; set; } // Who lost the PvP match


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
