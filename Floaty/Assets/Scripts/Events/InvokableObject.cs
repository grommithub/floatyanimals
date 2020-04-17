using UnityEngine;

public class InvokableObject : MonoBehaviour
{
    private LevelObjectInvoker eventTrigger;

    private void OnEnable()
    {
        eventTrigger = GetComponentInParent<LevelObjectInvoker>();

        if (eventTrigger != null)
            eventTrigger.ObstacleEvent += LevelObjectAction;
    }
    private void OnDisable()
    {
        if (eventTrigger != null)
            eventTrigger.ObstacleEvent -= LevelObjectAction;
    }

    protected virtual void LevelObjectAction()
    {
        print("Invoke event: " + name);
    }
}
