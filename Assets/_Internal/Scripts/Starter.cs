using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Starter : MonoBehaviour
{
    private void Awake()
    {
        GlobalEvents.Other.GameRestarted.Event += OnRestart;

        GameInfo.Distance.Value = 0.0f;
        GameInfo.Score.Value = 0;
    }

    private void OnRestart()
    {
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

    private void OnDestroy()
    {
        GlobalEvents.Other.GameRestarted.Event -= OnRestart;
    }
}
