using UnityEngine;

public class TurretRotate : MonoBehaviour
{

    [SerializeField] float distance;

    [SerializeField] float rotateSpeed;

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
        Debug.DrawRay(rayPoint.position, targetDirection * distance);
        if (Physics.Raycast(transform.position, targetDirection, out RaycastHit hit, distance))
        {
            if (hit.collider.gameObject.tag != "Player")
            {
                turret.mode = Turret.Mode.Stop;
                return;
            }
            Quaternion lookingTarget = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookingTarget, rotateSpeed * Time.deltaTime);
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
    }
    //public void FindTarget()
    //{
    //    GameObject player = GameObject.FindGameObjectWithTag("Player");

    //    target = player.transform;
    //}
}
