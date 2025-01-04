using UnityEngine;
using UnityEngine.UI; // For button functionality

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;        // Speed of character movement
    public float jumpForce = 10f;      // Force of the character's jump
    public Transform groundCheck;     // Transform to check if the character is on the ground
    public float groundCheckRadius = 0.2f; // Radius of the ground check
    public LayerMask groundLayer;     // Layer considered as ground

    private Rigidbody2D rb;
    private bool isGrounded;
    private SpriteRenderer spriteRenderer;

    // Buttons for movement
    public Button leftButton;
    public Button rightButton;
    public Button jumpButton;

    private float moveDirection = 0f; // Direction to move (-1 for left, 1 for right, 0 for none)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Check if the character is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        // Apply movement
        // Flip the character's sprite based on movement direction
        if (moveDirection < 0)
        {
            spriteRenderer.flipX = true;
             // Apply movement
            rb.linearVelocity = new Vector2(moveDirection * moveSpeed, rb.linearVelocity.y);
        }
        else if (moveDirection > 0)
        {
            spriteRenderer.flipX = false;
             // Apply movement
            rb.linearVelocity = new Vector2(moveDirection * moveSpeed, rb.linearVelocity.y);
        }
    }

    public void MoveLeft()
    {
        moveDirection = -1f;
    }

    public void MoveRight()
    {
        moveDirection = 1f;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void OnDrawGizmos()
    {
        // Draw ground check radius in editor for visualization
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
