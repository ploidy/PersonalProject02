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
    GameTimer.OnGameWon += PauseGame;
    UpgradeMenuManager.OnMenuOpen += PauseGame;
    UpgradeMenuManager.OnMenuClose += UnPauseGame;
    MainMenu.OnMenuOpen += PauseGame;
    MainMenu.OnMenuClose += UnPauseGame;
}

void OnDisable()
{
    GameTimer.OnGameWon -= PauseGame;
    UpgradeMenuManager.OnMenuOpen -= PauseGame;
    UpgradeMenuManager.OnMenuClose -= UnPauseGame;
    MainMenu.OnMenuOpen -= UnPauseGame;
    MainMenu.OnMenuClose -= UnPauseGame;

}

//void HandleGameWon(){PauseGame();}

}
