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
    [SerializeField] private TimeSpan timePlaying;
    //public GameObject Player;
    [SerializeField] GameObject winMenu;
    PauseManager pauseManager;
    


    private void Awake()
    {
        pauseManager = GetComponent<PauseManager>();
    }
    // Update is called once per frame
    void Update()
    {
        gameTimer += Time.deltaTime;
        timePlaying = TimeSpan.FromSeconds(gameTimer);

        string gameTimerStr = "Time:" + timePlaying.ToString("mm':'ss");
        timerText.text = gameTimerStr;


       if (gameTimer >= 300f)
        {
            GameWon();
        }
}
public void GameWon()
{
        pauseManager.PauseGame();
        winMenu.SetActive(true);
}

}
