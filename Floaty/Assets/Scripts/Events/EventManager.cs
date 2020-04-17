using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static EventManager manager;
    internal event Action GameStartEvent;
    internal event Action InitEvent;

    internal static EventManager GetManager()
    {
        if (manager != null) return manager;
        else
        {
            manager = FindObjectOfType<EventManager>();
            return manager;
        }
    }

    public void Initialize()
    {
        InitEvent?.Invoke();
    }
    public void StartGame()
    {
        GameStartEvent?.Invoke();
    }
}
