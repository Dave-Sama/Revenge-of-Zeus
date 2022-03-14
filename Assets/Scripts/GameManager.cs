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

    // Start is called before the first frame update
    void Start()
    {
        string playersName = DataManager.Instance.PlayersCharacter;
        string opponentsName = "Zeus"; //Temporary for development and testing
        Vector3 characterPosition = new Vector3(-2.75f, 0, 0);
        InstantiateCharacter(playersName, characterPosition,true);
        InstantiateCharacter(opponentsName, characterPosition*(-1),false);
        playersNameText.text = playersName;
        opponentsNameText.text = opponentsName;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnBackButtonClick()
        /*
         * A back button I made for testing during development
         */
    {
        SceneManager.LoadScene(2);
    }

    private void InstantiateCharacter(string characterName,Vector3 characterPosition, bool isPlayer)
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
                }
            }
        }
    }
}
