using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;
    [SerializeField] private GameObject LoadingScreen;
    [SerializeField] private Slider slider;

    //private void Awake()
    //{
    //    LoadingScreen = GameObject.Find("Loading Screen");
    //}
    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation opertaion = SceneManager.LoadSceneAsync(sceneIndex);
        LoadingScreen.SetActive(true);
        while (!opertaion.isDone)
        {
            float progress = Mathf.Clamp01(opertaion.progress / 0.9f);
            slider.value = progress;
            yield return null;
        }
    }
}
