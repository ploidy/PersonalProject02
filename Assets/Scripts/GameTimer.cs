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
    //public GameObject Player;
    //[SerializeField] GameObject winMenu;
    //PauseManager pauseManager;
    
    public delegate void GameWonHandler();
    public static event GameWonHandler OnGameWon;

    private void Awake()
    {
        //pauseManager = GetComponent<PauseManager>();
    }
    void Update()
    {
        //gameTimer += Time.deltaTime;
        //timePlaying = TimeSpan.FromSeconds(gameTimer);

        //string gameTimerStr = "Time:" + timePlaying.ToString("mm':'ss");
        //timerText.text = gameTimerStr;


       //if (gameTimer >= 300f)
        //{
           //GameWon();
        //}

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
            //GameWon();
        }
    }

//public void GameWon()
//{
        //pauseManager.PauseGame();
        //winMenu.SetActive(true);
//}

}
