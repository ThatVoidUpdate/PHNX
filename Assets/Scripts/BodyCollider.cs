using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BodyCollider : MonoBehaviour
{
    public UnityEvent TouchedEvent;
    public UnityEvent ReleasedEvent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TouchedEvent.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        ReleasedEvent.Invoke();
    }
}
