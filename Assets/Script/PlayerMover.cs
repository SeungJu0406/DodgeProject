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
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        playerRb.velocity = new Vector3(x * moveSpeed, 0, z * moveSpeed);
        
        if (x != 0 || z != 0)
        {
            Quaternion rotateDir = Quaternion.LookRotation(playerRb.velocity);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotateDir, rotateSpeed * Time.deltaTime);
        }

    }
}
