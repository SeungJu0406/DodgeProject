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
    public event Action OnWin;

    bool isWin;

    public void Hit(int damage)
    {
        if (isWin) return;
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

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Finish")
        {
            isWin = true;
            OnWin?.Invoke();
        }
    }
}
