using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private Outline imageOutline;
    [SerializeField] private GameObject model;
    private Color color;
    private bool isInstanceExists;
    private Object modelClone;

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
}
