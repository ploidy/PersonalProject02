using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
public void PauseGame()
{
    Time.timeScale = 0f;
}
public void UnPauseGame()
{
    Time.timeScale = 1f;
}

void OnEnable()
{
    GameTimer.OnGameWon += HandleGameWon;
}

void OnDisable()
{
    GameTimer.OnGameWon -= HandleGameWon;
}

void HandleGameWon()
{
    PauseGame();
}
}
