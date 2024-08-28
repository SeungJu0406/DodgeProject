using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IHit
{
    [SerializeField] int hp;

    public void Hit(int damage)
    {
        hp -= damage;
        if (hp < 0)
        {
            hp = 0;
            Die();
        }
    }
    void Die()
    {
        gameObject.SetActive(false);
    }
}
