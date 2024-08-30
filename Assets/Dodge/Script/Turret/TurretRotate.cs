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

    GameManager gameManager;
    private void Start()
    {
        GameObject gameManagerInstance = GameObject.FindGameObjectWithTag("GameController");
        gameManager = gameManagerInstance.GetComponent<GameManager>();
        layerMask = 1 << LayerMask.GetMask("Player");
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
                turret.mode = Turret.Mode.Stop;
                return;
            }
            Quaternion lookingTarget = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookingTarget, DetectingRotateSpeed * Time.deltaTime);
            turret.mode = Turret.Mode.Fire;
        }
    }
    void UndetectTarget()
    {
        if (turret.mode == Turret.Mode.Fire)
        {
            Collider[] hits = Physics.OverlapSphere(transform.position, distance);
            foreach (Collider hit in hits)
            {
                if (hit.gameObject.tag == "Player")
                    return;
            }
            turret.mode = Turret.Mode.Stop;
        }
        else if (turret.mode == Turret.Mode.Stop)
        {
            transform.Rotate(Vector3.up * UndetectingRotateSpeed * Time.deltaTime);
        }
    }
}
