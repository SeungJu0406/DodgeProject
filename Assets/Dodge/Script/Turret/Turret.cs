using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public enum Mode { Fire, Stop }

    [SerializeField] BulletPool bulletPool;

    [SerializeField] Transform muzzlePoint;

    [SerializeField] public float attackTime;


    Coroutine attackRoutine;

    public Mode mode;

    private void Awake()
    {
        mode = Mode.Stop;
    }

    private void Update()
    {
        CheckMode();

        Fire();
    }

    void Fire()
    {
        if (mode == Mode.Fire)
        {
            if (attackRoutine != null) { return; }
            attackRoutine = StartCoroutine(AttackRoutine());
        }
        else if (mode == Mode.Stop) 
        {
            if (attackRoutine == null) { return; }
            StopCoroutine(attackRoutine);
            attackRoutine = null;
        }
    }

    IEnumerator AttackRoutine()
    {
        WaitForSeconds delay = new WaitForSeconds(attackTime/2);
        while (true)
        {
            yield return delay;
            bulletPool.GetPool(muzzlePoint.position, muzzlePoint.rotation);
            yield return delay;
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
    }
    public GameObject Clone()
    {
        return Instantiate(this.gameObject);
    }
}
