using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool started;
    void Start()
    {
        EventManager.GetManager().Initialize();
    }
    // Update is called once per frame
    bool b;
    void Update()
    {
        if (Time.time > 3f && !b)
        {
            EventManager.GetManager().StartGame();
            b = true;
        }
    }
}
