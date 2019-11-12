using UnityEngine;

public class Hide : MonoBehaviour
{
    public float radCircle;
    public LayerMask isHidePlace;
    public bool isHide;

    private bool checkHide;
    private GameObject sprite;
    private PC_Controller controller;
    private new BoxCollider2D collider2D;
    private Rigidbody2D rb;

    private void Start()
    {
        sprite = transform.Find("Sprite").gameObject;
        controller = GetComponent<PC_Controller>();
        collider2D = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        isHide = false;
    }

    public void HideStart()
    {
        checkHide = Physics2D.OverlapCircle(transform.position, radCircle, isHidePlace);

        if (checkHide && !isHide)
        {
            sprite.SetActive(false);
            controller.enabled = false;
            rb.bodyType = RigidbodyType2D.Static;
            collider2D.isTrigger = true;
            gameObject.tag = "Untagged";
            isHide = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            if (isHide)
            {
                sprite.SetActive(true);
                controller.enabled = true;
                rb.bodyType = RigidbodyType2D.Dynamic;
                collider2D.isTrigger = false;
                gameObject.tag = "Player";
                isHide = false;
            }
    }
}
