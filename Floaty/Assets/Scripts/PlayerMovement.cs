using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float gravity = 1f;
    private Rigidbody2D rb;
    private PlayerInput input;
    private PlayerJump jump;
    bool moving = true;

    private float force = 15f;
    
   [SerializeField] private float acceleration = 1f, horizontalMaxSpeed = 3f;
    public float maxVelocity = 5.0f;

    private void OnEnable()
    {
        EventManager.GetManager().GameStartEvent += EnablePlayerControl;
        EventManager.GetManager().InitEvent += DisablePlayerControl;
    }
    private void OnDisable()
    {
        if (EventManager.manager == null) return;
        EventManager.GetManager().GameStartEvent -= EnablePlayerControl;
        EventManager.GetManager().InitEvent -= DisablePlayerControl;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Cursor.lockState = CursorLockMode.Locked;
        jump = GetComponent<PlayerJump>();
        input = GetComponent<PlayerInput>();
    }

    private void DisablePlayerControl()
    {
        jump.enabled = false;
        moving = false;
    }

    private void EnablePlayerControl()
    {
        rb.velocity += Vector2.right * force;
        jump.enabled = true;
        moving = true;
    }

    private void Update()
    {
        if (!moving) return;
        if(input.GetJump())
        {
            jump.Jump();
        }
    }

    //should maybe move this or something
    private void FixedUpdate()
    {
        rb.velocity -= Vector2.up * gravity * Time.deltaTime;

        if (!moving) return;
        transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.eulerAngles.z + Input.GetAxis("Mouse X"));
        float multiplier = 1.0f;
        if (rb.velocity.x < acceleration) multiplier = 2.0f;
        rb.velocity += Vector2.right * acceleration * multiplier * Time.deltaTime;
        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = Vector2.Lerp(rb.velocity, Vector2.ClampMagnitude(rb.velocity, maxVelocity), 5.0f * Time.deltaTime);
        }



        if (Input.GetButtonDown("Jump") && name == "Kirby") EnablePlayerControl();
    }
}
