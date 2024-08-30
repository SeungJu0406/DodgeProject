using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.Rendering;

public class Turret : MonoBehaviour
{
    public enum Mode { Fire, Stop }

    [SerializeField] BulletPool bulletPool;

    [SerializeField] Transform muzzlePoint;

    [SerializeField] public float attackTime;


    float curTime;

    public Mode mode;

    private void Awake()
    {
        curTime = attackTime-1;
        mode = Mode.Stop;
    }

    private void Update()
    {
        CheckMode();
        if(mode == Mode.Fire)
        {
            Fire();
        }     
    }

    void Fire()
    {
        curTime += Time.deltaTime;
        if (curTime > attackTime)
        {
            bulletPool.GetPool(muzzlePoint.position, muzzlePoint.rotation);
            curTime = 0;
        }
    }
    void CheckMode()
    {
        if (mode == Mode.Stop)
        {
            StopAttack();
        }
        if (mode == Mode.Fire)
        {
            StartAttack();
        }
    }

    public void StartAttack()
    {
        mode = Mode.Fire;
    }
    public void StopAttack()
    {
        mode = Mode.Stop;
        curTime = attackTime-1;
    }
    public GameObject Clone()
    {
        return Instantiate(this.gameObject);
    }
}
