using UnityEngine;

public class TurretFire : MonoBehaviour
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
}
