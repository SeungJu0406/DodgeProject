using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    [SerializeField] Rigidbody bulletRb;

    [SerializeField] Bullet bullet;

    [SerializeField] float speed;

    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        bulletRb.velocity = transform.forward * speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        bullet.bulletPool.ReturnPool(bullet);
    }
}
