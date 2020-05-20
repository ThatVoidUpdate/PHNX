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

    public float MaxHealth;
    private float Health;

    public float ThrowForce;

    // Start is called before the first frame update
    void Start()
    {
        BodyCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        Health = MaxHealth;
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

    public void EnableWallJump()
    {
        CanWallJump = true;
    }

    public void TakeDamage(float amount, Vector3 DamageOrigin)
    {
        print("OOF");
        Health -= amount;
        if (Health <= 0)
        {
            Die();
        }
        Vector2 ThrowDirection = (transform.position - DamageOrigin).normalized;
        rb.velocity = ThrowDirection * ThrowForce;
    }

    public void Die()
    {

    }
}
