using UnityEngine;

public class Player : MonoBehaviour
{
    //movement code ported from Brackets 2D movement video
    [SerializeField] private Rigidbody2D rb;
    private float horizontal;
    public float speed = 5f;
    public float jump = 16f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public Transform groundCheck;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded()) {
            rb.linearVelocityY = jump;
        }

        horizontal = Input.GetAxisRaw("Horizontal");
        rb.linearVelocityX = horizontal * speed;
        if (horizontal < 0f) {
            spriteRenderer.flipX = false;
        } else if (horizontal > 0f) {
            spriteRenderer.flipX = true;
        }
    }
    bool IsGrounded(){
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}
