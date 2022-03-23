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
        if (DataManager.Instance.IsPlayer && !DataManager.Instance.IsPlayerDead && !DataManager.Instance.IsPlayerDead && healthBarFront.tag == "Player" && healthBarBack.tag == "Player")
        {
            DrainHealth();
        }
        if (!DataManager.Instance.IsPlayer && !DataManager.Instance.IsOpponentDead && healthBarFront.tag == "Opponent" && healthBarBack.tag == "Opponent")
        {
            DrainHealth();
        }
        //if (Input.GetKey(KeyCode.Space)) // for testing
        //{
        //    DataManager.Instance.Damage = 5;
        //    DrainHealth();
        //}
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
        if (DataManager.Instance.Damage != 0)
        {
            healthBarFront.value = healthBarFront.value - DataManager.Instance.Damage;
            DataManager.Instance.Damage = 0;
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
        if(healthBarFront.value==0 && healthBarBack.value == 0 && !characterDied)
        {
            healthBarFront.gameObject.SetActive(false);
            healthBarBack.gameObject.SetActive(false);
            characterDied = true;
            if (healthBarFront.tag=="Player")
            {
                DataManager.Instance.IsPlayerDead = true;
            }
            if (healthBarFront.tag == "Opponent")
            {
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
