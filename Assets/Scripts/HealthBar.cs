using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider healthBarFront;
    [SerializeField] private Slider healthBarBack;
    private float sleep; // sleep variable for daleying time porpuses
    private bool pressed; // is space button pressed or not, temporary for development and testing
    private bool characterDied;
    // Start is called before the first frame update
    void Start()
    {
        sleep = 0;
        pressed = false;
        characterDied = false;
    }

    // Update is called once per frame
    void Update()
    {
        DrainHealth();
        if (Input.GetKeyDown(KeyCode.Space)) // for testing
        {
            DataManager.Instance.PlayersDamage = 10;
            DataManager.Instance.OpponentsDamage = 10;
            DrainHealth();
        }
        if(Input.GetKeyDown(KeyCode.Alpha2)) //for testing
        {
            DataManager.Instance.OpponentsDamage = 10;
            DrainHealth();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) //for testing
        {
            DataManager.Instance.PlayersDamage = 10;
            DrainHealth();
        }
        //if (DataManager.Instance.IsPlayerDead && healthBarFront.tag == "Player" && healthBarBack.tag == "Player") //candidate for deletion
        //{
        //    FillHealthBack();
        //}
        //if (DataManager.Instance.IsOpponentDead && healthBarFront.tag == "Opponent" && healthBarBack.tag == "Opponent")
        //{
        //    FillHealthBack();
        //}
    }

    void DrainHealth()
    {
        if(healthBarFront.tag == "Player" && healthBarBack.tag == "Player")
        {
            if (DataManager.Instance.PlayersDamage != 0)
            {
                healthBarFront.value = healthBarFront.value - DataManager.Instance.PlayersDamage;
                DataManager.Instance.PlayersDamage = 0;
                pressed = true;
            }
            if (sleep < 1 && pressed == true)
            {
                sleep += Time.deltaTime;
            }
            if (healthBarBack.value > healthBarFront.value && sleep >= 1)
            {
                healthBarBack.value = healthBarBack.value - 0.01f;
            }
            if (healthBarBack.value <= healthBarFront.value)
            {
                sleep = 0;
                pressed = false;
            }
            if (healthBarFront.value == 0)
            {
                healthBarFront.gameObject.SetActive(false);
                if(healthBarBack.value == 0)
                {
                    healthBarBack.gameObject.SetActive(false);
                }
            }
            if (healthBarFront.value == 0 && !characterDied)
            {
                characterDied = true;
                DataManager.Instance.IsPlayerDead = true;
            }
        }

        if(healthBarFront.tag=="Opponent" && healthBarBack.tag == "Opponent")
        {
            if (DataManager.Instance.OpponentsDamage != 0)
            {
                healthBarFront.value = healthBarFront.value - DataManager.Instance.OpponentsDamage;
                DataManager.Instance.OpponentsDamage = 0;
                pressed = true;
            }
            if (sleep < 1 && pressed == true)
            {
                sleep += Time.deltaTime;
            }
            if (healthBarBack.value > healthBarFront.value && sleep >= 1)
            {
                healthBarBack.value = healthBarBack.value - 0.01f;
            }
            if (healthBarBack.value <= healthBarFront.value)
            {
                sleep = 0;
                pressed = false;
            }
            if (healthBarFront.value == 0)
            {
                healthBarFront.gameObject.SetActive(false);
                if (healthBarBack.value == 0)
                {
                    healthBarBack.gameObject.SetActive(false);
                }
            }
            if (healthBarFront.value == 0 && !characterDied)
            {
                characterDied = true;
                DataManager.Instance.IsOpponentDead = true;
            }
        }
    }

    //void FillHealthBack() // candidate for deletion
    //{
    //    if (sleep < 5)
    //    {
    //        sleep += Time.deltaTime;
    //    }
    //    if(sleep >= 5)
    //    {
    //        healthBarFront.gameObject.SetActive(true);
    //        healthBarBack.gameObject.SetActive(true);
    //        currentRound = DataManager.Instance.CurrentRound;
    //        sleep = 0;
    //    }
    //    if(healthBarBack.value<healthBarBack.maxValue && healthBarFront.IsActive() && healthBarBack.IsActive())
    //    {
    //        healthBarBack.value = healthBarBack.value + 0.01f;
    //    }
    //    if(healthBarBack.value==healthBarBack.maxValue && sleep < 1 && healthBarFront.IsActive() && healthBarBack.IsActive())
    //    {
    //        sleep += Time.deltaTime;
    //    }
    //    if (sleep >= 1 && healthBarFront.IsActive() && healthBarBack.IsActive())
    //    {
    //        healthBarFront.value = healthBarFront.maxValue;
    //    }

    //}
}
