using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFire : MonoBehaviour
{
    [SerializeField] BulletPool bulletPool;

    [SerializeField] Transform muzzlePoint;
    
    [SerializeField] float attackTime;

    float curTime;

    private void Awake()
    {
        curTime = attackTime - 1;
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
