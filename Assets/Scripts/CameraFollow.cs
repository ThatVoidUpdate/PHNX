using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    public GameObject FollowObject;

    public float LerpFraction = 0.5f;

    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 LerpTarget = new Vector3(FollowObject.transform.position.x, FollowObject.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, LerpTarget, LerpFraction);
    }
}
