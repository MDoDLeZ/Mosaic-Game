using UnityEngine;

public class PC_Controller : MonoBehaviour
{
    private Movement movement;
    private Jump jump;

    private void Start()
    {
        movement = GetComponent<Movement>();
        jump = GetComponent<Jump>();
    }

    private void Update()
    {
        movement.Move(Input.GetAxis("Horizontal"));

        if (Input.GetButtonDown("Jump"))
            jump.startJump();
    }
}
