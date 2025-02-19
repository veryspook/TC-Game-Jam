using System.Diagnostics;
using UnityEngine;

public class Player : MonoBehaviour
{
    //movement code ported from Brackets 2D movement video
    [SerializeField] private Rigidbody2D rb;
    public bool isActive;
    private float horizontal;
    public float speed = 5f;
    public float jump = 16f;
    public GameObject otherForm;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public Transform groundCheck;

    void Start()
    {
        if (!isActive) {
            gameObject.SetActive(false);
        } else {
            gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            SwitchForm();
        }
        if (isActive) {
            if (Input.GetButtonDown("Jump") && IsGrounded()) {
                rb.linearVelocityY = jump;
                AudioManager.instance.PlaySound("Jump");
            }

            horizontal = Input.GetAxisRaw("Horizontal");
            rb.linearVelocityX = horizontal * speed;
            if (horizontal < 0f) {
                spriteRenderer.flipX = false;
            } else if (horizontal > 0f) {
                spriteRenderer.flipX = true;
            }
        }
    }
    bool IsGrounded(){
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    void SwitchForm() {
        isActive = false;
        gameObject.SetActive(false);
        otherForm.SetActive(true);
        otherForm.GetComponent<Player>().isActive = true;
        otherForm.transform.position = this.transform.position;
    }

}
