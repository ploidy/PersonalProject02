using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class Level : MonoBehaviour
{
int level = 1;
int experience = 0;
[SerializeField] XpBar xpBar;
[SerializeField] UpgradeMenuManager upgradeMenu;

public delegate void LevelUpHandler();
public static event LevelUpHandler OnLevelup;

int TO_LEVEL_UP
{
    get
    {
        return level * 900;
    }
}

private void Start()
{
    xpBar.UpdateXpSlider(experience, TO_LEVEL_UP);
    xpBar.SetLevelTest(level);
}

public void AddXp(int amount)
{
    experience += amount;
    CheckLevelUp();
    xpBar.UpdateXpSlider(experience, TO_LEVEL_UP);
}

public void CheckLevelUp()
{
    if(experience >= TO_LEVEL_UP)
    {
        LevelUp();
    }
}

void LevelUp()
    {
        experience -= TO_LEVEL_UP;
        level += 1;
        xpBar.SetLevelTest(level);
        OnLevelup?.Invoke();
    }

private void OnEnable()
{
    EnemyController.OnEnemyDead += AddXp;
}

private void OnDisable()
{
    EnemyController.OnEnemyDead -= AddXp;
}
}




