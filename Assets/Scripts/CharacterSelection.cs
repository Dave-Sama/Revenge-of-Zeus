using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private Outline imageOutline;
    [SerializeField] private GameObject model;
    [SerializeField] private GameObject areYouSurePanel;
    private Color color;
    private bool isInstanceExists;
    private Object modelClone;
    private string characterName;

    // Start is called before the first frame update
    void Start()
    {
        color = imageOutline.effectColor;
        isInstanceExists = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WhenMouseHovering()
    {
        imageOutline.effectColor = Color.red;
        if(!isInstanceExists)
        {
            modelClone=Instantiate(model);
            isInstanceExists = true;
        }
    }

    public void WhenMouseNotHovering()
    {
        imageOutline.effectColor = color;
        if(isInstanceExists)
        {
            Destroy(modelClone);
            isInstanceExists = false;
        }
    }

    public void onBackBtnClick()
    {
        SceneManager.LoadScene(0); //index 0 = main menu scene
    }

    public void onCharacterClick()
    {
        characterName = gameObject.name;
        areYouSurePanel.SetActive(true);
        
    }

    public void PressNoOnPanel()
    {
        areYouSurePanel.SetActive(false);
    }

    public void PressYesOnPanel()
    {
        DataManager.Instance.Character = characterName;
        SceneManager.LoadScene(3); //index 3 = battle scene
    }
}
