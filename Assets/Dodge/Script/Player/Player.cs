using System;
using UnityEngine;

public class Player : MonoBehaviour, IHit
{
    [SerializeField] int hp;

    public event Action OnDie;

    bool canHit;

    void Awake()
    {
        CanHit();
    }
    void Start()
    {
        OnDie += Manager.Game.GameOver;
        Manager.Game.OnReady += CantHit;
        Manager.Game.OnStart += CanHit;
        Manager.Game.OnGoal += CantHit;
        Manager.Game.OnGameOver += CantHit;
        Camera.main.transform.parent = transform;
    }

    public void Hit(int damage)
    {
        if (!canHit)
            return;
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
    void CanHit()
    {
        canHit = true;
    }

    void CantHit()
    {
        canHit = false;
    }

}
