using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float gravity = 1f;
    private Rigidbody2D rb;

    float timeToCollide = 0.0f;
    float interval = 0.5f;

    public float boingyness = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1f, 1f, 1f), 8f * Time.deltaTime);
        if(Input.GetButtonDown("Jump"))
        {
            transform.localScale *= 1.1f;
            rb.velocity = Vector2.up * 5.0f;
        }
        rb.velocity -= Vector2.up * gravity * Time.deltaTime;
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Time.time < timeToCollide) return;
        Vector3 scale = new Vector3();
        scale.x = 1.0f + boingyness * collision.relativeVelocity.magnitude;
        scale.y = 1.0f - boingyness * collision.relativeVelocity.magnitude;
        scale.z = 1f;

        float oldAngle = transform.rotation.eulerAngles.z;

        transform.up = collision.contacts[0].normal;
        transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z);

        float newAngle = transform.rotation.eulerAngles.z;
        float difference = newAngle - oldAngle;

        transform.GetChild(0).rotation = Quaternion.Euler(0f, 0f, transform.GetChild(0).rotation.eulerAngles.z - difference);
        scale.x = Mathf.Max(boingyness, scale.x);
        scale.y = Mathf.Max(boingyness, scale.y);

        scale.x = Mathf.Min(1.5f, scale.x);
        scale.y = Mathf.Min(1.5f, scale.y);

        transform.localScale = scale;

        rb.velocity = (collision.contacts[0].normal * collision.relativeVelocity.magnitude) * 0.95f;

        //timeToCollide = Time.time + interval;
    }
}
