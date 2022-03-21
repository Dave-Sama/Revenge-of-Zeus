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
    private Animator playerDeadAnim;
    private Animator opponentDeadAnim;
    private int roundCounter;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        rightWall = GameObject.Find("Right Wall");
        leftWall = GameObject.Find("Left Wall");
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        playersNameText.text = DataManager.Instance.PlayersCharacter;
        opponentsNameText.text = "Zeus"; //-----------------------Temporary for development and testing--------------
        Vector3 characterPosition = new Vector3(-2.75f, 0, 0);
        playerClone=InstantiateCharacter(playersNameText.text, characterPosition,true);
        opponentClone=InstantiateCharacter(opponentsNameText.text, characterPosition*(-1),false);
        //playerDeadAnim = playerClone.GetComponent<Animator>(); // --------put in comments when testing-----------
        opponentDeadAnim = opponentClone.GetComponent<Animator>();
        DataManager.Instance.IsPlayerDead = false;
        DataManager.Instance.IsOpponentDead = false;
        rightWall.transform.position = new Vector3(camera.pixelWidth/2, rightWall.transform.position.y);
        leftWall.transform.position = new Vector3(camera.pixelWidth / (-2), rightWall.transform.position.y);
        roundCounter = 1;
        //playerController = playerClone.GetComponent<PlayerController>(); put temporarily in comments for development and testing
        //playerController.enabled = false;  put temporarily in comments for development and testing
        StartCoroutine(RoundReadyFight());
    }

    // Update is called once per frame
    void Update()
    {
        //if (playerClone.transform.position.x < -4.21f) // --------put in comments when testing-----------
        //{
        //    playerClone.transform.position = new Vector3(-4.21f, playerClone.transform.position.y, playerClone.transform.position.z);
        //}
        if (opponentClone.transform.position.x > 3.99f)
        {
            opponentClone.transform.position = new Vector3(3.99f, opponentClone.transform.position.y, opponentClone.transform.position.z);
        }
        //if (DataManager.Instance.IsPlayerDead) // --------put in comments when testing-----------
        //{
        //    playerDeadAnim.SetTrigger("Dead_Trig");
        //    winText.text = opponentsNameText.text + " Wins!";
        //    winText.gameObject.SetActive(true);
        //}
        if (DataManager.Instance.IsOpponentDead)
        {
            opponentDeadAnim.SetTrigger("Dead_Trig");
            winText.text = playersNameText.text + " Wins!";
            winText.gameObject.SetActive(true);
            if (roundCounter == 2)
            {
                roundCounter=0;
                playerVictoryMark[1].SetActive(true);
            }
            if (roundCounter == 1)
            {
                roundCounter++;
                playerVictoryMark[0].SetActive(true);
            }
        }
        if(DataManager.Instance.IsPlayerDead && DataManager.Instance.IsOpponentDead)
        {
            winText.text = "Draw";
            winText.gameObject.SetActive(true);
            if (roundCounter == 2)
            {
                roundCounter=0;
                opponentVictoryMark[1].SetActive(true);
                playerVictoryMark[1].SetActive(true);
            }
            if (roundCounter == 1)
            {
                roundCounter++;
                opponentVictoryMark[0].SetActive(true);
                playerVictoryMark[0].SetActive(true);
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
                    PlayerController controller = character.gameObject.GetComponent<PlayerController>();
                    controller.enabled = false;
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
        roundText.text = "Round " + roundCounter;
        yield return new WaitForSeconds(2);
        roundText.gameObject.SetActive(false);
        readyText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        readyText.gameObject.SetActive(false);
        fightText.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        fightText.gameObject.SetActive(false);
        //playerController.enabled = true; put temporary in comments for development and testing
    }
}
