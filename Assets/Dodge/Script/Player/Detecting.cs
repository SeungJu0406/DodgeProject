using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Detecting : MonoBehaviour
{
    [SerializeField] float maxDetectingDistance;

    [SerializeField] Player player;

    bool canDetect;
    private void Start()
    {
        Manager.Game.OnReady += CantDetect;
        Manager.Game.OnStart += CanDetect;
        Manager.Game.OnGoal += CantDetect;
        Manager.Game.OnGameOver += CantDetect;

    }
    private void Update()
    {
       Detect();
    }

    void Detect()
    {
        if (!canDetect) return;
        Collider[] hits = Physics.OverlapSphere(transform.position, maxDetectingDistance);
        foreach (Collider hit in hits)
        {
            if (hit.transform.parent == null) continue; 
            IDetectable detectable = hit.transform.parent.GetComponent<IDetectable>();
            detectable?.Detect(player);
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