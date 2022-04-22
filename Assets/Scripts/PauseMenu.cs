using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEditor;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] Button resumeButton;
    EventSystem eventSystem;
    bool downArrowClicked;

    // Start is called before the first frame update
    void Start()
    {
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        downArrowClicked = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && !downArrowClicked)
        {
            resumeButton.Select();
            downArrowClicked = true;
        }
        if ((Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse1)) && downArrowClicked)
        {
            ResetDownArrowClicked();
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

    public void OnResume()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void OnBackToCharacters()
    {
        Time.timeScale = 1;
        DataManager.Instance.playerWonCounter = 0;
        DataManager.Instance.opponentWonCounter = 0;
        SceneLoader.Instance.LoadScene(2); // Scene index 2 = character selection scene
    }

    public void OnBackToMenu()
    {
        Time.timeScale = 1;
        DataManager.Instance.playerWonCounter = 0;
        DataManager.Instance.opponentWonCounter = 0;
        SceneLoader.Instance.LoadScene(0); // Scene index 0 = main menu scene
    }

    public void OnQuitButton()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
