using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSettings : MonoBehaviour
{
    public AudioSource AudioSource;
    public AudioSource musicClick;
    public AudioSource buttonSet;
    private float musicVolume = 1f;

    [SerializeField] private GameObject soundSettingsWindow;
    [SerializeField] private GameObject controlSettingsWindow;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource.volume = musicVolume;
    }

    public void updateVolume(float volume)
    {
        musicVolume = volume;
    }
    
    public void toControl()
    {
        soundSettingsWindow.SetActive(false);
        controlSettingsWindow.SetActive(true);
    }

    public void toggleSFX(bool tog)
    {
        if (tog)
        {
            musicClick.volume = 1f;
            buttonSet.volume = 1f;
        } else
        {
            buttonSet.volume = 0f;
            musicClick.volume = 0f;
        }
    }

}
