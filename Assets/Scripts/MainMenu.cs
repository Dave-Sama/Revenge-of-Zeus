using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
   [SerializeField] private GameObject buttonSet;
    private TextMeshProUGUI title;
    private TextMeshProUGUI pressToContinueText;

    // Start is called before the first frame update
    void Start()
    {
        title = GameObject.Find("Title Text").GetComponent<TextMeshProUGUI>();
        pressToContinueText = GameObject.Find("Press Any Key Text").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        PressAnyKey();
    }

    void PressAnyKey()
    {
        if (Input.anyKeyDown)
        {
            title.gameObject.SetActive(false);
            pressToContinueText.gameObject.SetActive(false);
            buttonSet.SetActive(true);
        }
    }
}
