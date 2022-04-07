using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSettings : MonoBehaviour
{
    public AudioSource AudioSource;
    private float musicVolume = 0f;

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

}
