using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XpBar : MonoBehaviour
{
    [SerializeField]Slider slider;
    [SerializeField] TMPro.TextMeshProUGUI levelText;

    public void UpdateXpSlider(int current, int target)
    {
        slider.maxValue = target;
        slider.value = current;
    }

    public void SetLevelTest(int level)
    {
        levelText.text = "Level: " + level.ToString();
    }
}

