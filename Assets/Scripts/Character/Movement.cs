using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float max_Speed;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(float ax)
    {
        if ((ax > 0 && transform.localScale.x < 0) || (ax < 0 && transform.localScale.x > 0))
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        rb.velocity = new Vector2(ax * speed, rb.velocity.y);
    }

}
