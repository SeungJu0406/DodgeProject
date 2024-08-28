using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] BulletPool bulletPool;

    [SerializeField] Transform muzzlePoint;

    [SerializeField] float attackTime;

    float curTime;

    bool isAttack;

    private void Awake()
    {
        curTime = attackTime - 1;
    }

    private void Update()
    {
        if (!isAttack)
            return;
        curTime += Time.deltaTime;
        if (curTime > attackTime)
        {
            bulletPool.GetPool(muzzlePoint.position, muzzlePoint.rotation);
            curTime = 0;
        }
    }

    public void StartAttack()
    {
        this.isAttack = true;
    }
    public void StopAttack()
    {
        this.isAttack = false;
    }
    public GameObject Clone()
    {
        return Instantiate(this.gameObject);
    }
}
