using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Gun : MonoBehaviour
{
    public int MaxAmmo = 6;
    public int CurrentAmmo = 6;
    public int Damage = 1;

    public float CooldownTime;
    private float CurrentTime;

    public IntEvent UpdateUIAmmo;

    public Camera MainCamera;
    public GameObject player;
    public Vector3 gunOffset;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire1") == 1 && CurrentTime > CooldownTime && CurrentAmmo > 0)
        {
            CurrentTime = 0;
            Fire();
        }
        

        //apply rotation (mouse location to world space, set vector3 fwd/right)
        Vector3 mousePosition = Input.mousePosition;

        Vector3 Worldposition = MainCamera.ScreenToWorldPoint(mousePosition);

        Vector3 offset = Worldposition - transform.position;
        offset.z = transform.position.z;
        transform.right = offset.normalized;

        transform.position = player.transform.position + gunOffset;


        CurrentTime += Time.deltaTime;
    }

    public void Fire()
    {
        CurrentAmmo -= 1;
        UpdateUIAmmo.Invoke(CurrentAmmo);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, Mathf.Infinity, layerMask: LayerMask.GetMask("PlayerCollision", "Player"));
        

        if (hit.collider != null && hit.collider.gameObject.CompareTag("Xombie"))
        {
            hit.collider.GetComponent<Xombie>().TakeDamage(Damage);
        }
        Debug.DrawRay(transform.position, transform.right * 10, Color.green, 1);

        //play sound
        print("Bang");

    }
}
