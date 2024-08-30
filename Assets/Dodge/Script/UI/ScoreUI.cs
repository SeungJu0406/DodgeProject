using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] Text scoreText;
    int bestScore { get { return Manager.Score.bestScore; } }
    int curScore {  get { return Manager.Score.curScore; } }
    void Update()
    {
        if (curScore < bestScore)
        {
            scoreText.color =Color.green;
        }
        else
        {
            scoreText.color = Color.white;
        }
        scoreText.text = $"Best Score: {bestScore}\nCur Score: {curScore}";
    }
}
