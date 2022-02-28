using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayMode : MonoBehaviour
{
    [SerializeField] private GameObject menuButtonSet;
    [SerializeField] private AudioSource introSong;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseWindow()
    {
        menuButtonSet.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ML1()
    {
        introSong.Stop();
    }
    public void ML2()
    {

    }
    public void PvP()
    {

    }
}
