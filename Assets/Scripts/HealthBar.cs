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
    // Start is called before the first frame update
    void Start()
    {
        sleep = 0;
        pressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        DrainHealth();
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
    }
}
