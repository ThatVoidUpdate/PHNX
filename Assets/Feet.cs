using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Feet : MonoBehaviour
{
    public bool IsGrounded;

    public UnityEvent GroundedEvent;
    public UnityEvent UnGroundedEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsGrounded = true;
        GroundedEvent.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsGrounded = false;
        UnGroundedEvent.Invoke();
    }
}
