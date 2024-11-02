using System;
using JetBrains.Annotations;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    float gameTimer = 0f;
    [SerializeField] private float timeToWin = 300f;
    [SerializeField] private TimeSpan timePlaying;
    
    public delegate void GameWonHandler();
    public static event GameWonHandler OnGameWon;

    void Update()
    {
    TrackTime();
    }
    void TrackTime()
    {
        gameTimer += Time.deltaTime;
        timePlaying = TimeSpan.FromSeconds(gameTimer);
        string gameTimerStr = "Time:" + timePlaying.ToString("mm':'ss");
        timerText.text = gameTimerStr;

        if (gameTimer >= timeToWin)
        {
            OnGameWon?.Invoke();
        }
    }
}
