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
    }

    // Update is called once per frame
    void Update()
    {
        if(!introSong.isPlaying && !buttonClick.isPlaying)
        {
            SceneManager.LoadScene(2); // Scene index 2 is character selection scene
        }
    }

    public void CloseWindow()
    {
        menuButtonSet.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ML1()
    {
        introSong.Stop();
        buttonClick.Play();
    }
    public void ML2()
    {

    }
    public void PvP()
    {

    }
}
