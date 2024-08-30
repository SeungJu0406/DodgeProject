using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWall : MonoBehaviour
{
    [SerializeField] int openingTime;

    [SerializeField] GameObject doorWall;

    Coroutine timeChecker;
    private void Start()
    {
        timeChecker = StartCoroutine(CheckTime());
    }
    IEnumerator CheckTime()
    {
        WaitForSeconds delay = new WaitForSeconds(0.1f);
        while (true)
        {
            if(Manager.Score.curScore >= openingTime)
            {
                doorWall.SetActive(false);
            }
            yield return delay;
        }
    }
}
