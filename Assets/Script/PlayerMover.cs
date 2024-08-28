using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] Rigidbody playerRb;
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDir = new Vector3(x, 0, z);
        if (moveDir.magnitude > 1) // magnitude : ∫§≈Õ¿« ≈©±‚
        {
            moveDir.Normalize();
        }
        playerRb.velocity = moveDir * moveSpeed;


        if (x != 0 || z != 0)
        {
            Quaternion rotateDir = Quaternion.LookRotation(playerRb.velocity);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotateDir, rotateSpeed * Time.deltaTime);
        }

    }
}
