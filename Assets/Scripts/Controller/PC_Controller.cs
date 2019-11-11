using UnityEngine;

public class PC_Controller : MonoBehaviour
{
    private Movement movement;
    private Climbing climbing;
    private Jump jump;

    private void Start()
    {
        movement = GetComponent<Movement>();
        climbing = GetComponent<Climbing>();
        jump = GetComponent<Jump>();
    }

    private void Update()
    {
        if (climbing.isClimbing)
            if (transform.localRotation.eulerAngles.z == 180 || transform.localRotation.eulerAngles.z == 0)
                movement.Move(Input.GetAxisRaw("Horizontal"), 0);
            else
                movement.Move(0, Input.GetAxisRaw("Vertical"));
        else
            movement.Move(Input.GetAxisRaw("Horizontal"), 0);

        if (Input.GetButtonDown("Jump"))
        {
            jump.JumpStart();
        }
    }
}
