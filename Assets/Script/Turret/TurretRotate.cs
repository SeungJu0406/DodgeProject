using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotate : MonoBehaviour
{
    [SerializeField] float distance;

    [SerializeField] float rotateSpeed;

    [SerializeField] Turret turret;

    [HideInInspector] Transform target;

    GameManager gameManager;
    private void Start()
    {
        GameObject gameManagerInstance=GameObject.FindGameObjectWithTag("GameController");
        gameManager = gameManagerInstance.GetComponent<GameManager>();
    }

    private void Update()
    {
        if (gameManager.curState == GameManager.GameState.Progress) 
        {
            DetectTarget();
        }
    }
    
    public void DetectTarget()
    {
        int layerMask = 1 << LayerMask.NameToLayer("Player");
        Collider[] hits = Physics.OverlapSphere(transform.position, distance, layerMask);
        if(hits.Length > 0)
        {
            Vector3 targetDirection = hits[0].transform.parent.position - transform.position;
            Quaternion lookingTarget = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookingTarget, rotateSpeed * Time.deltaTime);
            turret.StartAttack();
        }
        else
        {
            turret.StopAttack();
        }
    }

    public void FindTarget()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        target = player.transform;
    }
}
