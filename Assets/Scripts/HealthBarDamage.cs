using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarDamage : MonoBehaviour
{
    [SerializeField] private Slider healthBarDamage;
    [SerializeField] private Slider healthBarFront;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (healthBarDamage.value > healthBarFront.value)
        {
            healthBarDamage.value = healthBarDamage.value - 0.1f;
        }
    }
}
