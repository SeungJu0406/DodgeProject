using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotate : MonoBehaviour
{
    [SerializeField] Transform target;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        target = player.transform;
    }

    private void Update()
    {
        transform.LookAt(target.position);
    }
}
