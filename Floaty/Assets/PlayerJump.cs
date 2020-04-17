using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 5.0f;

    internal event Action JumpEvent;

    private void OnEnable()
    {
        JumpEvent += AddUpForce;
        JumpEvent += Puff;
    }
    private void OnDisable()
    {
        JumpEvent -= AddUpForce;
        JumpEvent -= Puff;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    internal void Jump()
    {
        JumpEvent?.Invoke();
    }

    private void AddUpForce()
    {
        float upforce = rb.velocity.y > 0.0f ? rb.velocity.y + jumpForce : jumpForce;
        rb.velocity = new Vector2(rb.velocity.x, upforce);
    }

    private void Puff()
    {
        transform.localScale *= 1.2f;
    }
}
