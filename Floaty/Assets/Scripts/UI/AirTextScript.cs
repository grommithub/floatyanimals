using UnityEngine;
using UnityEngine.UI;

public class AirTextScript : MonoBehaviour
{
    public Text AirText;

    void Update()
    {
        AirText.text = AirScript.myAir.ToString("0");
    }

}
