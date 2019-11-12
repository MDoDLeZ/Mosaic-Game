using UnityEngine;

public class PC_Controller : MonoBehaviour
{
    private Movement movement;
    private Climbing climbing;
    private Jump jump;
    private Hide hide;

    private void Start()
    {
        movement = GetComponent<Movement>();
        climbing = GetComponent<Climbing>();
        jump = GetComponent<Jump>();
        hide = GetComponent<Hide>();
    }

    private void Update()
    {
        if (climbing.isClimbing)
            if (transform.localRotation.eulerAngles.z == 180 || transform.localRotation.eulerAngles.z == 0)
                movement.Move(Input.GetAxis("Horizontal"), 0);
            else
                movement.Move(0, Input.GetAxis("Vertical"));
        else
            movement.Move(Input.GetAxis("Horizontal"), 0);

        if (Input.GetButtonDown("Jump"))
        {
            jump.JumpStart();
            climbing.ClimbingStop();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            hide.HideStart();
        }
    }
}
