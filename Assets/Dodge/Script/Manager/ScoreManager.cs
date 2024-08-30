using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public int bestScore;

    public int curScore;

    Coroutine timeRoutine;

    private void Awake()
    {
        Init();
    }


    IEnumerator TimeRoutine()
    {
        WaitForSeconds delay = new WaitForSeconds(1f);
        while (true)
        {
            curScore++;
            yield return delay;
        }
    }

    void Init()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
