using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] BulletPool bulletPool;

    [SerializeField] Transform muzzlePoint;
    
    [SerializeField] float attackTime;

    float curTime;

    private void Awake()
    {
        curTime = attackTime;
    }

    private void Update()
    {
       curTime += Time.deltaTime;
        if (curTime > attackTime) 
        {
            bulletPool.GetPool(muzzlePoint.position, muzzlePoint.rotation);
            curTime = 0;
        }
    }
}
