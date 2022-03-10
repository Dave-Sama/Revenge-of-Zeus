using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] characters = new GameObject[15];
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Slider healthBarFront;
    [SerializeField] private Slider healthBarBack;
    private string characterName;
    private Vector3 characterPosition = new Vector3(-2.13f, 0, 0);
    private float sleep; // sleep variable for dalying porpuses
    private bool pressed; // is space button pressed or not, temporary for development and testing

    // Start is called before the first frame update
    void Start()
    {
        characterName = DataManager.Instance.Character;
        foreach(GameObject character in characters)
        {
            Debug.Log(character.name);
            if(string.Equals(characterName,character.name))
            {
                Instantiate(character,characterPosition,character.transform.rotation);
            }
        }
        nameText.text = characterName;
        sleep = 0;
        pressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            healthBarFront.value = healthBarFront.value - 1;
            pressed = true;
        }
        if (sleep < 1 && pressed==true)
        {
            sleep += Time.deltaTime;
        }
        if (healthBarBack.value > healthBarFront.value && sleep>=1)
        {
           
            healthBarBack.value = healthBarBack.value - 0.01f;
        }
        if (healthBarBack.value <= healthBarFront.value)
        {
            sleep = 0;
            pressed = false;
        }
    }

    public void OnBackButtonClick()
        /*
         * A back button I made for testing during development
         */
    {
        SceneManager.LoadScene(2);
    }
}
