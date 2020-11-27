using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapHolder : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (GameInfo.IsStarted || GameInfo.IsAsteroidStarted)
        {
            GlobalEvents.Other.ScreenTapped.Invoke();
        }
    }
}
