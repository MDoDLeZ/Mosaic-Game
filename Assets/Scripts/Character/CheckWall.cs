using UnityEngine;

public class CheckWall : MonoBehaviour
{
    public Transform feetPos;
    public Transform climbingIsWall;
    public float radCircle;
    public LayerMask isWall;

    private Climbing climbing;
    private bool contraBool;

    private void Start()
    {
        climbing = transform.parent.GetComponent<Climbing>();
    }

    private void Update()
    {
        contraBool = Physics2D.Linecast(transform.parent.position, climbingIsWall.position, isWall);

        if (!contraBool && climbing.isClimbing)
        {
            climbing.ClimbingContra();
            print("qwe");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.gameObject.layer == 8)
        {
            climbing.ClimbingStart();
        }

        if (other.gameObject.layer == 9)
        {
            climbing.ClimbingStop();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.parent.position, climbingIsWall.position);
    }
}
