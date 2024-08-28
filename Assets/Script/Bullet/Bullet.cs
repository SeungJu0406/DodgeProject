using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] int damage;

    [HideInInspector] public BulletPool bulletPool;

    bool isAttack;

    private void OnEnable()
    {
        isAttack = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isAttack)
            return;
        IHit target = collision.gameObject.GetComponent<IHit>();
        if(target != null) 
        {
            target.Hit(damage);
        }
    }
}
