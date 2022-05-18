using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public int actionNum;
    Actions actions;

    // Start is called before the first frame update
    void Start()
    {
        actionNum = 0;
        actions=gameObject.AddComponent<Actions>();
    }

    // Update is called once per frame
    void Update()
    {
        actions.IntToAction(actionNum);
    }
}
