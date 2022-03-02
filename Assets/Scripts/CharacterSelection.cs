using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField] private Outline imageOutline;
    private Color color;

    // Start is called before the first frame update
    void Start()
    {
        color = imageOutline.effectColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColorWhenHovering()
    {
        imageOutline.effectColor = Color.red;
    }

    public void ChangeColorBackWhenNotHovering()
    {
        imageOutline.effectColor = color;
    }
}
