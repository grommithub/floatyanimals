using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinnerObstacle : InvokableObject
{
    [SerializeField] private float degrees = 0f, spinTime = 0f;
    [SerializeField] private LeanTweenType tweenType = LeanTweenType.easeInOutSine;

    private float rotation;
    protected override void LevelObjectAction()
    {
        rotation = transform.rotation.eulerAngles.z;
        LeanTween.value(gameObject, rotation, rotation + degrees, spinTime).setOnUpdate(SetRotation).setEase(tweenType);
    }
    private void SetRotation(float val) 
    {
        print("UPDATE");
        transform.rotation = Quaternion.Euler(0f, 0f, val);
    }
}
