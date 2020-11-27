using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class GUIHolder : MonoBehaviour
{
    [SerializeField] private Image fader;
    [SerializeField] private TextMeshProUGUI startText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private const float fadeTime = 0.5f;

    private void Awake()
    {
        GameInfo.Score.OnChangedEvent += SetScoreText;
    }

    private void SetScoreText(int value)
    {
        scoreText.text = value.ToString();
    }

    // Called from GUI
    public void OnFaderClicked()
    {
        fader.raycastTarget = false;

        var sequence = DOTween.Sequence();
        sequence.Append(fader.DOFade(0, fadeTime));
        sequence.Join(startText.DOFade(0, fadeTime));
        sequence.AppendCallback(() =>
        {
            fader.gameObject.SetActive(false);
            GlobalEvents.Other.StartGame.Invoke();
        });
        sequence.Play();
    }

    private void OnDestroy()
    {
        GameInfo.Score.OnChangedEvent -= SetScoreText;
    }
}
