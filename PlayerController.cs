using System.Net.Mime;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce;
    public float speed;
    Rigidbody2D rb;

    public Transform groundDetector;
    bool isGrounded;
    public LayerMask whatIsGround;

    bool facingright = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerJump();
        Fliptrigger();
        DetectGround();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        float x = Input.GetAxisRaw("Horizontal");

        Vector3 movement = new Vector3(x * speed, rb.velocity.y, 0f);
        rb.velocity = movement;
    }
    void Fliptrigger()
    {
        if (rb.velocity.x < 0 && facingright)
        {
            FlipPlayer();
        }
        else if (rb.velocity.x > 0 && !facingright)
        {
            FlipPlayer();
        }
    }

    void FlipPlayer()
    {
        facingright = !facingright;

        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, 0f);
        }
    }

    void DetectGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundDetector.position, 0.1f, whatIsGround);
    }
}