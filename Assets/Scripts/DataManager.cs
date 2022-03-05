using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string GameMod { get; set; }
    public string Character { get; set; }

    void Awake()
        /*
         * Awake is like Start but is called even if the sctipt is disabled.
         * Basically I created a singleton that will never be destroyed when loading a new scene.
         * That way I can pass data between different scenes.
         */
    {
        if(Instance!=null)
        {
            Destroy(Instance);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
        /*
         * Update is called once per frame
         */
    {
        
    }
}
