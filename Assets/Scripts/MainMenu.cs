using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject buttonSet;
    [SerializeField] private GameObject exitGameMessage;
    [SerializeField] private GameObject gameplayModeWindow;
    [SerializeField] private GameObject settingsWindow;
    private Button startButton;
    private TextMeshProUGUI title;
    private TextMeshProUGUI pressToContinueText;
    private bool downArrowClicked; // goes to true if the user clicked the down arrow one time to highlight the start button
    private EventSystem eventSystem;
    private Button noButton; // Refers to the "No" button of the exit menu
    private Button ML1Button;

    // Start is called before the first frame update
    void Start()
    {
        title = GameObject.Find("Title Text").GetComponent<TextMeshProUGUI>();
        pressToContinueText = GameObject.Find("Press Any Key Text").GetComponent<TextMeshProUGUI>();
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        downArrowClicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(title.gameObject.activeInHierarchy && pressToContinueText.gameObject.activeInHierarchy)
        {
            PressAnyKey();
        }
        if (buttonSet.activeInHierarchy && Input.GetKeyDown(KeyCode.DownArrow) && !downArrowClicked)
        {
            startButton.Select();
            downArrowClicked = true;
        }
        if (exitGameMessage.activeInHierarchy && Input.GetKeyDown(KeyCode.Escape))
        {
            CancelExit();
        }
        if (gameplayModeWindow.activeInHierarchy && Input.GetKeyDown(KeyCode.DownArrow) && !downArrowClicked)
        {
            ML1Button.Select();
            downArrowClicked = true;
        }
        if(!gameplayModeWindow.activeInHierarchy && !DataManager.Instance.downArrowPressed)
        {
            downArrowClicked = false;
            DataManager.Instance.downArrowPressed = true;
        }

    }

    void PressAnyKey()
        /*
         * Refers to the "Press any key to continue" message, opens the menu when pressing any key
         */
    {
        if (Input.anyKeyDown)
        {
            title.gameObject.SetActive(false);
            pressToContinueText.gameObject.SetActive(false);
            buttonSet.SetActive(true);
            startButton = GameObject.Find("Start Button").GetComponent<Button>();
        }
    }

    public void StartGame()
    {
        buttonSet.SetActive(false);
        gameplayModeWindow.SetActive(true);
        ML1Button = GameObject.Find("ML1 Button").GetComponent<Button>();
        DataManager.Instance.downArrowPressed = true;
        downArrowClicked = false;
    }
    public void GoToSettings()
    {
        buttonSet.SetActive(false);
        settingsWindow.SetActive(true);
    }

    public void TurnOnExitMessage()
    {
        buttonSet.SetActive(false);
        exitGameMessage.SetActive(true);
        noButton = GameObject.Find("No Button").GetComponent<Button>();
        noButton.Select();
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    public void CancelExit()
        /*
         * This event triggers when the players press No in the Quit message
         */
    {
        buttonSet.SetActive(true);
        exitGameMessage.SetActive(false);
        ResetDownArrowSelection();
    }

    public void HighlightOneButton()
    {
        eventSystem.SetSelectedGameObject(null);
    }

    public void ResetDownArrowSelection()
    {
        downArrowClicked = false;
        if(exitGameMessage.activeInHierarchy)
        {
            noButton.Select();
        }
    }
}
