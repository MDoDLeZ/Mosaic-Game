using UnityEngine;

public class Climbing : MonoBehaviour
{
    public float climdForce;
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
            rb.velocity = transform.up * -climdForce;
        }

        //Debug.Log(transform.localRotation.eulerAngles.z);
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
        if (isClimbing)
        {
            if (transform.localRotation.eulerAngles.z == 270)
                transform.localScale = new Vector3(1, 1, 1);
            else
                transform.localScale = new Vector3(-1, 1, 1);

            transform.rotation = Quaternion.Euler(0, 0, 0);


            isClimbing = false;
        }
    }
}
