using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayMode : MonoBehaviour
{
    [SerializeField] private GameObject menuButtonSet;
    [SerializeField] private AudioSource introSong;
    [SerializeField] private GameObject gameplayPanel;
    [SerializeField] private GameObject agentPanel;
    private AudioSource buttonClick; // Not the regular click but the voice that saying "Welcome to the olympus tournament"

    // Start is called before the first frame update
    void Start()
    {
        buttonClick = GameObject.Find("Gameplay Button Set").GetComponent<AudioSource>();
        agentPanel.SetActive(false);
        DataManager.Instance.downArrowPressed = true;
    }

    // Update is called once per frame
    void Update()
    {
        //if(!introSong.isPlaying && !buttonClick.isPlaying)
        //{
        //    SceneManager.LoadScene(2); // Scene index 2 is character selection scene
        //    //SceneLoader.Instance.LoadScene(2);
        //}
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseWindow();
        }
    }

    public void CloseWindow()
    {
        DataManager.Instance.downArrowPressed = false;
        gameplayPanel.SetActive(true);
        agentPanel.SetActive(false);
        menuButtonSet.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ML1()
    {
       DataManager.Instance.GameMode = "ML1";
        DataManager.Instance.downArrowPressed = false;
        gameplayPanel.SetActive(false);
       agentPanel.SetActive(true);
    }
    public void PvP()
    {
        introSong.Stop();
        buttonClick.Play();
        DataManager.Instance.GameMode = "PvP";
        StartCoroutine(LoadAfterAudioStops());
    }

    public void Easy()
    {
        introSong.Stop();
        buttonClick.Play();
        DataManager.Instance.AgentName = "Easy";
        StartCoroutine(LoadAfterAudioStops());
    }
    public void Medium()
    {
        introSong.Stop();
        buttonClick.Play();
        DataManager.Instance.AgentName = "Medium";
        StartCoroutine(LoadAfterAudioStops());
    }
    public void Hard()
    {
        introSong.Stop();
        buttonClick.Play();
        DataManager.Instance.AgentName = "Hard";
        StartCoroutine(LoadAfterAudioStops());
    }
    IEnumerator LoadAfterAudioStops()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.2f); // return to 6 after done testing
            SceneLoader.Instance.LoadScene(2);
            break;
        }
        
    }
}
