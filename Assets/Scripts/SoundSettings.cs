using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    //public AudioSource AudioSource;
    //public AudioSource musicClick;
    //public AudioSource buttonSet;
    public Slider volumeSlider;
    public GameObject savedPanel;
    //private float musicVolume = 1f;

    //[SerializeField] private GameObject soundSettingsWindow;
    //[SerializeField] private GameObject controlSettingsWindow;

    // Start is called before the first frame update
    void Start()
    {
        //AudioSource.Play();
        volumeSlider.value = DataManager.Instance.volume;
    }

    // Update is called once per frame
    void Update()
    {

        //AudioSource.volume = musicVolume;
        changeVolumeWithSlider();
    }

    //public void updateVolume(float volume)
    //{
    //    musicVolume = volume;
    //}

    //public void toControl()
    //{
    //    soundSettingsWindow.SetActive(false);
    //    controlSettingsWindow.SetActive(true);
    //}

    //public void toggleSFX(bool tog)
    //{
    //    if (tog)
    //    {
    //        musicClick.volume = 1f;
    //        buttonSet.volume = 1f;
    //    } else
    //    {
    //        buttonSet.volume = 0f;
    //        musicClick.volume = 0f;
    //    }
    //}



    // This is how not retarted programmers do this very easy task
    public void changeVolumeWithSlider()
    {
        AudioListener.volume=volumeSlider.value;
        DataManager.Instance.volume=volumeSlider.value;
    }

    public void SaveSound()
    {
        DataManager.Instance.SaveSettings();
        savedPanel.SetActive(true);
    }

    public void OnPressOKOnPanel()
    {
        savedPanel.SetActive(false);
    }

}
