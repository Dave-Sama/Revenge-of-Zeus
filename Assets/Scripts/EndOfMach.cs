using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class EndOfMach : MonoBehaviour
{
    [SerializeField] GameObject[] characters = new GameObject[15];
    [SerializeField] Button playAgainButton;
    [SerializeField] TextMeshProUGUI drawText;
    EventSystem eventSystem;
    GameObject podium;
    bool downArrowClicked;

    // Start is called before the first frame update
    void Start()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        podium = GameObject.Find("Podium");
        downArrowClicked = true;
        if(DataManager.Instance.PvPWinner == "" && DataManager.Instance.PvPLoser == "")
        {
            podium.SetActive(false);
            drawText.enabled = true;
        }
        else
        {
            InstantiateCharacters();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && !downArrowClicked)
        {
            playAgainButton.Select();
            downArrowClicked = true;
        }
        if ((Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1)) && downArrowClicked)
        {
            ResetDownArrowClicked();
        }
    }

    void InstantiateCharacters()
    {
        foreach(GameObject character in characters)
        {
            float rotationY = 168.631f;
            Quaternion rotationQuaternion = new Quaternion(character.transform.rotation.x, rotationY, character.transform.rotation.z, character.transform.rotation.w);
            Vector3 cloneScale= new Vector3(0.3824849f, 0.3824849f, 0.3824849f);

            if (character.name == DataManager.Instance.PvPWinner)
            {
               
                GameObject winnerClone=Instantiate(character, new Vector3(-0.05f, 1.335f, -7.635f),rotationQuaternion);
                winnerClone.transform.localScale = cloneScale;
                PlayerController playerController = winnerClone.GetComponent<PlayerController>();
                Rigidbody cloneRB=winnerClone.GetComponent<Rigidbody>();
                BoxCollider cloneCollider=winnerClone.GetComponent<BoxCollider>();
                cloneRB.constraints = RigidbodyConstraints.FreezePositionY;
                playerController.enabled = false;
                cloneCollider.enabled = false;
            }
            if (character.name == DataManager.Instance.PvPLoser)
            {
                GameObject loserClone = Instantiate(character, new Vector3(-0.387f, 1.157f, -7.641f), rotationQuaternion);
                loserClone.transform.localScale = cloneScale;
                PlayerController playerController = loserClone.GetComponent<PlayerController>();
                Rigidbody cloneRB = loserClone.GetComponent<Rigidbody>();
                BoxCollider cloneCollider = loserClone.GetComponent<BoxCollider>();
                cloneRB.constraints = RigidbodyConstraints.FreezePositionY;
                playerController.enabled = false;
                cloneCollider.enabled = false;
            }
        }
    }

    public void HighlightOneButton()
    {
        eventSystem.SetSelectedGameObject(null);
    }

    public void ResetDownArrowClicked()
    {
        downArrowClicked = false;
    }

    public void OnPlayAgain()
    {
        DataManager.Instance.playerWonCounter=0;
        DataManager.Instance.opponentWonCounter=0;
        SceneLoader.Instance.LoadScene(3); // Scene index 3 = battle scene
    }

    public void OnBackToCharacters()
    {
        DataManager.Instance.playerWonCounter = 0;
        DataManager.Instance.opponentWonCounter = 0;
        SceneLoader.Instance.LoadScene(2); // Scene index 2 = character selection scene
    }

    public void OnBackToMenu()
    {
        DataManager.Instance.playerWonCounter = 0;
        DataManager.Instance.opponentWonCounter = 0;
        SceneLoader.Instance.LoadScene(0); // Scene index 0 = main menu scene
    }
}
