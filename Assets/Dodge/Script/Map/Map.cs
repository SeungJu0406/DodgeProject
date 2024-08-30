using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField] int openingTime;

    [SerializeField] GameObject doorWall;

    [SerializeField] Goal goal;

    [HideInInspector] GameObject goalIntence;

    Coroutine timeChecker;

    private void Awake()
    {
        goalIntence = Instantiate(goal.gameObject);
        goalIntence.transform.parent = transform;
        goalIntence.SetActive(false);
    }
    private void Start()
    {
        Manager.Game.OnStart += StartCheckTime;
    }

    void StartCheckTime()
    {
        timeChecker = StartCoroutine(CheckTime());
    }
    IEnumerator CheckTime()
    {
        WaitForSeconds delay = new WaitForSeconds(0.1f);
        while (true)
        {
            if (Manager.Score.curScore >= openingTime)
            {
                goalIntence.gameObject.SetActive(true);
                doorWall.SetActive(false);
            }
            yield return delay;
        }
    }
}
