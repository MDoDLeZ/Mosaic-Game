using UnityEngine;

public class Movement : MonoBehaviour
{
    public float default_speed;
    public float max_Speed;

    private Rigidbody2D rb;
    private Climbing climbing;
    private float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        climbing = GetComponent<Climbing>();
        speed = default_speed;
    }

    public void Move(float ax, float ay)
    {
        if (transform.localRotation.eulerAngles.z == 0)
        {
            if ((ax > 0 && transform.localScale.x < 0) || (ax < 0 && transform.localScale.x > 0))
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
        else if (transform.localRotation.eulerAngles.z == 180)
        {
            if ((ax > 0 && transform.localScale.x > 0) || (ax < 0 && transform.localScale.x < 0))
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }

        if (transform.localRotation.eulerAngles.z == 270)
        {
            if ((ay > 0 && transform.localScale.x > 0) || (ay < 0 && transform.localScale.x < 0))
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }
        else if (transform.localRotation.eulerAngles.z == 90)
        {
            if ((ay > 0 && transform.localScale.x < 0) || (ay < 0 && transform.localScale.x > 0))
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
        }

        if (climbing.isClimbing)
            if (transform.localRotation.eulerAngles.z == 180 || transform.localRotation.eulerAngles.z == 0)
                rb.velocity = new Vector2(ax * speed, rb.velocity.y);
            else
                rb.velocity = new Vector2(rb.velocity.x, ay * speed);
        else
            rb.velocity = new Vector2(ax * speed, rb.velocity.y);
    }
}
