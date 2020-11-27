using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverView : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private RectTransform endPosition;

    private RectTransform rectTransform;
    private const float appearTime = 2.0f;

    private void Awake()
    {
        restartButton.onClick.AddListener(OnRestartButtonClicked);
        GlobalEvents.Other.RocketCollapsed.Event += GameOver;
        rectTransform = GetComponent<RectTransform>();
        restartButton.interactable = false;

        SetAllActive(false);
    }

    private void SetAllActive(bool value)
    {
        restartButton.gameObject.SetActive(value);
        gameOverText.gameObject.SetActive(value);
        scoreText.gameObject.SetActive(value);
    }

    public void OnRestartButtonClicked()
    {
        GlobalEvents.Other.GameRestarted.Invoke();
    }

    private void GameOver()
    {
        SetAllActive(true);
        scoreText.text = $"Score: {GameInfo.Score.Value}";

        var sequence = DOTween.Sequence();
        sequence.Append(rectTransform.DOMove(endPosition.position, appearTime))
            .SetEase(Ease.OutSine);
        sequence.AppendCallback(() =>
        {
            restartButton.interactable = true;
        });
        sequence.Play();
    }

    private void OnDestroy()
    {
        restartButton.onClick.RemoveListener(OnRestartButtonClicked);
        GlobalEvents.Other.RocketCollapsed.Event -= GameOver;
    }
}
