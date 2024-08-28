using UnityEngine;

public class Turret : MonoBehaviour
{
    public enum Mode { Fire, Stop }

    [SerializeField] BulletPool bulletPool;

    [SerializeField] Transform muzzlePoint;

    [SerializeField] float attackTime;

    float curTime;

    bool isAttack;

    int layermask;

    public Mode mode { get; private set; }

    private void Awake()
    {
        curTime = attackTime - 1;
        layermask = 1 << LayerMask.NameToLayer("Player");
    }

    private void Update()
    {
        if (!isAttack)
            return;
        //if (!Physics.Raycast(transform.position, transform.forward, layermask))
        //    return;
        curTime += Time.deltaTime;
        if (curTime > attackTime)
        {
            bulletPool.GetPool(muzzlePoint.position, muzzlePoint.rotation);
            curTime = 0;
        }
    }

    public void StartAttack()
    {
        mode = Mode.Fire;
        this.isAttack = true;
    }
    public void StopAttack()
    {
        mode = Mode.Stop;
        this.isAttack = false;
    }
    public GameObject Clone()
    {
        return Instantiate(this.gameObject);
    }
}
