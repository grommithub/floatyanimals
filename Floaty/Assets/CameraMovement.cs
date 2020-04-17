using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraMovement : MonoBehaviour
{
    private static CameraMovement camMove;
    private List<Transform> players = new List<Transform>();
    private float desiredX;

    private Vector3 startPos;

    [SerializeField] private float cameraMoveSpeed;

    private void Awake()
    {
        startPos = transform.position;
        var pls = FindObjectsOfType<PlayerMovement>();
        foreach (var p in pls) players.Add(p.transform);
    }

    private void Update()
    {
        CalculateDesiredPosition();
        UpdateCameraPosition();

    }

    private void UpdateCameraPosition()
    {
        float x = transform.position.x;
        x = Mathf.Max(startPos.x, Mathf.Lerp(x, desiredX, cameraMoveSpeed * Time.deltaTime));
        transform.position = new Vector3(x, startPos.y, startPos.z);
    }

    private void CalculateDesiredPosition()
    {
        desiredX = 0.0f;
        for(int i = 0; i < players.Count; i++)
        {
            desiredX += players[i].position.x;
        }
        desiredX /= players.Count;
    }
}
