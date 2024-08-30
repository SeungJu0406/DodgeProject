using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static GameManager Game { get { return GameManager.Instance; } }
    public static UIManager UI { get { return UIManager.Instance; } }

    public static ScoreManager Score { get { return ScoreManager.Instance; } }

    private void OnEnable()
    {
        GameManager.Create();
        UIManager.Create();
        ScoreManager.Create();
    }
    private void Start()
    {
        Score.Subscribe();
    }
}
