using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float angle = 40.0f;
    [SerializeField] private float time = 0.75f;

    private bool isFacedRight;

    private void Awake()
    {
        GlobalEvents.Other.ScreenTapped.Event += Rotate;
        GlobalEvents.Other.RocketCollapsed.Event += StopRotation;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, angle);
        isFacedRight = true;        
    }

    private void Rotate()
    {
        var rotation = isFacedRight ? -angle : angle;
        transform.DORotate(new Vector3(0.0f, 0.0f, rotation), time)
            .SetEase(Ease.OutSine);
        isFacedRight = !isFacedRight;
    }

    private void StopRotation()
    {
        transform.DOKill();
    }

    private void OnDestroy()
    {
        GlobalEvents.Other.ScreenTapped.Event -= Rotate;
        GlobalEvents.Other.RocketCollapsed.Event -= StopRotation;
    }
}
