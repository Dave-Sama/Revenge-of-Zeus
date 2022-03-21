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
    private GameObject rightWall;
    private GameObject leftWall;
    private GameObject playerClone;
    private GameObject opponentClone;
    private Camera camera;
    private Animator playerDeadAnim;
    private Animator opponentDeadAnim;

    // Start is called before the first frame update
    void Start()
    {
        rightWall = GameObject.Find("Right Wall");
        leftWall = GameObject.Find("Left Wall");
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
        string playersName = DataManager.Instance.PlayersCharacter;
        string opponentsName = "Zeus"; //Temporary for development and testing
        Vector3 characterPosition = new Vector3(-2.75f, 0, 0);
        playerClone=InstantiateCharacter(playersName, characterPosition,true);
        opponentClone=InstantiateCharacter(opponentsName, characterPosition*(-1),false);
        playersNameText.text = playersName;
        opponentsNameText.text = opponentsName;
        //playerDeadAnim = playerClone.GetComponent<Animator>();
        opponentDeadAnim = opponentClone.GetComponent<Animator>();
        DataManager.Instance.IsPlayerDead = false;
        DataManager.Instance.IsOpponentDead = false;
        rightWall.transform.position = new Vector3(camera.pixelWidth/2, rightWall.transform.position.y);
        leftWall.transform.position = new Vector3(camera.pixelWidth / (-2), rightWall.transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        //if(playerClone.transform.position.x<-4.21f)
        //{
        //    playerClone.transform.position = new Vector3(-4.21f, playerClone.transform.position.y, playerClone.transform.position.z);
        //}
        if (opponentClone.transform.position.x > 3.99f)
        {
            opponentClone.transform.position = new Vector3(3.99f, opponentClone.transform.position.y, opponentClone.transform.position.z);
        }
        //if(DataManager.Instance.IsPlayerDead)
        //{
        //    playerDeadAnim.SetTrigger("Dead_Trig");
        //}
        if (DataManager.Instance.IsOpponentDead)
        {
            opponentDeadAnim.SetTrigger("Dead_Trig");
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
}
