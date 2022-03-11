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
    [SerializeField] private Slider healthBarFront;
    [SerializeField] private Slider healthBarBack;
    private float sleep; // sleep variable for daleying porpuses
    private bool pressed; // is space button pressed or not, temporary for development and testing

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
        sleep = 0;
        pressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            healthBarFront.value = healthBarFront.value - 1;
            pressed = true;
        }
        if (sleep < 1 && pressed==true)
        {
            sleep += Time.deltaTime;
        }
        if (healthBarBack.value > healthBarFront.value && sleep>=1)
        {
           
            healthBarBack.value = healthBarBack.value - 0.01f;
        }
        if (healthBarBack.value <= healthBarFront.value)
        {
            sleep = 0;
            pressed = false;
        }
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
                    Instantiate(character, characterPosition, character.transform.rotation);
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
                    Instantiate(character, characterPosition, opponentRotation);
                }
            }
        }
    }
}
