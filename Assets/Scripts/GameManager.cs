using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] characters = new GameObject[15];
    [SerializeField] private TextMeshProUGUI playersNameText;
    [SerializeField] private TextMeshProUGUI opponentsNameText;
    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private TextMeshProUGUI roundText;
    [SerializeField] private TextMeshProUGUI readyText;
    [SerializeField] private TextMeshProUGUI fightText;
    [SerializeField] private GameObject[] playerVictoryMark; // the blue little circles that appear when the player wins the current round
    [SerializeField] private GameObject[] opponentVictoryMark; // the blue little circles that appear when the opponent wins the current round
    private GameObject rightWall;
    private GameObject leftWall;
    private GameObject playerClone;
    private GameObject opponentClone;
    private Camera camera;
    private Animator playerAnim;
    private Animator opponentAnim;
    private PlayerController playerController;
    private PlayerController opponentController;
    private AI opponentAI;
    private List<string> freeOpponents;
    private AudioSource battleMusic;
    private bool raisedCounterOnDraw;
    private GameObject pauseMenu;
    private Quaternion playerRotation;
    private Quaternion opponentRotation;
    // Start is called before the first frame update
    void Start()
    {
        rightWall = GameObject.Find("Right Wall");
        leftWall = GameObject.Find("Left Wall");
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        battleMusic = gameObject.GetComponent<AudioSource>();
        raisedCounterOnDraw = false;
        pauseMenu = GameObject.Find("Pause Menu");
        pauseMenu.SetActive(false);
        DataManager.Instance.OpponentBeingHit = false;
        DataManager.Instance.PlayerBeingHit = false;
        if (DataManager.Instance.playerWonCounter == 0 && DataManager.Instance.opponentWonCounter == 0)
        {
            DataManager.Instance.CurrentRound = 1;
        }

        playersNameText.text = DataManager.Instance.PlayersCharacter;

        if(DataManager.Instance.GameMode=="ML1" || DataManager.Instance.GameMode=="ML2")
        {
            if (DataManager.Instance.BattleNumber == 1 && DataManager.Instance.CurrentRound == 1)
            {
                freeOpponents = new List<string>();
                FillListWithOpponents();
                DataManager.Instance.FreeOpponents = freeOpponents; // init the free opponents
            }
            else
            {
                freeOpponents = DataManager.Instance.FreeOpponents; // update the free opponents
            }
            //playersNameText.text = "Helios"; //-----------------------Temporary for development and testing--------------
            //opponentsNameText.text = "Hermes"; 
            if (DataManager.Instance.CurrentRound == 1)
            {
                opponentsNameText.text = GetRandomCharacterName();
                DataManager.Instance.CurrentOpponent = opponentsNameText.text;
            }
            else
            {
                opponentsNameText.text = DataManager.Instance.CurrentOpponent;
            }
        }

        if (DataManager.Instance.GameMode == "PvP")
        {
            opponentsNameText.text = DataManager.Instance.OpponentsCharacter;
            DataManager.Instance.CurrentOpponent = opponentsNameText.text;
        }


        opponentsNameText.text = "Helios";// ---------------------------------For testing, delete later-------------------------

        Vector3 characterPosition = new Vector3(-2.75f, 0, 0);
        playerClone=InstantiateCharacter(playersNameText.text, characterPosition,true);
        opponentClone=InstantiateCharacter(opponentsNameText.text, characterPosition*(-1),false);
        playerAnim = playerClone.GetComponent<Animator>(); // --------put in comments when testing-----------
        opponentAnim = opponentClone.GetComponent<Animator>();
        if (DataManager.Instance.GameMode == "PvP")
        {
            string playerControllerName = playersNameText.text + "PvP";
            string opponentControllerName = opponentsNameText.text + "PvP";
            playerAnim.runtimeAnimatorController = Resources.Load("Animations/Playable_Characters/" + playerControllerName) as RuntimeAnimatorController;
            opponentAnim.runtimeAnimatorController = Resources.Load("Animations/Playable_Characters/" + opponentControllerName) as RuntimeAnimatorController;
        }
        else
        {
            string playerControllerName = playersNameText.text + "PvP";
            string opponentControllerName = opponentsNameText.text + "NPC";
            playerAnim.runtimeAnimatorController = Resources.Load("Animations/Playable_Characters/" + playerControllerName) as RuntimeAnimatorController;
            opponentAnim.runtimeAnimatorController = Resources.Load("Animations/NPC/" + opponentControllerName) as RuntimeAnimatorController;
        }
        DataManager.Instance.IsPlayerDead = false;
        DataManager.Instance.IsOpponentDead = false;
        //rightWall.transform.position = new Vector3(camera.pixelWidth/2, rightWall.transform.position.y);  // ---------------delete this later--------------------
        //leftWall.transform.position = new Vector3(camera.pixelWidth / (-2), rightWall.transform.position.y); // ---------------delete this later--------------------
        WinningsToVictoryMarks(DataManager.Instance.playerWonCounter, playerVictoryMark);
        WinningsToVictoryMarks(DataManager.Instance.opponentWonCounter, opponentVictoryMark);
        playerController = playerClone.GetComponent<PlayerController>();
        playerController.enabled = false;
        opponentController = opponentClone.GetComponent<PlayerController>();
        opponentController.enabled = false;
        opponentAI = opponentClone.GetComponent<AI>();
        playerRotation=playerClone.transform.rotation;
        opponentRotation=opponentClone.transform.rotation;
        StartCoroutine(RoundReadyFight());
    }

    // Update is called once per frame
    void Update()
    {
        // --------------------------- Fixing the low kick rotation bug -----------------------------------------------------

        playerClone.transform.rotation = playerRotation;
        opponentClone.transform.rotation = opponentRotation;

        // --------------------------- Activating Pause Menu -----------------------------------------------------

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }

        // --------------------------- Setting the boundaries of the battle arena -----------------------------------------------------

        if (playerClone.transform.position.x < -4.21f) // --------put in comments when testing-----------
        {
            playerClone.transform.position = new Vector3(-4.21f, playerClone.transform.position.y, playerClone.transform.position.z);
        }

        if (opponentClone.transform.position.x > 3.99f)
        {
            opponentClone.transform.position = new Vector3(3.99f, opponentClone.transform.position.y, opponentClone.transform.position.z);
        }

        // --------------------------- When it's a draw -----------------------------------------------------

        if (DataManager.Instance.IsPlayerDead && DataManager.Instance.IsOpponentDead)
        {
            playerAnim.SetTrigger("Dead_Trig");
            opponentAnim.SetTrigger("Dead_Trig");
            StartCoroutine(WinnerAnnouncement(""));
            if (DataManager.Instance.CurrentRound == 3)
            {
                if (DataManager.Instance.GameMode == "ML1" || DataManager.Instance.GameMode == "ML2") // Goes to the next battle (same as if the player won)
                {
                    DataManager.Instance.playerWonCounter = 0;
                    DataManager.Instance.opponentWonCounter = 0;
                    freeOpponents.Remove(opponentsNameText.text);
                    DataManager.Instance.FreeOpponents = freeOpponents;
                    DataManager.Instance.BattleNumber++;
                    StartCoroutine(ResetScene());
                }
                if (DataManager.Instance.GameMode == "PvP")  // Goes to the end of match screen with a draw message
                {
                    DataManager.Instance.PvPWinner = "";
                    DataManager.Instance.PvPLoser = "";
                    StartCoroutine(GoToEndOfMatchScene());
                }
            }
            if (DataManager.Instance.CurrentRound == 2 && !raisedCounterOnDraw)
            {
                DataManager.Instance.playerWonCounter++;
                DataManager.Instance.opponentWonCounter++;
                raisedCounterOnDraw = true;
                if (DataManager.Instance.playerWonCounter == DataManager.Instance.opponentWonCounter)
                {
                    DataManager.Instance.CurrentRound = 3;
                    opponentVictoryMark[1].SetActive(true);
                    playerVictoryMark[1].SetActive(true);
                    DataManager.Instance.IsOpponentDead = false;
                    DataManager.Instance.IsPlayerDead = false;
                    StartCoroutine(ResetScene());
                }
                if (DataManager.Instance.playerWonCounter > DataManager.Instance.opponentWonCounter)
                {
                    if (DataManager.Instance.GameMode == "ML1" || DataManager.Instance.GameMode == "ML2")
                    {
                        DataManager.Instance.playerWonCounter = 0;
                        DataManager.Instance.opponentWonCounter = 0;
                        freeOpponents.Remove(opponentsNameText.text);
                        DataManager.Instance.FreeOpponents = freeOpponents;
                        DataManager.Instance.BattleNumber++;
                        StartCoroutine(ResetScene());
                    }
                    if (DataManager.Instance.GameMode == "PvP")
                    {
                        DataManager.Instance.PvPWinner = playersNameText.text;
                        DataManager.Instance.PvPLoser = opponentsNameText.text;
                        StartCoroutine(GoToEndOfMatchScene());
                    }
                }
                if (DataManager.Instance.opponentWonCounter > DataManager.Instance.playerWonCounter)
                {
                    if (DataManager.Instance.GameMode == "ML1" || DataManager.Instance.GameMode == "ML2")
                    {
                        Debug.Log("Go to Game Over scene");
                    }
                    if (DataManager.Instance.GameMode == "PvP")
                    {
                        DataManager.Instance.PvPWinner = opponentsNameText.text;
                        DataManager.Instance.PvPLoser = playersNameText.text;
                        StartCoroutine(GoToEndOfMatchScene());
                    }
                }
                
            }
            if (DataManager.Instance.CurrentRound == 1)
            {
                DataManager.Instance.playerWonCounter++;
                DataManager.Instance.opponentWonCounter++;
                opponentVictoryMark[0].SetActive(true);
                playerVictoryMark[0].SetActive(true);
                DataManager.Instance.CurrentRound++;
                DataManager.Instance.IsOpponentDead = false;
                DataManager.Instance.IsPlayerDead = false;
                StartCoroutine(ResetScene());
            }
        }

        // --------------------------- When the opponent (or player 2) kills the player (or player 1)-----------------------------------------------------

        if (DataManager.Instance.IsPlayerDead && !DataManager.Instance.IsOpponentDead) // --------put in comments when testing-----------
        {
            playerAnim.SetTrigger("Dead_Trig");
            StartCoroutine(WinnerAnnouncement(opponentsNameText.text));

            if (DataManager.Instance.CurrentRound == 3)
            {
                if (DataManager.Instance.GameMode == "ML1" || DataManager.Instance.GameMode == "ML2")
                {
                    StartCoroutine(GoToGameOverScene());
                }
                if (DataManager.Instance.GameMode == "PvP")
                {
                    DataManager.Instance.opponentWonCounter++;
                    DataManager.Instance.PvPWinner = opponentsNameText.text;
                    DataManager.Instance.PvPLoser = playersNameText.text;
                    StartCoroutine(GoToEndOfMatchScene());
                }
            }
            if (DataManager.Instance.CurrentRound == 2)
            {
                DataManager.Instance.opponentWonCounter = 2;
                opponentVictoryMark[1].SetActive(true);
                DataManager.Instance.IsPlayerDead = false;
                if (DataManager.Instance.playerWonCounter == 0)
                {
                    if (DataManager.Instance.GameMode == "ML1" || DataManager.Instance.GameMode == "ML2")
                    {
                        StartCoroutine(GoToGameOverScene());
                    }
                    if (DataManager.Instance.GameMode == "PvP")
                    {
                        DataManager.Instance.PvPWinner = opponentsNameText.text;
                        DataManager.Instance.PvPLoser = playersNameText.text;
                        StartCoroutine(GoToEndOfMatchScene());
                    }

                }
                if (DataManager.Instance.playerWonCounter == 1)
                {
                    DataManager.Instance.opponentWonCounter = 1;
                    DataManager.Instance.CurrentRound++;
                    StartCoroutine(ResetScene());
                }
            }
            if (DataManager.Instance.CurrentRound == 1)
            {
                DataManager.Instance.CurrentRound++;
                DataManager.Instance.opponentWonCounter = 1;
                DataManager.Instance.IsPlayerDead = false;
                StartCoroutine(ResetScene());
            }
        }

        // --------------------------- When the player (or player 1) kills the opponent (or player 2)-----------------------------------------------------

        if (DataManager.Instance.IsOpponentDead && !DataManager.Instance.IsPlayerDead)
        {
            opponentAnim.SetTrigger("Dead_Trig");
            StartCoroutine(WinnerAnnouncement(playersNameText.text));
            if (DataManager.Instance.CurrentRound == 3)
            {
                if (DataManager.Instance.GameMode == "ML1" || DataManager.Instance.GameMode == "ML2")
                {
                    if (DataManager.Instance.BattleNumber < 10)
                    {
                        DataManager.Instance.playerWonCounter = 0;
                        DataManager.Instance.opponentWonCounter = 0;
                        freeOpponents.Remove(opponentsNameText.text);
                        DataManager.Instance.FreeOpponents = freeOpponents;
                        DataManager.Instance.BattleNumber++;
                        StartCoroutine(ResetScene());
                    }
                    else
                    {
                        StartCoroutine(GoToWinnerScene());
                    }
                }
                if (DataManager.Instance.GameMode == "PvP")
                {
                    DataManager.Instance.playerWonCounter++;
                    playerVictoryMark[1].SetActive(true);
                    DataManager.Instance.PvPWinner = playersNameText.text;
                    DataManager.Instance.PvPLoser = opponentsNameText.text;
                    StartCoroutine(GoToEndOfMatchScene());
                }
            }
            if (DataManager.Instance.CurrentRound == 2)
            {   
                playerVictoryMark[1].SetActive(true);
                DataManager.Instance.IsOpponentDead = false;
                if (DataManager.Instance.opponentWonCounter == 0)
                {
                    DataManager.Instance.playerWonCounter = 2;
                    if (DataManager.Instance.GameMode=="ML1" || DataManager.Instance.GameMode == "ML2")
                    {
                        if(DataManager.Instance.BattleNumber < 10)
                        {
                            DataManager.Instance.playerWonCounter = 0;
                            freeOpponents.Remove(opponentsNameText.text);
                            DataManager.Instance.FreeOpponents = freeOpponents;
                            DataManager.Instance.BattleNumber++;
                            StartCoroutine(ResetScene());
                        }
                        else
                        {
                            StartCoroutine(GoToWinnerScene());
                        }
                        
                    }
                    if (DataManager.Instance.GameMode == "PvP")
                    {
                        DataManager.Instance.PvPWinner=playersNameText.text;
                        DataManager.Instance.PvPLoser=opponentsNameText.text;
                        StartCoroutine(GoToEndOfMatchScene());
                    }
                    
                }
                if (DataManager.Instance.opponentWonCounter == 1)
                {
                    DataManager.Instance.playerWonCounter = 1;
                    DataManager.Instance.CurrentRound++;
                    StartCoroutine(ResetScene());
                } 
            }
            if (DataManager.Instance.CurrentRound == 1)
            {
                DataManager.Instance.CurrentRound++;
                DataManager.Instance.playerWonCounter = 1;
                DataManager.Instance.IsOpponentDead = false;
                StartCoroutine(ResetScene());
            }
        }
    }

    public void OnBackButtonClick()
        /*
         * A back button I made for testing during development
         */
    {
        SceneManager.LoadScene(2);
    }

    void FillListWithOpponents()
    {
        foreach(GameObject character in characters)
        {
            if (character.name != playersNameText.text)
            {
                freeOpponents.Add(character.name);
            }
        }
    }

    string GetRandomCharacterName()
    {
        int randomIndex=Random.Range(0, freeOpponents.Count);
        string character = freeOpponents[randomIndex];
        return character;
    }

    private GameObject InstantiateCharacter(string characterName,Vector3 characterPosition, bool isPlayer)
    {
        foreach (GameObject character in characters)
        {
            if (string.Equals(characterName, character.name))
            {
                if (isPlayer)
                {
                    GameObject player;
                    player=Instantiate(character, characterPosition, character.transform.rotation);
                    player.tag = "Player";
                    return player;
                }
                else
                {
                    float opponentRotationX = character.transform.rotation.x;
                    float opponentRotationY = character.transform.rotation.y * (-1);
                    float opponentRotationZ = character.transform.rotation.z;
                    float opponentRotationW = character.transform.rotation.w;
                    Quaternion opponentRotation = new Quaternion(opponentRotationX, opponentRotationY, opponentRotationZ, opponentRotationW);
                    GameObject opponent;
                    opponent=Instantiate(character, characterPosition, opponentRotation);
                    opponent.tag = "Opponent";
                    return opponent;
                }
            }
        }
        return null;
    }

    IEnumerator RoundReadyFight()
        /*
         * Declares what round it is, and then declares the ready, fight statements
         */
    {
        roundText.text = "Round " + DataManager.Instance.CurrentRound;
        yield return new WaitForSeconds(2);
        roundText.gameObject.SetActive(false);
        readyText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        readyText.gameObject.SetActive(false);
        fightText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        fightText.gameObject.SetActive(false);
        playerController.enabled = true;
        if (DataManager.Instance.GameMode == "PvP")
        {
            opponentController.enabled = true;
        }
        else
        {
            opponentAI.startFight = true;
        }
        battleMusic.Play();
    }

    IEnumerator WinnerAnnouncement(string name)
    {
        AudioSource winnerSound=null;
        foreach(GameObject character in characters)
        {
            if (name == character.name)
            {
                winnerSound = GameObject.Find(character.name + "(Clone)").GetComponent<AudioSource>();
                break;
            }
        }
        if (DataManager.Instance.IsPlayerDead && DataManager.Instance.IsOpponentDead)
        {
            winText.text = "Double K.O.";
            winText.gameObject.SetActive(true);
        }
        else
        {
            winText.text = "      K.O.";
            winText.gameObject.SetActive(true);
            yield return new WaitForSeconds(2);
            winText.text = name + " Wins!";
        }
        if (winnerSound!=null)
        {
            winnerSound.Play();
        }
        else
        {
            Debug.Log("Winner sound error!");
        }
        yield return new WaitForSeconds(8);
    }

    void WinningsToVictoryMarks(int winCounter, GameObject[] victoryMark)
    {
        if (winCounter == 0)
        {
            victoryMark[0].SetActive(false);
            victoryMark[1].SetActive(false);
        }
        if (winCounter == 1)
        {
            victoryMark[0].SetActive(true);
            victoryMark[1].SetActive(false);
        }
        if (winCounter == 2)
        {
            victoryMark[0].SetActive(true);
            victoryMark[1].SetActive(true);
        }
    }

    IEnumerator ResetScene()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator GoToEndOfMatchScene()
    {
        yield return new WaitForSeconds(3);
        SceneLoader.Instance.LoadScene(4); // Scene index 4 = End of Match scene
    }

    IEnumerator GoToGameOverScene()
    {
        yield return new WaitForSeconds(3);
        SceneLoader.Instance.LoadScene(5); // Scene index 5 = Game Over scene
    }
    IEnumerator GoToWinnerScene()
    {
        yield return new WaitForSeconds(3);
        SceneLoader.Instance.LoadScene(6); // Scene index 6 = Winner scene
    }
}
