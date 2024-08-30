using System;
using UnityEngine;

public class TurretRotate : MonoBehaviour
{

    [SerializeField] float distance;

    [SerializeField] float DetectingRotateSpeed;

    [SerializeField] float UndetectingRotateSpeed;

    [SerializeField] Turret turret;

    [SerializeField] Transform rayPoint;

    [HideInInspector] Transform target;

    int layerMask;

    bool canDetect;
    private void Start()
    {
        Manager.Game.OnReady += CantDetect;
        Manager.Game.OnStart += CanDetect;
        Manager.Game.OnGoal += CantDetect;
    }
    public void Update()
    {
        UndetectTarget();
    }
    public void DetectTarget(Player player)
    {
        Vector3 targetDirection = player.transform.position - transform.position;
        if (Physics.SphereCast(transform.position, 0.3f,targetDirection, out RaycastHit hit, distance))
        {
            if (hit.collider.gameObject.tag != "Player")
            {
                turret.StopAttack();
                return;
            }
            Quaternion lookingTarget = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookingTarget, DetectingRotateSpeed * Time.deltaTime);
            turret.StartAttack();
        }
    }
    void UndetectTarget()
    {
        if (!canDetect)
        {
            turret.StopAttack();            
        }
        if (turret.mode == Turret.Mode.Fire)
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, distance);
            foreach (Collider hit in hits)
            {
                if (hit.gameObject.tag == "Player")
                    return;
            }
            turret.StopAttack();
        }
        else if (turret.mode == Turret.Mode.Stop)
        {
            transform.Rotate(Vector3.up * UndetectingRotateSpeed * Time.deltaTime);
        }
    }

    void CanDetect()
    {
        canDetect = true;
    }
    void CantDetect()
    {
        canDetect = false;
    }
}
