using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] characters = new GameObject[15];
    private string characterName;

    // Start is called before the first frame update
    void Start()
    {
        characterName = DataManager.Instance.Character;
        Debug.Log(characterName);
        foreach(GameObject character in characters)
        {
            Debug.Log(character.name);
            if(string.Equals(characterName,character.name))
            {
                Instantiate(character);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBackButtonClick()
        /*
         * A back button I made for testing during development
         */
    {
        SceneManager.LoadScene(2);
    }
}
