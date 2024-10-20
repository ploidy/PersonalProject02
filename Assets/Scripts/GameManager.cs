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

    Time.timeScale = 0f;
    gameOverText.gameObject.SetActive(true);
    restartButton.gameObject.SetActive(true);
    isGameActive = false;
}
public void RestartGame()
{
    SceneManager.LoadScene("HordeSurvivorsScene");
}

}
