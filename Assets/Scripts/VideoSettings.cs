using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoSettings : MonoBehaviour
{

    [SerializeField] private GameObject mainSettings;
    [SerializeField] private GameObject controlSettingsWindow;
    [SerializeField] private GameObject videoSettingsWindow;

    private Resolution[] resolutions;

    public Dropdown resolutionsDropdown;

    // Start is called before the first frame update
    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionsDropdown.ClearOptions();

        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i<resolutions.Length; ++i)
        {
            options.Add(resolutions[i].width + " X " + resolutions[i].height);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionsDropdown.AddOptions(options);
        resolutionsDropdown.value = currentResolutionIndex;
        resolutionsDropdown.RefreshShownValue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeQuality(int qualityLevel)
    {
        QualitySettings.SetQualityLevel(qualityLevel);
    }

    public void toControl()
    {
        videoSettingsWindow.SetActive(false);
        controlSettingsWindow.SetActive(true);
    }

    public void CloseWindow()
    {
        videoSettingsWindow.SetActive(false);
        mainSettings.SetActive(true);
    } 

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height, Screen.fullScreen);
    }

}
