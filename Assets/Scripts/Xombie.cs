using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Xombie : MonoBehaviour
{
    public float Speed;
    public float DamageAmount;

    public GameObject Drop;
    public float DropChance;

    public float MaxHealth;
    private float Health;

    private Vector3 DownLeftOffset = new Vector2(-0.52f, -0.549f);
    private Vector3 LeftOffset = new Vector2(-0.52f, 0);
    private Vector3 DownRightOffset = new Vector2(0.52f, -0.549f);
    private Vector3 RightOffset = new Vector2(0.52f, 0);

    private Rigidbody2D rb;

    private bool GoingLeft = true;

    private int layerMask;

    private void Start()
    {
        Health = MaxHealth;
        rb = GetComponent<Rigidbody2D>();
        layerMask = LayerMask.GetMask("PlayerCollision", "Player");
    }

    public void FixedUpdate()
    {
        bool canMoveLeft = !Physics2D.OverlapCircle(transform.position + LeftOffset, 0.1f, layerMask) && Physics2D.OverlapCircle(transform.position + DownLeftOffset, 0.1f, layerMask);
        bool canMoveRight = !Physics2D.OverlapCircle(transform.position + RightOffset, 0.1f, layerMask) && Physics2D.OverlapCircle(transform.position + DownRightOffset, 0.1f, layerMask);

        if (canMoveLeft && !canMoveRight && !GoingLeft)
        {
            GoingLeft = true;
        }
        if (!canMoveLeft && canMoveRight && GoingLeft)
        {
            GoingLeft = false;
        }        

        rb.velocity = new Vector2(GoingLeft ? -Speed : Speed, rb.velocity.y);
    }

    public void TakeDamage(float Damage)
    {
        Health -= Damage;
        if (Health <= 0)
        {
            Die();
        }
        print("akdhljksdns");
    }

    public void Die()
    {
        if (Random.Range(0f,1f) < DropChance)
        {
            Instantiate(Drop, transform.position, Quaternion.identity);
        }
        Destroy(this.gameObject);
    }
}
