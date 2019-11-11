using UnityEngine;

public class Climbing : MonoBehaviour
{
    public float climdForce;
    public Transform feetPos;
    public bool isClimbing;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isClimbing == true)
        {
            Vector2 grav = transform.up * -climdForce;
            rb.velocity = grav + rb.velocity;
        }

        Debug.Log(transform.localRotation.eulerAngles.z);
    }

    public void ClimbingStart()
    {
        float angle = transform.eulerAngles.z;

        if (transform.localScale.x > 0)
        {
            if (angle == 270)
                angle = 0;
            else
                angle = transform.eulerAngles.z + 90;
        }
        else
        {
            angle = transform.eulerAngles.z - 90;
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);

        isClimbing = true;
    }

    public void ClimbingContra()
    {
        float angle = transform.eulerAngles.z;

        if (transform.localScale.x > 0)
        {
            angle = transform.eulerAngles.z - 90;
        }
        else
        {
            if (angle == 270)
                angle = 0;
            else
                angle = transform.eulerAngles.z + 90;
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);

        isClimbing = true;
    }

    public void ClimbingStop()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        isClimbing = false;
    }
}
