using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGraphics : MonoBehaviour
{
    [SerializeField] private float puffFactor = 1.1f, squishiness = 0.5f, firmness = 5f;

    private void OnEnable()
    {
        var jump = GetComponent<PlayerJump>();
        var bounce = GetComponent<Bounce>();
        if(jump != null)
            jump.JumpEvent += Puff;
        if (bounce != null)
            bounce.BounceEvent += Squash;
    }
    private void OnDisable()
    {
        var jump = GetComponent<PlayerJump>();
        var bounce = GetComponent<Bounce>();
        if (jump != null)
            jump.JumpEvent -= Puff;
        if (bounce != null)
            bounce.BounceEvent -= Squash;
    }

    private void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1f, 1f, 1f), firmness * Time.deltaTime);
    }

    public void Puff()
    {
        transform.localScale *= puffFactor;
    }
    public void Squash(Collision2D collision)
    {
        Vector3 scale = new Vector3();
        scale.x = 1.0f + (squishiness * collision.relativeVelocity.magnitude);
        scale.y = 1.0f - (squishiness * collision.relativeVelocity.magnitude);
        scale.z = 1f;
        float oldAngle = transform.rotation.eulerAngles.z;
        transform.up = collision.contacts[0].normal;
        transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z);

        float newAngle = transform.rotation.eulerAngles.z;
        float difference = newAngle - oldAngle;

        if (transform.childCount > 0)
            transform.GetChild(0).rotation = Quaternion.Euler(0f, 0f, transform.GetChild(0).rotation.eulerAngles.z - difference);


        scale.x = Mathf.Min(1.0f + squishiness, scale.x);
        scale.y = Mathf.Max(1 - squishiness, scale.y);

        transform.localScale = scale;
    }
}
