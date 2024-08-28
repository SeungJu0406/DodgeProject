using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotate : MonoBehaviour
{
    [SerializeField] float distance;

    [SerializeField] Turret turret;

    [HideInInspector] Transform target;


    private void Update()
    {
        DetectTarget();
    }
    
    public void DetectTarget()
    {
        transform.LookAt(target.position);
        Debug.DrawRay(transform.position, transform.forward * distance, Color.red);
        if(Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, distance))
        {
            if(hit.transform.gameObject.GetComponent<Player>() != null)
            {
                turret.StartAttack();
            }
            else
            {
                turret.StopAttack();
            }
        }
        else
        {
            turret.StopAttack();
        }
    }

    public void FindTarget()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        target = player.transform;
    }
}
