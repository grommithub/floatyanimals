using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBox : MonoBehaviour
{
    LeanTweenType doorTween = LeanTweenType.easeOutBounce;
    private void Start()
    {
        EventManager.GetManager().GameStartEvent += OpenDoor;
    }
    private void OnDestroy()
    {
        if (EventManager.manager == null) return;
        EventManager.GetManager().GameStartEvent -= OpenDoor;
    }

    private void OpenDoor()
    {
        LeanTween.rotateZ(transform.GetChild(0).gameObject, 95f, 1f).setEase(doorTween);
    }
}
