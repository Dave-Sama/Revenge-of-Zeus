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
        if (DataManager.Instance.GameMode == "PvP")
        {
            DataManager.Instance.IsPlayer = true;
        }
        DataManager.Instance.BlockTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WhenMouseHovering()
    {
        if (!DataManager.Instance.BlockTrigger)
        {
            if (DataManager.Instance.GameMode == "ML1" || DataManager.Instance.GameMode == "ML2")
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
                        GameObject[] P1NameText = GameObject.FindGameObjectsWithTag("P1");
                        CPUNameText.SetActive(false);
                        P1NameText[P1NameText.Length - 1].SetActive(false);
                        isInstanceExists = true;
                    }
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
        if (!DataManager.Instance.BlockTrigger)
        {
            if (DataManager.Instance.GameMode == "ML1" || DataManager.Instance.GameMode == "ML2")
            {
                characterName = gameObject.name;
                DataManager.Instance.PlayersCharacter = characterName;
                Destroy(modelClone);
                DataManager.Instance.CPUClone = Instantiate(model);
                GameObject P1NameText = GameObject.Find("P1 Name Text");
                GameObject P2NameText = GameObject.Find("P2 Name Text");
                P1NameText.SetActive(false);
                P2NameText.SetActive(false);
                DataManager.Instance.BlockTrigger = true;
                areYouSurePanel.SetActive(true);
            }
            if (DataManager.Instance.GameMode == "PvP")
            {
                characterName = gameObject.name;
                if (DataManager.Instance.IsPlayer == true)
                {
                    DataManager.Instance.PlayersCharacter = characterName;
                    Destroy(modelClone);
                    DataManager.Instance.P1Clone = Instantiate(model, new Vector3(-3.41f, -1.04f, 0), model.transform.rotation);
                    GameObject NameText = GameObject.Find("Name Text");
                    GameObject P2NameText = GameObject.Find("P2 Name Text");
                    NameText.SetActive(false);
                    P2NameText.SetActive(false);
                    DataManager.Instance.IsPlayer = false;
                }
                else
                {
                    DataManager.Instance.OpponentsCharacter = characterName;
                    Destroy(modelClone);
                    DataManager.Instance.P2Clone = Instantiate(model, new Vector3(3.41f, -1.04f, 0), model.transform.rotation);
                    GameObject NameText = GameObject.Find("Name Text");
                    GameObject[] P1NameText = GameObject.FindGameObjectsWithTag("P1");
                    NameText.SetActive(false);
                    P1NameText[P1NameText.Length-1].SetActive(false);
                    DataManager.Instance.BlockTrigger = true;
                    areYouSurePanel.SetActive(true);
                }
            }
        }
    }

    public void PressNoOnPanel()
    {
        DataManager.Instance.BlockTrigger = false;
        if ((DataManager.Instance.GameMode=="ML1" || DataManager.Instance.GameMode=="ML2") && DataManager.Instance.CPUClone != null)
        {
            Destroy(DataManager.Instance.CPUClone);
        }
        if (DataManager.Instance.GameMode=="PvP" && DataManager.Instance.P1Clone != null && DataManager.Instance.P2Clone != null)
        {
            Destroy(DataManager.Instance.P1Clone);
            Destroy(DataManager.Instance.P2Clone);
            DataManager.Instance.IsPlayer = true;
        }
        areYouSurePanel.SetActive(false);
    }

    public void PressYesOnPanel()
    {
        DataManager.Instance.BattleNumber = 1;
        SceneLoader.Instance.LoadScene(3); //index 3 = battle scene
    }
}
