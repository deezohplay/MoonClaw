using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 7f;
    [SerializeField] float jumpForce = 15f;
    [SerializeField] float groundCheckRadius = 0.2f;

    public LayerMask groundLayer;
    public Transform groundCheck;

    float jumpTime;
    float jumpHoldTime;

    float xInput;

    Rigidbody2D rb;

    bool isJumping;
    bool isFacingRight;

    bool jump;

    bool isGrounded;
    public bool startGame;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        isFacingRight = true;
        startGame = false;
    }

    void Update()
    {
        if(startGame == true){
            if(jump && !isJumping)
            {
                jump = false;
                isJumping = true;
            }
        }
    }

    void FixedUpdate()
    {
        if(startGame == true){
            rb.linearVelocity = new Vector2(xInput*moveSpeed,rb.linearVelocity.y);
            
            //handles the player
            if(xInput < 0 && isFacingRight)
            {
                FlipPlayer();
            }else if(xInput > 0 && !isFacingRight)
            {
                FlipPlayer();
            }

            isGrounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,groundLayer);

            if(!isGrounded && isJumping)
            {
                isJumping = false;
                return;
            }
            if(isGrounded && isJumping)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                isJumping = false;
            }
        }
    }

    void FlipPlayer()
    {
        isFacingRight = !isFacingRight;
        Vector2 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale; 
    }

    public void HorizontalInput(float value)
    {
        xInput = value;
    }

    public void JumpInput()
    {
        jump = true;
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
    public void StartGame()
    {
        startGame = true;
    }
}
