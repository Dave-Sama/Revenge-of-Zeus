using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject buttonSet;
    [SerializeField] private GameObject exitGameMessage;
    [SerializeField] private GameObject gameplayModeWindow;
    [SerializeField] private GameObject settingsWindow; 
    private TextMeshProUGUI title;
    private TextMeshProUGUI pressToContinueText;

    // Start is called before the first frame update
    void Start()
    {
        title = GameObject.Find("Title Text").GetComponent<TextMeshProUGUI>();
        pressToContinueText = GameObject.Find("Press Any Key Text").GetComponent<TextMeshProUGUI>();
        InitializeControllers();
    }

    // Update is called once per frame
    void Update()
    {
        if(title.gameObject.activeInHierarchy && pressToContinueText.gameObject.activeInHierarchy)
        {
            PressAnyKey();
        }
        
    }

    void PressAnyKey()
    {
        if (Input.anyKeyDown)
        {
            title.gameObject.SetActive(false);
            pressToContinueText.gameObject.SetActive(false);
            buttonSet.SetActive(true);
        }
    }

    public void StartGame()
    {
        buttonSet.SetActive(false);
        gameplayModeWindow.SetActive(true);
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
    }

    public void InitializeControllers()
    {
        DataManager.Instance.upper_left_punch1_Keycode = KeyCode.A;
        DataManager.Instance.upper_right_punch1_Keycode = KeyCode.S;
        DataManager.Instance.upper_kick1_Keycode = KeyCode.D;
        DataManager.Instance.middle_left_punch1_Keycode = KeyCode.Z;
        DataManager.Instance.middle_right_punch1_Keycode = KeyCode.X;
        DataManager.Instance.middle_kick1_Keycode = KeyCode.C;
        DataManager.Instance.special_attack1_Keycode = KeyCode.V;
        DataManager.Instance.jump1_Keycode = KeyCode.UpArrow;
        DataManager.Instance.bend1_Keycode = KeyCode.DownArrow;
        DataManager.Instance.block1_Keycode = KeyCode.LeftControl;


        DataManager.Instance.upper_left_punch2_Keycode = KeyCode.Insert;
        DataManager.Instance.upper_right_punch2_Keycode = KeyCode.Home;
        DataManager.Instance.upper_kick2_Keycode = KeyCode.PageUp;
        DataManager.Instance.middle_left_punch2_Keycode = KeyCode.Delete;
        DataManager.Instance.middle_right_punch2_Keycode = KeyCode.End;
        DataManager.Instance.middle_kick2_Keycode = KeyCode.PageDown;
        DataManager.Instance.special_attack2_Keycode = KeyCode.Keypad7;
        DataManager.Instance.jump2_Keycode = KeyCode.Keypad8;
        DataManager.Instance.bend2_Keycode = KeyCode.Keypad2;
        DataManager.Instance.block2_Keycode = KeyCode.Keypad0;

    }
}
