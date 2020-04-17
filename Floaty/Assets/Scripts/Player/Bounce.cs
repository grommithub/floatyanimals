using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]

public class Bounce : MonoBehaviour
{
    internal bool bounceEnabled = true;

    private Rigidbody2D rb;
    private float timeToCollide = 0.0f;
    [SerializeField] private float bounciness = 1.0f, interval = 0.5f;

    internal event Action<Collision2D> BounceEvent;

    private void OnEnable()
    {
        BounceEvent += Boing;
    }
    private void OnDisable()
    {
        BounceEvent -= Boing;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!bounceEnabled) return;
        if (Time.time < timeToCollide) return;

        BounceEvent?.Invoke(collision);
        timeToCollide = Time.time + interval;
    }

    private void Boing(Collision2D collision)
    {
        Vector2 bouncedirection = collision.contacts[0].normal * collision.relativeVelocity.magnitude;
        bouncedirection *= bounciness;
        rb.velocity += bouncedirection;

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        rb.velocity += collision.otherRigidbody.GetRelativePointVelocity(transform.position);
    }
}
