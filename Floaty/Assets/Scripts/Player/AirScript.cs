using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AirScript : MonoBehaviour
{
    static public bool myPlayerDeath = false;
    static public float myAir;
    void Start()
    {
        myAir = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if(WinTriggerScript.myWin != true)
        {
            myAir -= Time.deltaTime * 5;
        }

        if (myAir <= 0)
        {
            myPlayerDeath = true;
            DestroyPlayer();
        }
    }

    void DestroyPlayer()
    {
        gameObject.SetActive(false);
        SceneManager.LoadScene(2);
    }
}
