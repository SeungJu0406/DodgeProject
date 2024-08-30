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
    void Init()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        bestScore = 0;
        curScore = 0;
    }
    void ReadyScore()
    {
        curScore = 0;
    }

    void StartScore()
    {
        if (timeRoutine == null)
        {
            timeRoutine = StartCoroutine(TimeRoutine());
        }
    }
    
    void GameOverScore()
    {
        if (timeRoutine != null)
        {
            StopCoroutine(timeRoutine);
            timeRoutine = null;
        }
        curScore = 0;
    }
    void GoalScore()
    {
        if (timeRoutine !=null)
        {
            StopCoroutine(timeRoutine);
            timeRoutine = null;
        }
        if(bestScore <= 0 || curScore < bestScore)
        {
            bestScore = curScore;
        }
    }

    IEnumerator TimeRoutine()
    {
        WaitForSeconds delay = new WaitForSeconds(1f);
        while (true)
        {    
            yield return delay;
            curScore++;
        }
    }
    public void Subscribe()
    {
        Manager.Game.OnReady += ReadyScore;
        Manager.Game.OnStart += StartScore;
        Manager.Game.OnGameOver += GameOverScore;
        Manager.Game.OnGoal += GoalScore;
    }

    public static void Create()
    {
        ScoreManager scoreManagerPrefab = Resources.Load<ScoreManager>("ScoreManager");
        Instantiate(scoreManagerPrefab);
    }
    public static void Release()
    {
        if (Instance == null) return;

        Destroy(Instance.gameObject);
        Instance = null;
    }
}
