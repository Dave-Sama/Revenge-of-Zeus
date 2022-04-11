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
    private GameObject CPUClone;
    private GameObject P1Clone;
    private GameObject P2Clone;

    // Start is called before the first frame update
    void Start()
    {
        color = imageOutline.effectColor;
        isInstanceExists = false;
        if (DataManager.Instance.GameMode == "PvP")
        {
            DataManager.Instance.IsPlayer = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WhenMouseHovering()
    {
        if (DataManager.Instance.GameMode=="ML1" || DataManager.Instance.GameMode=="ML2")
        {
            imageOutline.effectColor = Color.red;
            if (!isInstanceExists)
            {
                modelClone = Instantiate(model);
                GameObject P1NameText = GameObject.Find("P1 Name Text");
                GameObject P2NameText = GameObject.Find("P2 Name Text");
                P1NameText.SetActive(false);
                P2NameText.SetActive(false);
                isInstanceExists = true;
            }
        }
        if (DataManager.Instance.GameMode == "PvP")
        {
            if (DataManager.Instance.IsPlayer == true)
            {
                imageOutline.effectColor = Color.red;
                if (!isInstanceExists)
                {
                    modelClone = Instantiate(model, new Vector3(-3.41f, -1.04f, 0), model.transform.rotation);
                    GameObject CPUNameText = GameObject.Find("Name Text");
                    GameObject P2NameText = GameObject.Find("P2 Name Text");
                    CPUNameText.SetActive(false);
                    P2NameText.SetActive(false);
                    isInstanceExists = true;
                }

            }
            else
            {
                imageOutline.effectColor = Color.blue;
                if (!isInstanceExists)
                {
                    modelClone = Instantiate(model, new Vector3(3.41f, -1.04f, 0), model.transform.rotation); //rotatiion y=153.472f;
                    GameObject CPUNameText = GameObject.Find("Name Text");
                    GameObject P1NameText = GameObject.Find("P1 Name Text");
                    CPUNameText.SetActive(false);
                    P1NameText.SetActive(false);
                    isInstanceExists = true;
                }
            }
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
        if(DataManager.Instance.GameMode == "ML1" || DataManager.Instance.GameMode == "ML2")
        {
            characterName = gameObject.name;
            DataManager.Instance.PlayersCharacter = characterName;
            Destroy(modelClone);
            CPUClone=Instantiate(model);
            areYouSurePanel.SetActive(true);
        }
        if(DataManager.Instance.GameMode == "PvP")
        {
            characterName = gameObject.name;
            if (DataManager.Instance.IsPlayer == true)
            {
                DataManager.Instance.PlayersCharacter = characterName;
                Destroy(modelClone);
                P1Clone = Instantiate(model);
                DataManager.Instance.IsPlayer = false;
            }
            else
            {
                DataManager.Instance.OpponentsCharacter = characterName;
                Destroy(modelClone);
                P2Clone = Instantiate(model);
                areYouSurePanel.SetActive(true);
            }
        }
    }

    public void PressNoOnPanel()
    {
        areYouSurePanel.SetActive(false);
    }

    public void PressYesOnPanel()
    {
        DataManager.Instance.BattleNumber = 1;
        SceneManager.LoadScene(3); //index 3 = battle scene
    }
}
