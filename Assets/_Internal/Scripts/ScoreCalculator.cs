using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    private int scorePerSecond;

    private void Awake()
    {
        scorePerSecond = Resources.Load<GameSettings>("GameSettings").ScorePerSecond;
        GameInfo.Distance.OnChangedEvent += CalculateScore;
    }

    private void CalculateScore(float value)
    {
        var score = Mathf.FloorToInt(GameInfo.Distance.Value) * scorePerSecond;
        if (GameInfo.Score.Value != score)
        {
            GameInfo.Score.Value = score;
        }
    }

    private void OnDestroy()
    {
        GameInfo.Distance.OnChangedEvent -= CalculateScore;
    }

}
