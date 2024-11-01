using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameOverText;
    public Button restartButton;
    public bool isGameActive;
    public GameObject player;

    [SerializeField] GameObject winMenu;

    private void OnEnable()
    {
        GameTimer.OnGameWon += HandleGameWon;
        PlayerController.OnGameOver += GameOver;
    }

    private void OnDisable()
    {
        GameTimer.OnGameWon -= HandleGameWon;
        PlayerController.OnGameOver -= GameOver;
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        isGameActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.gameObject == null)
        {
            GameOver();
        }

}

public void GameOver()
{
    Debug.Log("Game Over!");
    Time.timeScale = 0f;
    gameOverText.gameObject.SetActive(true);
    restartButton.gameObject.SetActive(true);
    isGameActive = false;
}
public void RestartGame()
{
    SceneManager.LoadScene("HordeSurvivorsScene");
}
void HandleGameWon()
{
    Debug.Log("Player has won the game!");
    winMenu.SetActive(true);

}
}
