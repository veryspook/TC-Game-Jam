
using UnityEngine;

public class Player : MonoBehaviour
{
    //movement code ported from Brackets 2D movement video
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public Animator anim;    public bool isActive;
    private float horizontal;
    public float speed = 5f;
    public float jump = 16f;
    public GameObject otherForm;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private ParticleSystem switchParticles;
    public Transform groundCheck;
    private bool isGrounded;

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
        //this line is only here bc it keeps deassigning itself i dont know why
        anim = GetComponent<Animator>();

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        if (DialogueManager.ended && !UIManager.instance.win && !UIManager.instance.InMenu()) {        
            horizontal = Input.GetAxisRaw("Horizontal");
            rb.linearVelocityX = horizontal * speed;     
            if (Input.GetKeyDown(KeyCode.Q)) {
                SwitchForm();
                AudioManager.instance.PlaySound("Transform");
            }
            if (isActive) {
                anim.SetFloat("verticalVelocity", rb.linearVelocityY);
                anim.SetBool("onGround", isGrounded);
                if (rb.linearVelocityX != 0) {
                    anim.SetBool("walking", true);
                } else {
                    anim.SetBool("walking", false);
                }
                if (Input.GetButtonDown("Jump") && (isGrounded || UIManager.instance.extraJumps > 0)) {
                    if (!isGrounded) {
                        UIManager.instance.UseDRP();
                    }
                    rb.linearVelocityY = jump;
                    AudioManager.instance.PlaySound("Jump");
                }
                if (horizontal < 0f) {
                    spriteRenderer.flipX = true;
                } else if (horizontal > 0f) {
                    spriteRenderer.flipX = false;
                }
            }
        }
    }
    void SwitchForm() {
        isActive = false;
        gameObject.SetActive(false);
        otherForm.SetActive(true);
        otherForm.GetComponent<Player>().isActive = true;
        otherForm.transform.position = this.transform.position;
        switchParticles.transform.position = transform.position;
        switchParticles.Play();
    }

}
