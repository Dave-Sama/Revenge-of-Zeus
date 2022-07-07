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
    [SerializeField] private GameObject agentWindow;
    [SerializeField] private GameObject settingsWindow;
    private Button startButton;
    private TextMeshProUGUI title;
    private TextMeshProUGUI pressToContinueText;
    private bool downArrowClicked; // goes to true if the user clicked the down arrow one time to highlight the start button
    private EventSystem eventSystem;
    private Button noButton; // Refers to the "No" button of the exit menu
    private Button ML1Button;
    public Button EasyButton;

    // Start is called before the first frame update
    void Start()
    {
        title = GameObject.Find("Title Text").GetComponent<TextMeshProUGUI>();
        pressToContinueText = GameObject.Find("Press Any Key Text").GetComponent<TextMeshProUGUI>();
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        downArrowClicked = false;
        DataManager.Instance.LoadSettings();
        AudioListener.volume = DataManager.Instance.volume;
        //if(!DataManager.Instance.EnteredTheGame)
        //{
        //    InitializeControllers();
        //}       
    }

    // Update is called once per frame
    void Update()
    {
        if (title.gameObject.activeInHierarchy && pressToContinueText.gameObject.activeInHierarchy)
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
        if (agentWindow.activeInHierarchy && Input.GetKeyDown(KeyCode.DownArrow) && !DataManager.Instance.downArrowPressed)
        {
            EasyButton.Select();
            DataManager.Instance.downArrowPressed = true;
        }
        if (!gameplayModeWindow.activeInHierarchy && !agentWindow.activeInHierarchy && !DataManager.Instance.downArrowPressed)
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
            DataManager.Instance.EnteredTheGame = true;
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
        if (exitGameMessage.activeInHierarchy)
        {
            noButton.Select();
        }
    }

    //public void InitializeControllers()
    //{
    //    DataManager.Instance.upper_left_punch1_Keycode = KeyCode.A;
    //    DataManager.Instance.upper_right_punch1_Keycode = KeyCode.S;
    //    DataManager.Instance.upper_kick1_Keycode = KeyCode.D;
    //    DataManager.Instance.middle_left_punch1_Keycode = KeyCode.Z;
    //    DataManager.Instance.middle_right_punch1_Keycode = KeyCode.X;
    //    DataManager.Instance.middle_kick1_Keycode = KeyCode.C;
    //    DataManager.Instance.special_attack1_Keycode = KeyCode.V;
    //    DataManager.Instance.jump1_Keycode = KeyCode.UpArrow;
    //    DataManager.Instance.bend1_Keycode = KeyCode.DownArrow;
    //    DataManager.Instance.block1_Keycode = KeyCode.LeftControl;


    //    DataManager.Instance.upper_left_punch2_Keycode = KeyCode.Insert;
    //    DataManager.Instance.upper_right_punch2_Keycode = KeyCode.Home;
    //    DataManager.Instance.upper_kick2_Keycode = KeyCode.PageUp;
    //    DataManager.Instance.middle_left_punch2_Keycode = KeyCode.Delete;
    //    DataManager.Instance.middle_right_punch2_Keycode = KeyCode.End;
    //    DataManager.Instance.middle_kick2_Keycode = KeyCode.PageDown;
    //    DataManager.Instance.special_attack2_Keycode = KeyCode.Keypad7;
    //    DataManager.Instance.jump2_Keycode = KeyCode.Keypad8;
    //    DataManager.Instance.bend2_Keycode = KeyCode.Keypad2;
    //    DataManager.Instance.block2_Keycode = KeyCode.Keypad0;

    //}
}
