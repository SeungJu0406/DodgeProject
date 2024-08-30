using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detecting : MonoBehaviour
{
    [SerializeField] float maxDetectingDistance;

    [SerializeField] Player player;

    private void Start()
    {
        Manager.Game.playerdetecting = this;
    }
    private void Update()
    {
       Detect();
    }

    void Detect()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, maxDetectingDistance);
        foreach (Collider hit in hits)
        {
            if (hit.transform.parent == null) continue; 
            IDetectable detectable = hit.transform.parent.GetComponent<IDetectable>();
            detectable?.Detect(player);
        }
    }

}