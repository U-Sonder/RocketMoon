using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "SO/GameSettings")]
public class GameSettings : ScriptableObject
{
    [Range(0.5f, 5.0f)] public float Speed = 2.0f;
    [Range(0.1f, 0.5f)] public float AsteroidsSpawnFrequently = 0.2f;
    [Range(0.0f, 1.0f)] public float AsteroidsSpawnProbability = 0.4f;
    [Range(10, 20)] public int AsteroidsInitialAmount = 10;
    public int ScorePerSecond = 10;
}
