using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayMode : MonoBehaviour
{
    [SerializeField] private GameObject menuButtonSet;
    [SerializeField] private AudioSource introSong;
    private AudioSource buttonClick; // Not the regular click but the voice that saying "Welcome to the olympus tournament"

    // Start is called before the first frame update
    void Start()
    {
        buttonClick = GameObject.Find("Gameplay Button Set").GetComponent<AudioSource>();
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
        menuButtonSet.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ML1()
    {
        introSong.Stop();
        buttonClick.Play();
        DataManager.Instance.GameMode = "ML1";
        StartCoroutine(LoadAfterAudioStops());
    }
    public void ML2()
    {
        introSong.Stop();
        buttonClick.Play();
        DataManager.Instance.GameMode = "ML2";
    }
    public void PvP()
    {
        introSong.Stop();
        buttonClick.Play();
        DataManager.Instance.GameMode = "PvP";
        StartCoroutine(LoadAfterAudioStops());
    }

    IEnumerator LoadAfterAudioStops()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f); // return to 6 after done testing
            SceneLoader.Instance.LoadScene(2);
            break;
        }
        
    }
}
