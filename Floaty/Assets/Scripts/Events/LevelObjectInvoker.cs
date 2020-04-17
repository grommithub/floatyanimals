using System;
using UnityEngine;

public class LevelObjectInvoker : MonoBehaviour
{
    internal event Action ObstacleEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.GetComponent<PlayerMovement>() != null)
            ObstacleEvent?.Invoke();
    }
}
