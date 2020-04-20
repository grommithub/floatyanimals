using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Kirby (1)")
        {
            AirScript.myAir = AirScript.myAir + 30;
            DestroyItemFunction();
        }
    }

    void DestroyItemFunction()
    {
        gameObject.SetActive(false);
    }
}
