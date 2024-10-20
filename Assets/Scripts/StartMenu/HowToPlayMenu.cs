using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HowToPlayMenu : MonoBehaviour
{
    public GameObject howToPanel;
    // Start is called before the first frame update
public void OpenHowToMenu()
{
    if (howToPanel != null)
    {
        howToPanel.SetActive(true);
    }
}
public void CloseHowToMenu()
{
    howToPanel.SetActive(false);
}

}
