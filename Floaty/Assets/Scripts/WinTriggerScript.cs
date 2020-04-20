using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTriggerScript : MonoBehaviour
{
    static public bool myWin = false;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Kirby (1)")
        {
            myWin = true;
        }
    }
}
