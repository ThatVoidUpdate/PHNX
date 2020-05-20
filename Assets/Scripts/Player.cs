using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public float HorizontalSpeed;
    public float JumpForce;
    public bool IsGrounded = true;

    private Rigidbody2D rb;
    private BoxCollider2D BodyCollider;
    private BoxCollider2D FootCollider;

    // Start is called before the first frame update
    void Start()
    {
        BodyCollider = GetComponent<BoxCollider2D>();
        FootCollider = GetComponentInChildren<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal") * HorizontalSpeed;
        float Vertical = 0;
        if (Input.GetAxis("Jump") == 1 && IsGrounded)
        {
            Vertical = JumpForce;
        }
        else
        {
            Vertical = rb.velocity.y;
        }
        rb.velocity = new Vector2(Horizontal, Vertical);
    }

    public void BecomeGrounded()
    {
        IsGrounded = true;
    }

    public void BecomeUnGrounded()
    {
        IsGrounded = false;
    }
}
