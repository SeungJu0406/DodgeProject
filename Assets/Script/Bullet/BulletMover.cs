using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [SerializeField] Rigidbody bulletRb;
    [SerializeField] float speed;

    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        bulletRb.velocity = Vector3.forward * speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
