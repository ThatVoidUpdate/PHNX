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
    public bool IsTouchingLeftWall;
    public bool IsTouchingRightWall;

    public bool CanWallJump;

    private Rigidbody2D rb;
    private BoxCollider2D BodyCollider;

    // Start is called before the first frame update
    void Start()
    {
        BodyCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float Horizontal = rb.velocity.x; ;

        if (IsGrounded)
        {
            Horizontal = Input.GetAxis("Horizontal") * HorizontalSpeed;
        }
        
        float Vertical = 0;
        if (Input.GetAxis("Jump") == 1 && IsGrounded)
        {
            Vertical = JumpForce;
        }
        else if (Input.GetAxis("Jump") == 1 && IsTouchingLeftWall && CanWallJump)
        {
            //fire off at an up-right angle
            Horizontal = JumpForce / 2;
            Vertical = JumpForce / 2;
        }
        else if (Input.GetAxis("Jump") == 1 && IsTouchingRightWall && CanWallJump)
        {
            //fire off at an up-left angle
            Horizontal = JumpForce / -2;
            Vertical = JumpForce / 2;
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

    public void LeftTouch()
    {
        IsTouchingLeftWall = true;
    }

    public void LeftRelease()
    {
        IsTouchingLeftWall = false;
    }

    public void RightTouch()
    {
        IsTouchingRightWall = true;
    }

    public void RightRelease()
    {
        IsTouchingRightWall = false;
    }
}
