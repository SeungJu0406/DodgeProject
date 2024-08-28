using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour, IHit
{
    [SerializeField] int hp;

    public event Action OnDie;

    public void Hit(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
            Die();
        }
    }
    void Die()
    {
        OnDie?.Invoke();
        gameObject.SetActive(false);      
    }
}
