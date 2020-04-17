using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralObstacleScript : InvokableObject
{
    [SerializeField] private bool moving = false, rotating = false, scaling = false;


    private Vector2 startingPosition;
    private float startingRotation;
    private Vector3 startingScale;

    private Vector2 desiredPosition;
    private Vector2 positionLastFrame;
    private Vector2 positionThisFrame;

    //I may want to have several waypoints further down the line
    [Header ("Movement")]
    [SerializeField] private Vector2 translation;
    [SerializeField] private LeanTweenType movementTweenType;
    [SerializeField] private float movementTime;
    [SerializeField] private bool returningMovement;

    [Header("Rotation")]
    [SerializeField] private float rotationMagnitude;
    [SerializeField] private LeanTweenType rotationTweenType;
    [SerializeField] private float rotationTime;
    [SerializeField] private bool returningRotation;


    [Header("Scaling")]
    [SerializeField] private Vector3 newScale = new Vector3(1f,1f,1f);
    [SerializeField] private LeanTweenType scalingTweenType;
    [SerializeField] private float scalingTime;
    [SerializeField] private bool returningScale;

    [Space]
    [SerializeField] private float returningTime;


    private void Start()
    {
        desiredPosition = startingPosition;

        startingPosition = transform.position;
        startingRotation = transform.eulerAngles.z;
        startingScale    = transform.localScale;
    }

    protected override void LevelObjectAction()
    {

        LeanTween.cancel(gameObject);
        //do this with velocity later
        if (moving)
        {
            LeanTween.move(gameObject, startingPosition + translation, movementTime).setEase(movementTweenType).setOnComplete(Reset);
            //LeanTween.value(gameObject, startingPosition, startingPosition + desiredPosition, movementTime).setOnComplete(Reset);
        }
        if(rotating)
        {
            LeanTween.rotateZ(gameObject, transform.rotation.eulerAngles.z + rotationMagnitude,  rotationTime).setEase(rotationTweenType).setOnComplete(Reset);
        }
        if (scaling)
        {
            LeanTween.scale(gameObject, newScale, scalingTime).setEase(rotationTweenType).setOnComplete(Reset);
        }
    }

    private void Reset()
    {
        ReturnPosition();
        ReturnRotation();
        ReturnScale();
    }
    private void ReturnPosition()
    {
        if (returningMovement)
            LeanTween.move(gameObject, startingPosition, returningTime).setEase(movementTweenType);
    }
    private void ReturnRotation()
    {
        if (returningRotation)
            LeanTween.rotateZ(gameObject, startingRotation, returningTime).setEase(rotationTweenType);
    }
    private void ReturnScale()
    {
        if (returningScale)
            LeanTween.scale(gameObject, startingScale, returningTime).setEase(scalingTweenType);
    }

}
