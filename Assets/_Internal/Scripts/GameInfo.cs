using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameInfo 
{
    private static GameStates GameState;
    public static bool IsStarted => GameState == GameStates.Started;
    public static bool IsAsteroidStarted => GameState == GameStates.AsteroidStarted;
    public static bool IsEnded => GameState == GameStates.Ended;

    public static ObservableValue<float> Distance = new ObservableValue<float>();
    public static ObservableValue<int> Score = new ObservableValue<int>();

    static GameInfo()
    {
        GameState = GameStates.Prepare;

        GlobalEvents.Other.StartGame.Event += () => { GameState = GameStates.Started; };
        GlobalEvents.Other.AsteroidsStarted.Event += () => { GameState = GameStates.AsteroidStarted; };
        GlobalEvents.Other.RocketCollapsed.Event += () => { GameState = GameStates.Ended; };
        GlobalEvents.Other.GameRestarted.Event += () => { GameState = GameStates.Prepare; };        
    }
}

public enum GameStates
{
    Prepare,
    Started,
    AsteroidStarted,
    Ended
}