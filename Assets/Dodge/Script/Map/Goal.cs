using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Goal : MonoBehaviour
{
    public event UnityAction OnWin;

    private void Start()
    {
        OnWin += Manager.Game.GoalGame;     
    }
    private void OnDisable()
    {
        OnWin -= Manager.Game.GoalGame;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            OnWin?.Invoke();
        }
    }
}
