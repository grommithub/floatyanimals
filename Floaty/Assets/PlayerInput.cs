using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private KeyCode jump;
    internal bool GetJump()
    {
        return Input.GetKeyDown(jump);
    }
}
