using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalEvents
{
    public static AudioEvents Audio; // Audio can be implemented here
    public static SomeOtherEvents Other = new SomeOtherEvents();
}


public class AudioEvents
{
    public SimpleEvent PlayMusic;
    public SimpleEvent PlaySoundEffect;
    public SimpleEvent PlayBackgroundMusic;

}

public class SomeOtherEvents
{
    public SimpleEvent StartGame = new SimpleEvent();
    public SimpleEvent AsteroidsStarted = new SimpleEvent();
    public SimpleEvent RocketCollapsed = new SimpleEvent();
    public SimpleEvent GameRestarted = new SimpleEvent();
    public SimpleEvent ScreenTapped = new SimpleEvent();
}

public class SimpleEvent
{
    public event Action Event;
    public void Invoke() => Event?.Invoke();
}


