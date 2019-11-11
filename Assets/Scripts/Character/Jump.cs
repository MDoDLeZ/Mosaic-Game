using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce;
    public float radCircle;
    public float fallMultiplier;
    public float lowJumpmultiplier;
    public Transform feetPos;
    public LayerMask whatIsGround;

    private Rigidbody2D rb;
    private bool isGrounded;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void JumpStart()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, radCircle, whatIsGround);

        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void Update()
    {
        if (rb.velocity.y < 0) // Ускорение, когда игрок падает(конец прыжка)
        { 
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb.velocity.y > 0 && !Input.GetButton("Jump")) // Начало прыжка, меньший скорость
        { 
            rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpmultiplier - 1) * Time.deltaTime;
        }
    }
}
