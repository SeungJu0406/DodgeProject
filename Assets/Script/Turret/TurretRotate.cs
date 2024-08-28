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
        int layerMask = 1 << LayerMask.NameToLayer("Player");
        Collider[] hits = Physics.OverlapSphere(transform.position, distance, layerMask);
        if(hits.Length > 0)
        {
            turret.StartAttack();
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
