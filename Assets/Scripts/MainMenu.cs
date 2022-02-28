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
    private TextMeshProUGUI title;
    private TextMeshProUGUI pressToContinueText;

    // Start is called before the first frame update
    void Start()
    {
        title = GameObject.Find("Title Text").GetComponent<TextMeshProUGUI>();
        pressToContinueText = GameObject.Find("Press Any Key Text").GetComponent<TextMeshProUGUI>();
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
        SceneManager.LoadScene(2); // scene index 1 is the settings scene
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
}
