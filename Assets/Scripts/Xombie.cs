using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Xombie : MonoBehaviour
{
    public float Speed;
    public float DamageAmount;

    public GameObject Drop;
    public float DropChance;

    public float MaxHealth;
    private float Health;

    private void Start()
    {
        Health = MaxHealth;
    }

    public void Update()
    {
        //move the xombie forwards
    }

    public void TakeDamage(float Damage)
    {
        Health -= Damage;        
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
